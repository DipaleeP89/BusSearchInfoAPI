using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BusReervationAPI.Infrastructure;
using BusReervationAPI.Models;
using BusReervationAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        //get Bus Info on search
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

        [HttpPost("AddBookingInfo", Name = "BookingInfo")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<dynamic>> AddBookingInfo(BookingInfo bookingInfo)
        {
            TryValidateModel(bookingInfo);
            if (ModelState.IsValid)
            {
               
                await _busInfoContext.BookingInfos.AddAsync(bookingInfo);
                await _busInfoContext.SaveChangesAsync();
               
                return Created("", new
                {
                    bookingInfo.Id,
                    bookingInfo.Username,
                    bookingInfo.UserMobile,
                    bookingInfo.Email,
                    bookingInfo.BusInfoId ,
                    bookingInfo.TravelDate,
                    bookingInfo.SeatNo 
                });
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }

}