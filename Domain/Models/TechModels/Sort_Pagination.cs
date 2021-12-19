using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Codebridge.Domain.Models.TechModels
{
    public class Sort_Pagination
    {
        public string attribute { get; set; } = "Id";
        public string order { get; set; } = "by";

        [Range(1, int.MaxValue, ErrorMessage = "pageNumber should be greater than or equal to 1")]
        public int pageNumber { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "limit should be greater than or equal to 1")]
        public int limit { get; set; } = 2;

        [Range(1, int.MaxValue, ErrorMessage = "pageSize should be greater than or equal to 1")]
        public int pageSize { get; set; } = 2;

        [BindNever]
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > limit||value < 0) ? limit : value;
            }
        }
    }
}
