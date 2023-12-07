using FocalAgent.Models;

namespace FocalAgent.Interface;

/// <summary>
/// Represents a service for reading and writing CSV data related to movies.
/// </summary>
public interface ICsvService
{
    /// <summary>
    /// Reads metadata information from a CSV file.
    /// </summary>
    /// <returns>A list of Metadata objects.</returns>
    List<Metadata> ReadMetadataFromCsv();

    /// <summary>
    /// Reads movie statistics information from a CSV file.
    /// </summary>
    /// <returns>A list of MovieStats objects.</returns>
    List<MovieStats> ReadStatsFromCsv();

    /// <summary>
    /// Writes metadata information to a CSV file.
    /// </summary>
    /// <param name="metadataList">The list of Metadata objects to be written to the CSV file.</param>
    void WriteMetadataToCsv(List<Metadata> metadataList);
}

