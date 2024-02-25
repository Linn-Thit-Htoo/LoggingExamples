using log4net;
using log4netExample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace log4netExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILog _logger;

        public BlogController(ILog logger)
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
            _logger.Info("Blog list => " + JsonConvert.SerializeObject(lst));
            return Ok(lst);
        }
        #endregion

        #region Test logging
        [HttpGet("testing")]
        public IActionResult TestLogging()
        {
            _logger.Debug("test logging");
            return Ok();
        }
        #endregion
    }
}
