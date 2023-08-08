using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestTask.Core.Services;
using TestTask.Data.Dtos;

namespace TestTask.API.Controllers {
    [Route("api/[controller]")]
    public class MeasuringPointController : Controller {
        private readonly MeasuringPointService _measuringPointService;

        public MeasuringPointController(MeasuringPointService measuringPointService) {
            _measuringPointService = measuringPointService;
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateAsync(
            [FromBody] MeasuringPointDto dto,
            CancellationToken cancellationToken
        ) {
            try {
                var (result, measuringPointId) = await _measuringPointService.CreateAsync(dto, cancellationToken);

                if (result == ServiceResult.UnprocessableEntity) {
                    return StatusCode(422);
                }

                return measuringPointId!;
            }
            catch (Exception ex) {
                return StatusCode(500, ex);
            }
        }
    }
}