using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Interfaces.Services.Identity;
using Pickup.Application.Models;
using Pickup.Application.Models.Identity;
using Pickup.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Branches.Queries.GetById
{
   public class GetBranchbyIdQuery : IRequest<Result<GetBranchbyIdResponse>>
    {
        public int BranchId { get; set; }
    }

    public class GetBranchbyIdQueryHandler : IRequestHandler<GetBranchbyIdQuery, Result<GetBranchbyIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService _userManager;
        private readonly IBranchRepository _branchRepository;

        public GetBranchbyIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userManager, IBranchRepository branchRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _branchRepository = branchRepository;
        }

        public async Task<Result<GetBranchbyIdResponse>> Handle(GetBranchbyIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _unitOfWork.Repository<Branch>().GetInclude(request.BranchId,x=>x.Users);
            var BranchUser = branch.Users;
            List<UsersBranchResponse> userModel = new List<UsersBranchResponse>();
            var AllUsers = await _userManager.GetAllExecptAdminAsync();
            foreach (var user in AllUsers.Data)
            {
                if (BranchUser.Any(x => x.Id == user.Id))
                {
                    userModel.Add(new UsersBranchResponse { Id = user.Id, Selected = true, UserName = user.UserName });
                }
                else
                {
                    userModel.Add(new UsersBranchResponse { Id = user.Id, Selected = false, UserName = user.UserName });
                }
            }
            var result = new GetBranchbyIdResponse() { Users = userModel };
            return await Result<GetBranchbyIdResponse>.SuccessAsync(result);
        }
    }
}
