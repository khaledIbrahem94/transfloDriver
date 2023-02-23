using DTO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Driver.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IDriverService DriverService;

        public DriverController(IDriverService driverService)
        {
            this.DriverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            return Ok(await DriverService.GetAllDrivers());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDriverById(long Id)
        {
            return Ok(await DriverService.GetDriverById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertDriver(DriverDTO driver)
        {
            return Ok(await DriverService.InsertDriver(driver));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDriver(DriverDTO driver)
        {
            return Ok(await DriverService.UpdateDriver(driver));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDriver(long Id)
        {
            return Ok(await DriverService.DeleteDriver(Id));
        }
    }
}
