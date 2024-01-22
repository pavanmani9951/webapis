using Microsoft.AspNetCore.Mvc;
using MagicVilla_VillaAPI.Models.DTO;
using MagicVilla_VillaAPI.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    public class VillaAPIController:ControllerBase

    {
        [HttpGet]
        public ActionResult <IEnumerable<VillaDTO>> GetVillas()
 // you have to mention return type for status code so using action result we will help us to acheive that... 
        {
            return Ok(VillaStore.VillaList);
        }

        [HttpGet("{id:int}",Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
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
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id >0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = VillaStore.VillaList.OrderByDescending(u=>u.Id).FirstOrDefault().Id+1;
            VillaStore.VillaList.Add(villaDTO);

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
            var villa = VillaStore.VillaList.FirstOrDefault(u=> u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            VillaStore.VillaList.Remove(villa);
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
            var villa = VillaStore.VillaList.FirstOrDefault(u=>u.Id == id);
            villa.Name = villaDTO.Name;
            villa.Location= villaDTO.Location;
            return NoContent();
        }
    }
}
