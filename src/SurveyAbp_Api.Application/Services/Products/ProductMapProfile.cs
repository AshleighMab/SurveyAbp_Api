﻿
using AutoMapper;
using SurveyAbp_Api.Domain;
using SurveyAbp_Api.Services.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAbp_Api.Services.Products
{
    public class ProductMapProfile :Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();
        }
      
            
    }
}
