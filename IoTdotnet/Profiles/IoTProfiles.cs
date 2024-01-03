using IoTdotnet.Dtos;
using IoTdotnet.Models;
using AutoMapper;
using IoTdotnet.View;


namespace IoTdotnet.Profiles
{
    public class IoTProfiles : Profile
    {
        public IoTProfiles()
        {
            CreateMap<NewProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
            CreateMap<Project, ProjectVM>();


            CreateMap<NewSensorDto, Sensor>();
            CreateMap<UpdateSensorDto, Sensor>();
            CreateMap<Sensor, SensorVM>();


            CreateMap<IotUser, IotUserVM>();
            CreateMap<IotUserRegisterDto, IotUser>();
            //CreateMap<NewProjectDto, Project>();




        }
    }
}
