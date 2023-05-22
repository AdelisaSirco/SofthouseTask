# SofthouseTask

The Softhouse Test app was built using a combination of technologies. On the front-end, it utilizes HTML, CSS, and JavaScript to create the user interface and handle form submission. The back-end is implemented using .NET Core, which provides the server-side functionality for processing the API requests. The app communicates with the Disney API to retrieve character information based on user input. Additionally, a SQL database is used to store and persist the character data.


The GetCharacterFromApi method is an HTTP GET method that retrieves character information from the Disney API. It takes a character name as a parameter and makes a request to the API endpoint using the provided name. The method uses the HttpClient class to send the request and receives the response. If the request is successful, the response content is deserialized into a CharactersModel object using JSON.NET.

The retrieved character information is then looped through, and for each character, a new Characters object is created and populated with the relevant data. This object is then added to the Characters DbSet in the database context (_dbContext). Finally, the changes are saved to the database using _dbContext.SaveChangesAsync().

The GetChar method is a helper method that performs the actual HTTP GET request to the Disney API. It takes a character name as a parameter and constructs the API URL with the name query parameter. It uses HttpClient to send the request and retrieves the response. If the response is successful, the content is read as a string and deserialized into a CharactersModel object using JSON.NET. The method then returns the deserialized object.


The UpdateCharacter method handles HTTP PUT requests to update existing character records in the database. It uses the [HttpPut("{id}")] attribute with the character ID included in the URL. The method receives the ID of the character to be updated and the updated properties through the CharacterUpdateModel parameter retrieved from the request body. It searches for the character in the database based on the provided ID and returns a 404 Not Found response if the character doesn't exist. The method updates the properties of the character with the values from the CharacterUpdateModel, including Name, SourceUrl, TVShows, ShortFilms, Films, and UpdatedAt. The changes are then saved to the database, and if successful, the updated character is returned with an HTTP 200 OK status. If any exceptions occur during the update process, an error message is logged, and an HTTP 500 Internal Server Error status is returned to indicate a server-side error.


GetCharacterFromApi and UpdateCharacter methods also retun output file that will be saved on your Desktop
