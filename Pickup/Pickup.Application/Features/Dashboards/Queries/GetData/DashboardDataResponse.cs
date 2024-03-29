﻿using System.Collections.Generic;

namespace Pickup.Application.Features.Dashboards.Queries.GetData
{
    public class DashboardDataResponse
    {
        public int ProductCount { get; set; }
        public int BrandCount { get; set; }
        public int UserCount { get; set; }
        public int RoleCount { get; set; }
        public int BranchesCount { get; set; }
        public int CustomersCount { get; set; }
        public List<ChartSeries> DataEnterBarChart { get; set; } = new List<ChartSeries>();
        public Dictionary<string, double> ProductByBrandTypePieChart { get; set; }
    }

    public class ChartSeries
    {
        public ChartSeries() { }

        public string Name { get; set; }
        public double[] Data { get; set; }
    }

}