using IoTdotnet.Dtos;
using IoTdotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTdotnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly SensorService _sensorService;
        private readonly ILogger<SensorsController> _logger;

        public SensorsController(SensorService service, ILogger<SensorsController> logger)
        {
            _sensorService = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSensorVMById(int id)
        {

            var s = await _sensorService.GetSensorVMByIdAsync(id);
            if (s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        [HttpGet("{id}/values")]
        public async Task<IActionResult> GetSensorValuesById(int id)
        {
            return NotFound();
            //var r = await _sensorService.

            //if (r == null)
            //{
            //    return NotFound();
            //}

            //return Ok(r);
        }
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> GetSensorById(int id)
        {
            return NotFound();
            //var r = await _sensorService.

            //if (r == null)
            //{
            //    return NotFound();
            //}

            //return Ok(r);
        }

        // POST api/<RecipesController>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] NewSensorDto sensordto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var createdRecipe = await _recipeBookService.CreateRecipeAsync(recipeBookId, recipe);
            //if (createdRecipe == null)
            //    return NotFound();

            //return CreatedAtAction(nameof(GetById), new { Id = createdRecipe.Id }, createdRecipe);
            return NotFound();
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}/Set/{value}")]
        public async Task<IActionResult> Put(int id,int value)
        {
            return NotFound();

            //return await _recipeBookService.UpdateRecipeAsync(id, recipe)
            //    ? NoContent()
            //    : NotFound();
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NotFound();

            //return await _recipeBookService.DeleteRecipeAsync(id)
            //    ? NoContent()
            //    : NotFound();
        }

        [HttpPut("{id}/AddUser/{user_id}")]
        public async Task<IActionResult> AddUser(int sensorId, int UserId)
        {
            return NotFound();

            //return await _recipeBookService.UpdateRecipeAsync(id, recipe)
            //    ? NoContent()
            //    : NotFound();
        }


    }
}
