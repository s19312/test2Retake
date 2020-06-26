using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2Retake.DTOs.Requets;
using test2Retake.Exceptions;
using test2Retake.Services;

namespace test2Retake.Controllers
{
    [ApiController]
    [Route("api/firefighters")]
    public class CustomeController : ControllerBase
    {
        private readonly IFireFighterDbService _service;
        public CustomeController(IFireFighterDbService service) {
            _service = service;
        }

        [HttpGet("api/firefighters/{id}/actions ")]
        public IActionResult GetListOfAction(int idFireman) {
            try {
                return Ok(_service.getLisiOfAction(idFireman));
            }
            catch (NoSuchFireFighterException ex) {
                return BadRequest("Such FireMan does not exists!");
            }
        }
        [HttpPut("api/actions/fire-trucks")]
        public IActionResult AssighFireTruck(AssignTruckRequest request) {
            try
            {
                _service.AssignTruck(request);
            }
            catch (NoSuchActionException ex)
            {
                return BadRequest("No such Action");
            }
            catch (NoSuchTruckException ex)
            {
                return BadRequest("No such Truck");
            }
            catch (CurrentlyUseSuchTruckException ex) {
                return BadRequest("Such Tuck currently used in another Action");
            }
            return Ok("Assigned!");
        }
    }
}
