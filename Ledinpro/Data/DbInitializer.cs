using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Ledinpro.Models;

namespace Ledinpro.Data
{
    public static class DbInitializer
    {
        public static void Initializer(LedinproContext context)
        {
            context.Database.EnsureCreated();

            // 判断是否有轮播图
            if (context.Carousels.Any())
            {
                return;
            }

            var carousel = new Carousel()
            {
                Name = "轮播图1",
                Title = "轮播图1 标题",
                Description = "轮播图1 描述",
                PicturePath = "PicturePath",
                CreateUserName = "开发者",
                CreateDateTime = DateTime.Now,
                LastEditUserName = "开发者",
                LastEditDateTime = DateTime.Now
            };

            context.Carousels.Add(carousel);

            context.SaveChanges();
        }
    }
}
