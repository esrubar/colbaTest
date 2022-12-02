using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route ("[controller]")]
public class MemesController: ControllerBase
{
    private static readonly List<Thumbnail> _thumbnails = ThumbnailsData.Thumbnails;

    [HttpGet("{name}")]
    public IActionResult GetByName([FromRoute] string name)
    {
        var thumbnail = _thumbnails.FirstOrDefault(thumbnail => thumbnail.Name.ToLower() == name.ToLower());
        var thumbnailRoute = thumbnail.ThumbnailRoute;
        return new ObjectResult(thumbnailRoute)
        {
            StatusCode = StatusCodes.Status200OK
        };
    }
    
}