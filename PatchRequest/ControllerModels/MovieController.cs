using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatchRequest.Model;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace PatchRequest.ControllerModels
{
    [Route("api/movie")]
    public class MovieController : Controller
    {
        IList<Movie> Movies { get; set; }

        public MovieController()
        {
            Movies = new List<Movie>();

            Movies.Add(new Movie(1, "A Beautiful Mind","Ron Howard", new System.DateTime(2002, 3, 8)));
            Movies.Add(new Movie(2, "V For Vandetta", "James McTeigue", new System.DateTime(2006, 3, 31)));
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Movie> patchEntity)
        {
            var entity = Movies.FirstOrDefault(movie => movie.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            patchEntity.ApplyTo(entity, ModelState); // Must have Microsoft.AspNetCore.Mvc.NewtonsoftJson installed

            return Ok(entity);
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var entity = Movies.FirstOrDefault(movie => movie.Id == id);

            if (entity == null)
            {
                return NotFound();
            }


            return Ok(entity);
        }


    }
}
