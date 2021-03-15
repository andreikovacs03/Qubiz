using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API_101.Models;

namespace Web_API_101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetRecipes([FromQuery] int count)
        {
            Recipe[] recipes =
            {
                new(){Title = "Oxtail"},
                new(){Title = "Curry Chicken"},
                new(){Title = "Dumplings"},
            };

            if (!recipes.Any())
                return NotFound();
            return Ok(recipes.Take(count));
        }

        [HttpPost]
        public ActionResult CreateNewRecipes([FromBody] Recipe newRecipe)
        {
            bool badThingsHappened = false;

            if (badThingsHappened)
                return BadRequest();
            return Created("", newRecipe);
        }

        [HttpDelete]
        public ActionResult DeleteRecipes()
        {
            bool badThingsHappened = false;

            if (badThingsHappened)
                return BadRequest();
            return NoContent();
        }

    }
}
