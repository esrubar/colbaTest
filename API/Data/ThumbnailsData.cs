using API.Models;

namespace API.Data;

public class ThumbnailsData
{
    
    public static readonly List<Thumbnail> Thumbnails = new()
    {
        new Thumbnail
        {
            Id = Guid.Parse("c875eadd-e4f6-441b-89aa-e15bd7e6f7ef"),
            Name = "Uwu como",
            Description = "Meme mono",
            Width = 5,
            Height = 10,
            OriginalRoute = "OriginalRoute",
            ThumbnailRoute = "ThumbnailRoute Uwu"
        },
        new Thumbnail
        {
            Id = Guid.Parse("78729ece-f4d3-4f83-b1ef-a27bb67d5141"),
            Name = "Si ya saben como me pongo para que me invitan",
            Description = "Meme borracho",
            Width = 5,
            Height = 10,
            OriginalRoute = "OriginalRoute",
            ThumbnailRoute = "ThumbnailRoute alcohol"
        },
        new Thumbnail
        {
            Id = Guid.Parse("92f74a42-2dbf-4044-921e-74cbf6ae803d"),
            Name = "Dos ratas peleando por un churro como",
            Description = "Meme callejero",
            Width = 5,
            Height = 10,
            OriginalRoute = "OriginalRoute",
            ThumbnailRoute = "ThumbnailRoute ratas"
        },
        new Thumbnail
        {
            Id = Guid.Parse("21e25e9e-d6be-41c4-adeb-ad022b037893"),
            Name = "Pepe the frog como",
            Description = "Meme anfibio",
            Width = 5,
            Height = 10,
            OriginalRoute = "OriginalRoute",
            ThumbnailRoute = "ThumbnailRoute rana"
        },
    };
}