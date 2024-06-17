using Microsoft.AspNetCore.Mvc;
using Camping.Data;
using Camping.Models;
using Microsoft.AspNetCore.Authorization;

namespace Camping.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SpotController : ControllerBase
    {
        private DataContext _data;
        public SpotController (DataContext data)
        {
            this._data = data;
        }
        [HttpPost]
        
        public ActionResult Post (Spot spot)
        {
            _data.AddSpot(spot);
            
            return Ok("Spot added");
        }
        [HttpGet]
        public ActionResult<List<Spot>> Get ()
        {
            return Ok(_data.GetSpots());
        }
       
        
    }
}
