using MediatR;
using Pickup.Application.Features.Customers.Dto;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Application.Models;
using Pickup.Shared.Wrapper;
using System.Threading;
using System.Threading.Tasks;

namespace Pickup.Application.Features.Customers.Queries.GetById
{
    public class GetCutomerByIdQuery : IRequest<Result<dtoCustomerRsponse>>
    {
        public int? CustomerID { get; set; }
        public string CustomerPhone { get; set; }
        public int? CustomerPlanID { get; set; }
    }
    public class GetCutomerByIdQueryHandler : IRequestHandler<GetCutomerByIdQuery, Result<dtoCustomerRsponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly IBranchRepository _branchRepository;

        public GetCutomerByIdQueryHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IBranchRepository branchRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _branchRepository = branchRepository;
        }

        public async Task<Result<dtoCustomerRsponse>> Handle(GetCutomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = new Customer();
            if (request.CustomerPlanID != null)
            {
                customer = await _customerRepository.GetCustomerByPlanID((int)request.CustomerPlanID);
            }
            if (request.CustomerID != null)
            {
                customer = await _unitOfWork.Repository<Customer>().GetInclude((int)request.CustomerID, x => x.CustomerPlans);
            }
            if (request.CustomerPhone != null)
            {
                customer = await _customerRepository.GetCustomerByPhone(request.CustomerPhone);
            }
            if (customer != null && customer.Id != 0)
            {

                dtoCustomerRsponse cust = new dtoCustomerRsponse();
                cust.Id = customer.Id;
                cust.Name = customer.Name;
                cust.Notes = customer.Notes;
                cust.Phone1 = customer.Phone1;
                cust.Phone2 = customer.Phone2;
                cust.BranchId = customer.BranchId;
                cust.BranchName = await _branchRepository.GetBranchNameById(customer.BranchId);
                cust.CustomerPlan = new System.Collections.Generic.List<dtoCustomerPlanReponse>();
                foreach (var item in customer.CustomerPlans)
                {
                    cust.CustomerPlan.Add(new dtoCustomerPlanReponse()
                    {
                        CustomerPlanID = item.Id,
                        PlanName = item.PlanName,
                        RemainingMeals = item.RemainingMealsCount,
                        RemainingSnacks = item.RemainingSnacksCount
                    });
                }
                return await Result<dtoCustomerRsponse>.SuccessAsync(cust);
            }
            else
            {
                return await Result<dtoCustomerRsponse>.FailAsync("No Customer Found!");
            }
        }
    }
}
