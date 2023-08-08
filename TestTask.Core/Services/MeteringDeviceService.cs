using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.EF;
using TestTask.Data.Dtos;

namespace TestTask.Core.Services {
    public class MeteringDeviceService {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;

        public MeteringDeviceService(
            TestTaskContext context,
            IMapper mapper
        ) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MeteringDeviceDto>> GetInTimeRangeAsync(
            long startDateTimestamp,
            long endDateTimestamp,
            CancellationToken cancellationToken
        ) {
            var startDate = DateTimeOffset.FromUnixTimeMilliseconds(startDateTimestamp);
            var endDate = endDateTimestamp == 0 ? DateTimeOffset.UtcNow :
                DateTimeOffset.FromUnixTimeMilliseconds(endDateTimestamp);

            return await _context.Measures
                .Include(measure => measure.DeliveryPoint)
                .Where(measure => measure.MeasureDate > startDate && measure.MeasureDate < endDate)
                .ProjectTo<MeteringDeviceDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}