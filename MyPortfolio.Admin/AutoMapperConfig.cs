using AutoMapper;
using AutoMapper.Configuration;
using MyPortfolio.Admin.Models;
using MyPortfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolio.Admin
{
    public class AutoMapperConfig
    {
        public void Initialize()
        {
            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Post, PostViewModel>().ReverseMap();
            cfg.CreateMap<Category, CategoryViewModel>().ReverseMap();
            Mapper.Initialize(cfg);
        }
    }
}