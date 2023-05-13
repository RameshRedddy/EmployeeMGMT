using AutoMapper;
using Azure;
using EmployeeMGMT.Data;
using EmployeeMGMT.Models;
using EmployeeMGMT.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using System.Collections;
using System.Data;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace EmployeeMGMT.Controllers
{
	[Route("api/EmployeeMGMT")]
	[ApiController]
	public class EmployeeMGMTController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;
		public EmployeeMGMTController(ApplicationDbContext db, IMapper mapper)

		{
			_db = db;
			_mapper = mapper;
		}


		//Get all user [HttpGet]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<UsersDTO>> GetUsers()
		{
			//logger.LogInformation("Getting all Users");
			return Ok(_db.Users.ToList());
		}

		//Get User by Id
		[HttpGet("Id:int",Name = "GetData")]
		//HttpGet("Id:int"]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]


		 public ActionResult GetUsers(int id)
		{
			if (id == 0)
			{
				//_logger.LogError("Get Users Error with Id" + id);
				return BadRequest();
			}
			var user = _db.Users.FirstOrDefault(u => u.Id == id);
			if (User == null)

			{

				return NotFound();
			}
			return Ok(user);
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		 public  ActionResult<UsersDTO> CreateUser([FromBody]UsersDTO usersDTO)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			//if (UserData.usersData.FirstOrDefault(u => u.Name.ToLower() == usersDTO.Name.ToLower()) != null) ;
			if (_db.Users.FirstOrDefault(u => u.Name.ToLower() == usersDTO.Name.ToLower()) != null) ;
			//{
			//	ModelState.AddModelError("", "USER Name Already Exists");
			//	return BadRequest(ModelState);
			//}

			if (usersDTO == null) 
			    {
			        return BadRequest(usersDTO);
			      }
			  if (usersDTO.Id > 0)
			    {
			      return StatusCode(StatusCodes.Status500InternalServerError);
			     }
			Users model = new Users()
			{

				Id = usersDTO.Id,
				Name = usersDTO.Name,
				Email = usersDTO.Email,
				Password = usersDTO.Password,
				Role = usersDTO.Role,
			};
			  _db.Users.Add(model);
			   _db.SaveChanges();
			      //usersDTO.Id = UserData.usersData.OrderByDescending(u=>u.Id).FirstOrDefault().Id + 1;
			      //UserData.usersData.Add(usersDTO);
			      //return CreatedAtRoute("GetData",new { id = usersDTO.Id}, usersDTO);
			      return Ok(usersDTO);
		 }

		[HttpDelete("{id:int}", Name = "DeleteUser")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult DeleteUser(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}
			var user =  _db.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
			{
				return NotFound();
			}
			_db.Users.Remove(user);
			_db.SaveChanges();
			return NoContent();
			
		}
		
		[HttpPut("{id:int}", Name = "UpdateUser")]
		 //[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult UpdateUser(int id, [FromBody] UsersDTO userDTO)
		{
			if (userDTO == null || id != userDTO.Id)
				{
					return BadRequest();
				}
			Users model = new Users()
			{
				Id = userDTO.Id,
				Name = userDTO.Name,
				Email = userDTO.Email,
				Password = userDTO.Password,
				Role = userDTO.Role,
			};
			_db.Users.Update(model);
			_db.SaveChanges();
			return NoContent();
		


		}
	
		
     }
}






