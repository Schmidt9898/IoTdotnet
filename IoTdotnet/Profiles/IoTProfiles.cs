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
            CreateMap<NewSensorDto, Sensor>();
            CreateMap<UpdateSensorDto, Sensor>();

            CreateMap<Project, ProjectVM>();


            CreateMap<IotUser, IotUserVM>();
            CreateMap<IotUserRegisterDto, IotUser>();
            //CreateMap<NewProjectDto, Project>();




        }
    }
}
