using AutoMapper;
using IoTdotnet.Dtos;
using IoTdotnet.Models;
using IoTdotnet.View;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace IoTdotnet.Services
{
    public class SensorService
    {
        private readonly SensorsDBContext _context;
        private readonly IMapper _mapper;
        private readonly Random _rng;
        public SensorService(SensorsDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _rng = new Random();
        }

        public async Task<Sensor> GetSensorByIdAsync(int id)
        {
            return await _context
                .sensors
                .Where(x => x.Id == id)
                //.Select(x => _mapper.Map<SensorVM>(x))
                .SingleOrDefaultAsync();
        }
        public async Task<ProjectVM> GetProjectVMByIdAsync(int id)
        {

            
            var p = await _context.projects.FindAsync(id);


            //var sensors_ = await _context.sensors.Where(x => x.ProjectId == id);
            

            return _mapper.Map<View.ProjectVM>(p);
            //.Select(x => _mapper.Map<SensorVM>(x))
            //.SingleOrDefaultAsync();
        }

  //      public int? GetFreeSensorId()
		//{
  //          for (int i = 0; i < 100; i++)
  //          {
  //          int id = _rng.Next();
  //          if(_context.sensors.Find(id) is null)
  //              {
  //                  return id;
  //              }
  //          }
  //          return null;
		//}

  //      public int? GetFreeProjectId()
  //      {
  //          for (int i = 0; i < 100; i++)
  //          {
  //              int id = _rng.Next();
  //              if (_context.projects.Find(id) is null)
  //              {
  //                  return id;
  //              }
  //          }
  //          return null;
  //      }


        public async Task<ProjectVM> CreateProjectAsync(int owner_id,NewProjectDto s)
        {
            var p = _mapper.Map<Models.Project>(s);

                var user = await _context.users.FindAsync(owner_id);
                if (user == null)
                    return null;
                p.Owner = user;
                //p.OwnerId = owner_id;
                //if(user.Projects is null)
                //    user.Projects = new List<Models.Project>() { p };
                //user.Projects.Add(p);
                
                _context.projects.Add(p);
                await _context.SaveChangesAsync();
                return _mapper.Map<ProjectVM>(p);

        }




  //      public async Task<Sensor> CreateSensorAsync(NewSensorDto s)
		//{
  //          //find new id 
  //          //var sensor_ = _mapper.Map<Sensor>(x);
  //          int? newId = GetFreeSensorId();
  //          if (newId == null)
  //              return null;

  //          int id = newId ?? default(int);
  //          return await CreateSensorAsync(id,s);

		//}
        public async Task<Sensor> CreateSensorAsync(int projectId, NewSensorDto x)
        {
            var m = _mapper.Map<Sensor>(x);

            //sensor.RecipesNumber++;

            //  1. Set the foreign key id
            //var sid_ = GetFreeSensorId();
            //if (sid_ is null)
            //    return null;
            //m.Id = sid_ ?? default(int);


            //  2. Set the foreign key by navigation property
            //m.RecipeBook = book;

            var project = await _context.projects.FindAsync(projectId);
            if (project == null)
                return null;
            //m.ProjectId = projectId;
            project.Sensors.Add(m);



            _context.sensors.Add(m);
            await _context.SaveChangesAsync();

            return m;// _mapper.Map<RecipeVM>(m);
        }

        public Task<bool> UpdateProjectAsync(int id, UpdateProjectDto project)
        {
            throw new NotImplementedException();
        }
    }
}
