using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLogExample;
using NLogExample.Models;

namespace NLogExample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly ILoggerManager _logger;

    public BlogController(ILoggerManager logger)
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
        _logger.LogInfo("Blog list => " + JsonConvert.SerializeObject(lst));
        return Ok(lst);
    }

    #endregion

    #region Test logging
    [HttpGet("testing")]
    public IActionResult TestLogging()
    {
        _logger.LogDebug("test logging");
        return Ok();
    }
    #endregion
}
