using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderServicesController : ControllerBase
    {
        private IProviderServiceService _providerServiceService;
        public ProviderServicesController(IProviderServiceService providerServicesService)
        {
            _providerServiceService = providerServicesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _providerServiceService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _providerServiceService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProviderService providerServices)
        {
            await _providerServiceService.Create(providerServices);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProviderService providerServices)
        {
            await _providerServiceService.Update(providerServices);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _providerServiceService.Delete(id);
            return Ok();
        }
    }
}
