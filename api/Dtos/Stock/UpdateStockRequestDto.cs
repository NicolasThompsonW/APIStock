using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class UpdateStockRequestDto
    {

        [MaxLength(10, ErrorMessage = "Symbol must be at most 10 character")]
        public string Symbol { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Company Name must be at most 50 character")]
        public string CompanyName { get; set; } = string.Empty;

        [Range(0, 1000000000)]
        public decimal Price { get; set; }

        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [MaxLength(10, ErrorMessage = "Sector must be at most 10 character")]
        public string Industry { get; set; } = string.Empty;

        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}