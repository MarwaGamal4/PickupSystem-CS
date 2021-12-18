using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup.Shared.Wrapper
{
    public class CustomPagingResult<T> : Result
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
        public int TotalRecords { get; set; }
        public int TotalDeliverd { get; set; }
        public int TotalPending { get; set; }
        public int TotalNotDeliverd { get; set; }
        public CustomPagingResult(List<T> data)
        {
            Data = data;
        }
        internal CustomPagingResult(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10,int totalRecords=0 , int totalDeliverd=0,int totalPending =0,int totalNotDeliverd =0)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            TotalDeliverd = totalDeliverd;
            TotalPending = totalPending;
            TotalNotDeliverd = totalNotDeliverd;
            TotalRecords = totalRecords;
        }
        public static CustomPagingResult<T> Failure(List<string> messages)
        {
            return new CustomPagingResult<T>(false, default, messages);
        }

        public static CustomPagingResult<T> Success(List<T> data, int count, int page, int pageSize , int totalRecords , int totalDeliverd , int totalPending, int totalNotDeliverd)
        {
            return new CustomPagingResult<T>(true, data, null, count, page, pageSize , totalRecords,totalDeliverd,totalPending,totalNotDeliverd);
        }
    }
}
