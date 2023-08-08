using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.EF;
using TestTask.Data.Dtos;
using System;

namespace TestTask.Core.Services {
    public class ConsumerObjectService {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;
        private const int _counterExpirationDays = 30;
        private const int _currentTransformatorExpirationDays = 30;
        private const int _voltageTransformatorExpirationDays = 30;

        public ConsumerObjectService(
            TestTaskContext context,
            IMapper mapper
        ) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CounterDto>> ListExpiredCountersAsync(
            long consumerObjectId,
            CancellationToken cancellationToken
        ) {
            var deadline = DateTimeOffset.UtcNow.AddDays(-_counterExpirationDays);
            return await _context.MeasuringPoints
                .Where(measuringPoint =>
                    measuringPoint.ConsumerObjectId == consumerObjectId
                    && measuringPoint.CounterCheckDate < deadline
                )
                .ProjectTo<CounterDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}