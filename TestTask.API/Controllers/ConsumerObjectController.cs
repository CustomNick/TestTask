using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestTask.Core.Services;
using TestTask.Data.Dtos;

namespace TestTask.API.Controllers {
    [Route("api/[controller]")]
    public class ConsumerObjectController : Controller {
        private readonly ConsumerObjectService _consumerObjectService;

        public ConsumerObjectController(ConsumerObjectService consumerObjectService) {
            _consumerObjectService = consumerObjectService;
        }

        [HttpGet("/{id}/expired/counters")]
        public async Task<ActionResult<List<CounterDto>>> ListExpiredCountersAsync(
            long id,
            CancellationToken cancellationToken
        ) {
            try {
                return await _consumerObjectService.ListExpiredCountersAsync(id, cancellationToken);
            }
            catch (Exception ex) {
                return StatusCode(500, ex);
            }
        }
    }
}