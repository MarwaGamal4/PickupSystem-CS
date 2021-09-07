using AutoMapper;
using MediatR;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.DeliveryRpt.Commands.SetDeliveryStatus
{
   public class SetStatusCommand : IRequest<Result<int>>
    {
        [Required]
        public int id { get; set; }
        public string driverLatitude { get; set; }
        public string driverLongitude { get; set; }
        public string deliveryNote { get; set; }
        [Required]
        public int deliveryStatus { get; set; }

    }

    public class SetStatusHandler : IRequestHandler<SetStatusCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDeliveryRptRepository _rptRepository;

        public SetStatusHandler(IUnitOfWork unitOfWork, IMapper mapper, IDeliveryRptRepository rptRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _rptRepository = rptRepository;
        }

        public async Task<Result<int>> Handle(SetStatusCommand request, CancellationToken cancellationToken)
        {
            var record = await _rptRepository.FindById(request.id);
            if (record == null )
            {
                return await Result<int>.FailAsync($"You have Enterd A wrong Value (id = {request.id})!");
            }
            if (request.deliveryStatus != 1)
            {
                if (String.IsNullOrEmpty(request.deliveryNote))
                {
                    return await Result<int>.FailAsync("You Must Provide a Note For The Action");
                }
                if (string.IsNullOrEmpty(request.driverLatitude) || string.IsNullOrEmpty(request.driverLongitude))
                {
                    return await Result<int>.FailAsync("You Must Provide You Location");
                }
            }
            var result = await _rptRepository.ChangeDeliverdState(request.id, request.deliveryStatus, request.deliveryNote, request.driverLatitude, request.driverLongitude);
            return await Result<int>.SuccessAsync(result,"Status Changed Successfuly");
        }
    }
}
