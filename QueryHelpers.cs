namespace CodingTermsMinimalApi
{
    public static class QueryHelpers
    {
        public static string GetAllMovieRatings()
        {
            return "SELECT * FROM MovieRating;";
        }

        public static string InsertMovieRatings()
        {
            return @"
                INSERT INTO MovieRating (Created,CreatedBy,Modified,ModifiedBy,IsActive,Title,ReleaseDate,ImagePosterUrl,Rating) 
VALUES          (CURDATE(),'system',CURDATE(),'system',TRUE,@Title, @ReleaseDate,@ImagePosterUrl,@Rating);
            ";
        }
    }
}
