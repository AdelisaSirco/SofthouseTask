using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Softhouse_Test_App.Data;
using Softhouse_Test_App.Models;
using System.Data.Entity;
using System.Net.Http;
using System.Text.Json;
using System.IO;


namespace Softhouse_Test_App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(AppDbContext dbContext, ILogger<CharacterController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]

        public async Task<CharactersModel> GetCharacterFromApi(string name)
        {
            try
            {
                CharactersModel chars = null;

                chars = await GetChar(name);

                foreach (var item in chars.Data)
                {
                    Characters characters = new Characters();
                    characters.Name = item.Name;                   
                    characters.SourceUrl = item.SourceUrl;
                    characters.TVShows = item.TvShows;
                    characters.ShortFilms = item.ShortFilms;
                    characters.Films = item.Films;
                    characters.CreatedAt = item.CreatedAt;
                    characters.UpdatedAt = item.UpdatedAt;


                    _dbContext.Characters.Add(characters);
                    await _dbContext.SaveChangesAsync();

                }


              

                // Convert the CharactersModel to JSON string
                string json = System.Text.Json.JsonSerializer.Serialize(chars);
                
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\output.json";

                await System.IO.File.WriteAllTextAsync(filePath, json);

                return chars;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<CharactersModel> GetChar(string name)
        {
            using (var client = new HttpClient())
            {
                CharactersModel chars = null;
                string apiUrl = $"https://api.disneyapi.dev/character?name={name}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    chars = JsonConvert.DeserializeObject<CharactersModel>(content);
                }

                return chars;



            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCharacter([FromBody] Characters character)
        {
            try
            {
                
                var existingCharacter = await _dbContext.Characters.FindAsync(character.Id);
                if (existingCharacter == null)
                    return NotFound();

                // Update the character properties
                existingCharacter.Name = character.Name;               
                existingCharacter.Id = character.Id;
                existingCharacter.CreatedAt = character.CreatedAt;               
                existingCharacter.UpdatedAt = character.UpdatedAt;
                existingCharacter.SourceUrl= character.SourceUrl;
                existingCharacter.TVShows = character.TVShows;
                existingCharacter.ShortFilms = character.ShortFilms;
                existingCharacter.Films = character.Films;

                // Save the changes to the database
                await _dbContext.SaveChangesAsync();

                // Convert the CharactersModel to JSON string
                string json = System.Text.Json.JsonSerializer.Serialize(existingCharacter);

               
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\output.json";

                await System.IO.File.WriteAllTextAsync(filePath, json);




                return Ok(existingCharacter);


              

            }
            catch (Exception ex)
            {
                // Log any errors to the error log table
                _logger.LogError(ex, "An error occurred while updating the character.");
                return StatusCode(500, "An error occurred while updating the character.");
            }
        }


    }
    
}