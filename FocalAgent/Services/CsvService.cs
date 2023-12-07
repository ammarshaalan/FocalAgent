using CsvHelper;
using CsvHelper.Configuration;
using FocalAgent.Interface;
using FocalAgent.Models;
using System.Globalization;

namespace FocalAgent.Services;

public class CsvService : ICsvService
{
    private const string MetadataFilePath = "Path\\To\\Your\\Project\\metadata.csv";
    private const string StatsFilePath = "Path\\To\\Your\\Project\\stats.csv";

    public List<Metadata> ReadMetadataFromCsv()
    {
        using var reader = new StreamReader(MetadataFilePath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        return csv.GetRecords<Metadata>().ToList();
    }

    public List<MovieStats> ReadStatsFromCsv()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);

        using var reader = new StreamReader(StatsFilePath);
        using var csv = new CsvReader(reader, config);
        return csv.GetRecords<MovieStats>().ToList();
    }

    public void WriteMetadataToCsv(List<Metadata> metadataList)
    {
        using (var writer = new StreamWriter(MetadataFilePath))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(metadataList);
        }
    }
}