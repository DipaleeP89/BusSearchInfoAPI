using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusReervationAPI.Infrastructure;
using BusReervationAPI.Models;
using BusReervationAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusReervationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private BusInfoContext _busInfoContext;
        
        public SearchController(BusInfoContext BusInfoContext)
        {
            this._busInfoContext = BusInfoContext;
            
        }
        [HttpPost("", Name = "GetSearchInfo")]
        public ActionResult<dynamic> GetSearchInfo(SearchModel searchmodel)
        {
            TryValidateModel(searchmodel);
            if (ModelState.IsValid)
            {
                var result = _busInfoContext.BusInfo.Where(a => a.FromLocation == searchmodel.FromLocation
                            && a.ToLocation == searchmodel.ToLocation && a.TravelDate == searchmodel.TravelDate).ToList();
                    
                    
                   
                if (result != null)
                {


                    return Ok(result);
                }
                else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
    }

}