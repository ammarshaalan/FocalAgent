using FocalAgent.Interface;
using FocalAgent.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly ICsvService _csvService;
    private const int PageSize = 10; // Set your desired page size


    public MovieController(ICsvService csvService)
    {
        _csvService = csvService;
    }

    [HttpPost("metadata")]
    public IActionResult AddMetadata([FromBody] Metadata metadata)
    {
        try
        {
            var metadataList = _csvService.ReadMetadataFromCsv();
            metadataList.Add(metadata);
            _csvService.WriteMetadataToCsv(metadataList);

            return Ok("Metadata added successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("metadata/{movieId}")]
    public IActionResult GetMetadata(int movieId)
    {
        try
        {
            var metadataList = _csvService.ReadMetadataFromCsv();
            var metadata = metadataList
                .Where(m => m.MovieId == movieId)
                .OrderByDescending(m => m.Id)
                .FirstOrDefault();

            if (metadata == null)
            {
                return NotFound("No metadata found for the specified movieId.");
            }

            return Ok(metadata);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpGet("movies/stats")]
    public IActionResult GetMovieStats()
    {
        try
        {
            // Retrieve watch duration stats
            var watchDurationStats = _csvService.ReadStatsFromCsv();

            // Retrieve metadata
            var metadataList = _csvService.ReadMetadataFromCsv();

            // Group watch duration stats by MovieId and calculate total watches and average watch duration
            var watchDurationStatsGrouped = watchDurationStats
                .GroupBy(w => w.movieId)
                .Select(group => new
                {
                    MovieId = group.Key,
                    metadataList.FirstOrDefault(metadata => metadata.MovieId == group.Key)?.Title,
                    TotalWatches = group.Count(), // Count the number of watches for each movie
                    AverageWatchDurationS = group.Average(w => w.watchDurationMs) / 1000, // Average watch duration in seconds
                    metadataList.FirstOrDefault(metadata => metadata.MovieId == group.Key)?.ReleaseYear
                })
                .ToList();

            return Ok(watchDurationStatsGrouped);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

}
