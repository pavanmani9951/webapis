using Microsoft.AspNetCore.Mvc;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using MagicVilla_VillaAPI.Logging;
using Microsoft.EntityFrameworkCore;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]


    public class VillaAPIController:ControllerBase

    {
        //our created logger
        //private readonly ILogging _logger;
        //ILogger is default logger
        //private readonly ILogger<VillaAPIController> _logger;

        //public VillaAPIController(ILogging logger)
        //{
        //  _logger = logger;
        //}

        private readonly ApplicationDbContext _db;

        public VillaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }
    

            [HttpGet]
        public ActionResult <IEnumerable<VillaDTO>> GetVillas()
 // you have to mention return type for status code so using ActionResult we will help us to acheive that... 
        {
          //  _logger.Log("Getting all villas","");
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}",Name = "GetVilla")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
             //   _logger.Log("get villa error with id" + id,"error");
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if(villa == null){
                return NotFound();
            }
            return Ok(villa);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult <VillaDTO> CreateVilla ([FromBody]VillaDTO villaDTO)
        {
            if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomerError", "Villa already exist");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id >0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Location = villaDTO.Location,
                Rate = villaDTO.Rate,
                SqFt = villaDTO.SqFt,
            };
            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new {id=villaDTO.Id },villaDTO);
        }


        [HttpDelete ("{id:int}",Name ="DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult DeleteVilla (int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(u=> u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id,[FromBody] VillaDTO villaDTO)
        {
            if(villaDTO==null || id!=villaDTO.Id)
            {
                return BadRequest();
            }
            //var villa = _db.Villas.FirstOrDefault(u=>u.Id == id);
            //villa.Name = villaDTO.Name;
            //villa.Location= villaDTO.Location;
            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Location = villaDTO.Location,
                Rate = villaDTO.Rate,
                SqFt = villaDTO.SqFt,
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
