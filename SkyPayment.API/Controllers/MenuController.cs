using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Domain.Queries.MenuQueries;
using SkyPayment.Shared;

namespace SkyPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MenuController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult GetMenus()
        {
            var getAllMenuQueries = new GetAllMenuQueries();
            var send = _mediator.Send(getAllMenuQueries);
            return Ok(send);
        }
        [HttpGet("{restaurantId}/{menuId}")]
        public IActionResult GetMenusTest(string restaurantId,string menuId)
        {
            return Ok(new MenuResponseModel()
            {
                Name = "Icecekler",
                Items = new List<MenuItemResponse>()
                {
                    new MenuItemResponse()
                    {
                        Ingredients = "Birseyler",
                        Name = "Limonata",
                        Price = 20,
                        ProductContent = ProductContent.IsVegetarian
                    },
                    new MenuItemResponse()
                    {
                        Ingredients = "BaskaBirseyle",
                        Name = "mMilkshake",
                        Price = 23,
                        ProductContent = ProductContent.IsDiabetic
                    },
                    new MenuItemResponse()
                    {
                        Ingredients = "Glikoz surubu",
                        Name = "Latte",
                        Price = 40
                    }, new MenuItemResponse()
                    {
                        Ingredients = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        Name = "Coffee",
                        Price = 50
                    }
                }
            });
        }
        [HttpGet("{restaurantId}")]
        public IActionResult GetMenuList(string restaurantId)
        {
            return Ok(new List<MenuListResponse>()
            {
                new MenuListResponse()
                {
                    Id = 1,
                    Name = "Sicaklar"
                },
                new MenuListResponse()
                {
                    Id = 2, Name = "Icecekler"
                }
            });
        }
    }
}