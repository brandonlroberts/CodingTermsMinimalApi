using CodingTermsMinimalApi.Models.Base;

namespace CodingTermsMinimalApi.Models
{
    public class MovieRating : BaseEntity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePosterUrl { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
