using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using SerilogExample.Models;

namespace SerilogExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        #region Get blogs
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogDataModel> lst = new()
            {
                new BlogDataModel
                {
                    BlogId = Guid.NewGuid(),
                    BlogTitle = "Blog 1",
                    BlogAuthor = "Author",
                    BlogContent = "Content"
                },
                new BlogDataModel
                {
                    BlogId = Guid.NewGuid(),
                    BlogTitle = "Blog 2",
                    BlogAuthor = "Author",
                    BlogContent = "Content"
                },
                 new BlogDataModel
                {
                    BlogId = Guid.NewGuid(),
                    BlogTitle = "Blog 3",
                    BlogAuthor = "Author",
                    BlogContent = "Content"
                }
            };
            _logger.LogInformation("Blog list => " + JsonConvert.SerializeObject(lst));
            return Ok(lst);
        }
        #endregion

        #region Test logging
        [HttpGet("testing")]
        public IActionResult TestLogging()
        {
            Log.Debug("test logging");
            return Ok();
        }
        #endregion
    }
}
