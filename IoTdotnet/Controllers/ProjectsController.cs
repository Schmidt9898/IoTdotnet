using IoTdotnet.Dtos;
using IoTdotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTdotnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly SensorService _sensorService;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(SensorService service, ILogger<ProjectsController> logger)
        {
            _sensorService = service;
            _logger = logger;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var r = await _sensorService.GetProjectVMByIdAsync(id);

            if (r == null)
            {
                return NotFound();
            }

            return Ok(r);
        }
        //[HttpGet("{id}/value")]
        //public async Task<IActionResult> GetSensorValueById(int id)
        //{
        //    var r = await _sensorService.GetProjectByIdAsync(id);

        //    if (r == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(r);
        //}

        // POST api/<RecipesController>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] NewProjectDto projectdto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var createdProject = await _sensorService.CreateProjectAsync(2, projectdto);
            if (createdProject == null)
                return NotFound();

            //return CreatedAtAction(nameof(GetById), new { Id = createdRecipe.Id }, createdRecipe);
            return Ok(createdProject);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectDto project)
        {
            var r = await _sensorService.GetProjectByIdAsync(id);

            if (r == null)
            {
                return NotFound();
            }

            return Ok(r);


            return await _sensorService.UpdateProjectAsync(id, project)
                ? NoContent()
                : NotFound();
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
    }
}
