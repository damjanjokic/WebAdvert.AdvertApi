using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.IServices;
using AdvertApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertApi.Controllers
{
    [ApiController]
    [Route("api/adverts")]
    public class AdvertController : Controller
    {
        private readonly IAdvertStorageService _advertStorageService;
        public AdvertController(IAdvertStorageService advertStorageService)
        {
            _advertStorageService = advertStorageService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(404)] //NotFound
        [ProducesResponseType(201, Type = typeof(CreateAdvertResponse))] //Created
        public async Task<IActionResult> Create(AdvertModel model)
        {
            string recordId;
            try
            {
                 recordId = await _advertStorageService.Add(model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return StatusCode(201, new CreateAdvertResponse { Id = recordId });
        }

        [HttpPut]
        [Route("Confirm")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Confirm(ConfirmAdvertModel model)
        {
            try
            {
                await _advertStorageService.Confirm(model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception exp)
            {

                return StatusCode(500, exp.Message);
            }

            return new OkResult();
        }
    }
}