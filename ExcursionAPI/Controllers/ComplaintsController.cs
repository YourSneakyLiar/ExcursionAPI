using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private IComplaintService _complaintService;
        public ComplaintsController(IComplaintService complaintsService)
        {
            _complaintService = complaintsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _complaintService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _complaintService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Complaint complaints)
        {
            await _complaintService.Create(complaints);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Complaint complaints)
        {
            await _complaintService.Update(complaints);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _complaintService.Delete(id);
            return Ok();
        }
    }
}