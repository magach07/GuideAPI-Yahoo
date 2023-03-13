using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guide.Infrastructure.Shared.Shared
{
    public abstract class BaseQuery
    {
        public string? Table { get; set; }
        public string? Query { get; set; }
        public object? Parameters { get; set; }
    }
}