using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestTask.Core.Services;
using TestTask.Data.Dtos;

namespace TestTask.API.Controllers {
    [Route("api/[controller]")]
    public class MeteringDeviceController : Controller {
        private readonly MeteringDeviceService _meteringDeviceService;

        public MeteringDeviceController(MeteringDeviceService meteringDeviceService) {
            _meteringDeviceService = meteringDeviceService;
        }

        [HttpGet("/byTimeRange")]
        public async Task<ActionResult<List<MeteringDeviceDto>>> ListByTimeRangeAsync(
            [FromQuery(Name="startDateTimestamp")] long startDateTimestamp,
            [FromQuery(Name="endDateTimestamp")] long endDateTimestamp,
            CancellationToken cancellationToken
        ) {
            try {
                var meteringDevices = await _meteringDeviceService.GetInTimeRangeAsync(
                    startDateTimestamp,
                    endDateTimestamp,
                    cancellationToken
                );

                return meteringDevices;
            }
            catch (Exception ex) {
                return StatusCode(500, ex);
            }
        }
    }
}