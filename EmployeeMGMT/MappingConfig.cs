using AutoMapper;
using EmployeeMGMT.Models;
using EmployeeMGMT.Models.DTO;

namespace EmployeeMGMT
{
	public class MappingConfig :  Profile
	{
		public MappingConfig()
		{
			CreateMap<Users, UsersDTO>();
			CreateMap<UsersDTO, Users>();

            CreateMap<Users, UserCreateDTO>().ReverseMap();
			CreateMap<Users, UserUpdatedDTO>().ReverseMap();
		}
	}
}
