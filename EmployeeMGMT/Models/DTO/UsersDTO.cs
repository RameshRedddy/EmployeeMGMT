using System.ComponentModel.DataAnnotations;

namespace EmployeeMGMT.Models.DTO
{
	public class UsersDTO
	{
		public int Id { get; set; }
		//[Required]
		//[MaxLength(30)]
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }

	}
}
