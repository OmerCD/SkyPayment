using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkyPayment.Domain.Commands;
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
        [HttpGet("GetMenus")]
        public async Task<IActionResult> GetMenus()
        {
            var getAllMenuQueries = new GetAllMenuQueries();
            var send = await _mediator.Send(getAllMenuQueries);
            return Ok(send);
        }
        [HttpGet("GetMenusByManager/{managerId}")]
        public async Task<IActionResult> GetMenusByManager(string managerId)
        {
            var getMenuByManagerIdQueries = new GetMenuByManagerIdQueries(managerId);
            var send = await _mediator.Send(getMenuByManagerIdQueries);
            return Ok(send);
        }
        [HttpGet("{restaurantId}/{menuId}")]
        public async Task<IActionResult> GetMenusById(string restaurantId,string menuId)
        {
            var getMenuByRestaurantQueries = new GetMenuByRestaurantQueries(restaurantId,menuId);
            var menuResponseModels = await _mediator.Send(getMenuByRestaurantQueries);
            return Ok(menuResponseModels);
            
            return Ok(new MenuResponseModel()
            {
                Name = "İçecekler",
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
                    },
                    new MenuItemResponse()
                    {
                        Ingredients = "Şekersiz",
                        Name = "Çay",
                        Price = 3
                    },
                    new MenuItemResponse()
                    {
                        Ingredients = "Daha Şekersiz",
                        Name = "Su",
                        Price = 2
                    },
                    new MenuItemResponse()
                    {
                        Ingredients = "Laktoz var",
                        Name = "Süt",
                        Price = 5
                    },
                    new MenuItemResponse()
                    {
                        Ingredients = "İyidir için.",
                        Name = "Soda",
                        Price = 40
                    },
                }
            });
        }
        
        [HttpGet("{restaurantId}/{menuId}/{menuItemId}")]
        public async Task<IActionResult> GetMenuDetail(string restaurantId,string menuId,string menuItemId)
        {
            var getMenuItemQueries = new GetMenuItemQueries(restaurantId, menuId, menuItemId);
            var send =await _mediator.Send(getMenuItemQueries);

            return Ok(send);
        }
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetMenuList(string restaurantId)
        {
            var getMenuListQueries = new GetMenuListQueries();
            var send =await  _mediator.Send(getMenuListQueries);
            return Ok(send);
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
        [HttpPost]
        //[Authorize(Roles = "manager")]
        public IActionResult CreateMenu([FromBody] MenuCreateModel menuCreateModel)
        {
            var menuCreateCommand = new MenuCreateCommand(menuCreateModel.Name, menuCreateModel.Items, menuCreateModel.RestaurantId,menuCreateModel.ManagerId);
            var send = _mediator.Send(menuCreateCommand);
            return Ok(send);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMenu([FromBody] MenuUpdateModel menuUpdateModel)
        {
            var menuUpdateCommand = new MenuUpdateCommand(menuUpdateModel.Name, menuUpdateModel.Items, menuUpdateModel.RestaurantId,
                menuUpdateModel.Id);
           await _mediator.Send(menuUpdateCommand);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(string id)
        {
            var menuDeleteCommand = new MenuDeleteCommand(id);
            var send = await _mediator.Send(menuDeleteCommand);
            return Ok(send);
        }
    }
}