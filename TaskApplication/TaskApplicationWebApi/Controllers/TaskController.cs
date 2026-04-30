using Microsoft.AspNetCore.Mvc;
using TaskApp.Service;
using Microsoft.AspNetCore.Authorization;


namespace TaskApplicationWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService inTaskService;

        public TaskController(TaskService _taskService)
        {
            inTaskService = _taskService;
        }

        [HttpGet("gettask")]
        public IActionResult GetTaskList()
        {
            return Ok(inTaskService.GetTasksInPage(0, 10));
        }
    }
}