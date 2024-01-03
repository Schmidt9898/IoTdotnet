using IoTdotnet.Dtos;
using IoTdotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

            //TODO loged in user

            var createdProject = await _sensorService.CreateProjectAsync("933b67d8-9f4a-41f5-9789-cb2b72de8994", projectdto);
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

            var vm = await _sensorService.UpdateProjectAsync(r, project);

            if (vm is not null)
            {
                //good
                return Ok(vm);
            }
            return NoContent();
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var r = await _sensorService.GetProjectByIdAsync(id);

            if (r == null)
            {
                return NotFound();
            }

            var ans = await _sensorService.DeleteProject(r);



            if (ans)
            {
                return Ok(new { Status = "Ok", Message = "Project has been deleted" });
            }else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   new { Status = "Error", Message = "Error during deletion." });
            }

            return NotFound();

            //return await _recipeBookService.DeleteRecipeAsync(id)
            //    ? NoContent()
            //    : NotFound();
        }


        [HttpPost("{id}/AddSensor")]
        public async Task<IActionResult> Post(int id,[FromBody] NewSensorDto dto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //TODO loged in user

            var sensor = await _sensorService.CreateSensorAsync(id, dto);
            if (sensor == null)
                return NotFound(); // todo more

            return Ok(sensor);
        }
        //[HttpGet("{id}/Senors")]
        //public async Task<IActionResult> GetSensorsByProjectId(int id)
        //{
        //    var r = await _sensorService.GetSensorVMsByProjectIdAsync(id);

        //    if (r == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(r);
        //}
    }
}
