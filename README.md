**Movie API**

This repository contains a simple REST API for a Movie Studio, implemented using .NET 8.0. The API provides three endpoints for managing movie metadata and statistics.

### Endpoints:

1. **POST /metadata**
   - Saves a new piece of metadata for a movie.
   - Request Body Example:
     ```json
     {
       "movieId": 3,
       "title": "Elysium",
       "language": "EN",
       "duration": "1:49:00",
       "releaseYear": 2013
     }
     ```
   
2. **GET /metadata/{movieId}**
   - Returns all metadata for a given movie.
   - Response Example:
     ```json
     [
       {
         "movieId": 3,
         "title": "Elysium",
         "language": "EN",
         "duration": "1:49:00",
         "releaseYear": 2013
       },
       {
         "movieId": 3,
         "title": "Kỷ Nguyên Elysium",
         "language": "VN",
         "duration": "1:49:00",
         "releaseYear": 2013
       }
     ]
     ```

3. **GET /movies/stats**
   - Returns viewing statistics for all movies.
   - Response Example:
     ```json
     [
       {
         "movieId": 3,
         "title": "Elysium",
         "averageWatchDurationS": 3600,
         "watches": 4000,
         "releaseYear": 2013
       },
       {
         "movieId": 6,
         "title": "Total Recall",
         "averageWatchDurationS": 5400,
         "watches": 3000,
         "releaseYear": 2012
       }
     ]
     ```

### Instructions to Run:

1. Clone this repository.
2. Ensure you have .NET 8.0 or the latest version installed.
3. Open the project in your preferred IDE.
4. Run the application.
5. Use a tool like Postman to interact with the API using the provided endpoints.

**Note**: The API reads data directly from the supplied `metadata.csv` file and `stats.csv` , and you do not need to set up a database.

### Configuration

The file paths for the CSV data files are configured in the `CsvService` class. Before running the application, please ensure that you update these file paths to match the location of your CSV files on your local machine.

#### CsvService File Paths

In the `CsvService` class (`FocalAgent/Services/CsvService.cs`), you will find the following file paths:

```csharp
private const string MetadataFilePath = "Path\\To\\Your\\Project\\metadata.csv";
private const string StatsFilePath = "Path\\To\\Your\\Project\\stats.csv";;
```

Update these paths according to the location of your `metadata.csv` and `stats.csv` files.
Feel free to explore and contribute to this simple Movie API!
