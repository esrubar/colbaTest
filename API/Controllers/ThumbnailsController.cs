using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route ("[controller]")]
public class ThumbnailsController: ControllerBase
{
    private static readonly List<Thumbnail> _thumbnails = ThumbnailsData.Thumbnails;

    [HttpGet]
    public List<Thumbnail> GetAll()
    {
        return _thumbnails;
    }

    [HttpPost]
    public Thumbnail Create([FromBody] Thumbnail thumbnail)
    {
        thumbnail.Id = Guid.NewGuid();
        _thumbnails.Add(thumbnail);
        return thumbnail;
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var thumbnail = _thumbnails.FirstOrDefault(thumbnail => thumbnail.Id == id);
        if (thumbnail is null)
        {
            return NotFound();
        }

        return new ObjectResult(thumbnail) { StatusCode = StatusCodes.Status200OK };
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var thumbnail = _thumbnails.FirstOrDefault(thumbnail => thumbnail.Id == id);
        if (thumbnail is null)
        {
            return NotFound();
        }

        _thumbnails.Remove(thumbnail);
        return NoContent();
    }

    [HttpGet("search")]
    public SearchByNamePaginationResponse SearchByName([FromQuery]SearchByNameFilter filter)
    {
        var elementsInPage = new List<Thumbnail>();
    
        var thumbnails = _thumbnails
            .Where(t => t.Name.ToLower().Contains(filter.Name.ToLower()) 
                        && t.Description.ToLower().Contains(filter.Description.ToLower())).ToList();

        for (var i = 0; i <= filter.ElementsInPageCount - 1; i++)
        {
            var element = thumbnails.ElementAtOrDefault(filter.ElementsInPageCount * (filter.Page - 1) + i);
            if (element != null) elementsInPage.Add(element);
        }
        
        /* 
        var firstElement = thumbnails.ElementAtOrDefault(2 * (filter.Page - 1));

        if (firstElement != null)
        {
            elementsInPage.Add(firstElement);
        }
        
        var secondElement = thumbnails.ElementAtOrDefault(2 * filter.Page - 1);
        
        if (secondElement != null)
        {
            elementsInPage.Add(secondElement);
        }
        */

         
        var total = (double)thumbnails.Count / filter.ElementsInPageCount;
        var totalPages = (int)Math.Ceiling(total);
        
        /*
         var elementsInPage = new List<Thumbnail>()
         {
             firstElement,
             secondElement
         };
         */

        var searchByNamePaginationResponse =
            new SearchByNamePaginationResponse(filter.Page, totalPages, filter.ElementsInPageCount, elementsInPage);

        return searchByNamePaginationResponse;
            


    }


    
}
