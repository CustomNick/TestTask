using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Core.EF;
using TestTask.Data.Dtos;
using TestTask.Data.Entities;
using AutoMapper;

namespace TestTask.Core.Services {
    public class MeasuringPointService {
        private readonly TestTaskContext _context;
        private readonly IMapper _mapper;

        public MeasuringPointService(
            TestTaskContext context,
            IMapper mapper
        ) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<(ServiceResult, long?)> CreateAsync(
            MeasuringPointDto dto,
            CancellationToken cancellationToken
        ) {
            var consumer = await _context.ConsumerObjects.SingleOrDefaultAsync(
                co => co.Id == dto.ConsumerObjectId,
                cancellationToken
            );

            if (consumer == null) {
                return (ServiceResult.UnprocessableEntity, null);
            }

            var measuringPoint = _mapper.Map<MeasuringPoint>(dto);

            _context.MeasuringPoints.Add(measuringPoint);

            await _context.SaveChangesAsync(cancellationToken);

            return (ServiceResult.Ok, measuringPoint.Id);
        }
    }
}