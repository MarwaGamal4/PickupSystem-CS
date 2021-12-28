using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pickup.Application.Features.Plans.Commands.AddEdit.dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Application.Models.ERP;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Plans.Commands.AddEdit
{
   public class AddEditPlanCommand : IRequest<Result<TbPlanMasterHdr>>
    {
        public int Id { get; set; }
        [Required]
        public string PlanName { get; set; }
        public string PlanExprission { get; set; }

        public int ComId { get; set; }
        [Required]
        public int DaysCount { get; set; }
        [Required]
        public int StartDay { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int MealCategory { get; set; }
        public List<PlanPrice> TbPlanPrices { get; set; }
        public List<PlanLines> TbPlanMasterLines { get; set; }
    }
    public class AddEditPlanHandler : IRequestHandler<AddEditPlanCommand, Result<TbPlanMasterHdr>>
    {
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<AddEditPlanHandler> _localizer;
       
        private readonly IPlanRepository _PlanRepository;


        public AddEditPlanHandler(IPlanRepository planRepository ,IMapper mapper, IStringLocalizer<AddEditPlanHandler> localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
           
            _PlanRepository = planRepository;
        }

        public async Task<Result<TbPlanMasterHdr>> Handle(AddEditPlanCommand command, CancellationToken cancellationToken)
        {
            var Plan = _mapper.Map<TbPlanMasterHdr>(command);
            if (command.Id == 0) //New Plan Implemntation
            {
               await _PlanRepository.AddAsync(Plan);
               
                return await Result<TbPlanMasterHdr>.SuccessAsync(Plan, _localizer["Plan Added Susscesfuly"]);
            }
            else  // Update Exist Plan
            {
                await _PlanRepository.UpdateAsync(Plan);
                return await Result<TbPlanMasterHdr>.SuccessAsync(Plan, _localizer["Plan Saved"]);
            }
        }
    }
}
