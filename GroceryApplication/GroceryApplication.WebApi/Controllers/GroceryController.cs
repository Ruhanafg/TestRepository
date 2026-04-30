// using GroceryApplication.Domain.Models;
// using GroceryApplication.Service;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace GroceryApplication.WebApi.Controllers
// {
//     [Authorize]
//     [ApiController]
//     [Route("api/[controller]")]
//     public class GroceryController : ControllerBase
//     {
//         private readonly GroceryService _groceryService;

//         public GroceryController(GroceryService groceryService)
//         {
//             _groceryService = groceryService;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAll()
//         {
//             var items = await _groceryService.GetAllItems();
//             return Ok(items);
//         }

//         [HttpPost]
//         public async Task<IActionResult> AddItem(GroceryList item)
//         {
//             await _groceryService.AddItem(item);
//             return Ok("Item added");
//         }
//     }
// }