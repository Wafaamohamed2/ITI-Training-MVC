using Microsoft.AspNetCore.Mvc;

namespace Day13.Models
{
    public class MovieStatsViewComponent : ViewComponent
    {
        private readonly IRepo<Movie> _repo;

        public MovieStatsViewComponent(IRepo<Movie> repo)
        {
            _repo = repo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movies = _repo.GetAll();
            var totalMovies = movies.Count();
            var averageYear = (int)movies.Average(m => m.Year);

            var stats = new MovieStatsViewModel
            {
                Count = totalMovies,
                AverageYear = averageYear
            };

            return View(stats);
        }
    }
}
