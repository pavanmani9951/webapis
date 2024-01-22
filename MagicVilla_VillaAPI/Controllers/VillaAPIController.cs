using Microsoft.AspNetCore.Mvc;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
   [Route("api/[controller]")]
    public class VillaAPIController:ControllerBase

    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa>
            {
                new Villa{Id=1,Name="Magroove Resort"},
                new Villa{Id=2,Name="ECR Resort and Villas"}
            };
        }
    }
}
