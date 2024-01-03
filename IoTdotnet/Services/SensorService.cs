using AutoMapper;
using IoTdotnet.Dtos;
using IoTdotnet.Models;
using IoTdotnet.View;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        //public async Task<Sensor> GetSensorByIdAsync(int id)
        //{
        //    return await _context
        //        .sensors
        //        .Where(x => x.Id == id)
        //        //.Select(x => _mapper.Map<SensorVM>(x))
        //        .SingleOrDefaultAsync();
        //}
        public async Task<ProjectVM> GetProjectVMByIdAsync(int id)
        {
            var p = await GetProjectByIdAsync(id);

            if (p == null)
                return null;
            return _mapper.Map<View.ProjectVM>(p);
        }
        public async Task<Models.Project> GetProjectByIdAsync(int id)
        {

            var b = _context.projects.Include(p => p.Owner).FirstOrDefault(x => x.Id == id);

            //var p = await _context.projects.FindAsync(id);

            //var u = await _context.users.FindAsync(p.Owner);

            return b;
        }


        public async Task<ProjectVM> CreateProjectAsync(string owner_id,NewProjectDto s)
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
        public async Task<SensorVM> CreateSensorAsync(int projectId, NewSensorDto x)
        {
            var m = _mapper.Map<Sensor>(x);
//            m.values = new List<int>();
            var project = await _context.projects.FindAsync(projectId);
            if (project == null)
                return null;
            m.project = project;
            //project.Sensors.Add(m);

            _context.sensors.Add(m);
            await _context.SaveChangesAsync();

            return _mapper.Map<SensorVM>(m);
        }

        public async Task<ProjectVM> UpdateProjectAsync(Models.Project project, UpdateProjectDto dto)
        {
            project.Name = dto.Name;
            project.Description = dto.Description;

            _context.Entry(project).State = EntityState.Modified;
            var n = _context.SaveChanges();

            return _mapper.Map<ProjectVM>(project);
        }

        public async Task<bool> DeleteProject(Models.Project r)
        {
            _context.projects.Remove(r);
            _context.SaveChanges();
            return true;
        }

        public async Task<SensorVM> GetSensorVMByIdAsync(int id)
        {
            var sensor = await GetSensorByIdAsync(id);
            return _mapper.Map<SensorVM>(sensor);
        }
        public async Task<Sensor> GetSensorByIdAsync(int id)
        {
            var sensor = _context.sensors.Include(s => s.project).FirstOrDefault(s => s.Id == id);

            //return sensor;
            return sensor;
        }

        //internal Task GetSensorVMsByProjectIdAsync(int id)
        //{
        //    return await _context
        //                .sensors
        //                .Where(x => x.Id == id)
        //                //.Select(x => _mapper.Map<SensorVM>(x))
        //                .SingleOrDefaultAsync();
        //}
    }
}