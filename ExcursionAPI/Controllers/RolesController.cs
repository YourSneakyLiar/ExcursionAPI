using BusinessLogic.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExcursionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleService _roleService;
        public RolesController(IRoleService rolesService)
        {
            _roleService = rolesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _roleService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Role roles)
        {
            await _roleService.Create(roles);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Role roles)
        {
            await _roleService.Update(roles);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.Delete(id);
            return Ok();
        }
    }
}
