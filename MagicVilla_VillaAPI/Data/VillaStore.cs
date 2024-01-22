using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>  
            {
                new VillaDTO{Id=1,Name="Magroove Resort",Location="chennai"},
                new VillaDTO{Id=2,Name="ECR Resort and Villas",Location="chennai"},
                new VillaDTO { Id = 3, Name = "ECR Resort with beach view",Location="chennai" }
            }; 
    }
}
