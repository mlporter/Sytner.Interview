using Synter.InterviewApi.Domain.DataModels;
using Synter.InterviewApi.Infrastructure.Repositories.Interfaces;

namespace Synter.InterviewApi.Infrastructure.Repositories
{
    public class WeatherStationRepository : IWeatherStationRepository
    {
        private readonly ApiDbContext _dbContext;

        public WeatherStationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(WeatherStation weatherStation)
        {
            _dbContext.WeatherStation.Add(weatherStation);
            _dbContext.SaveChanges();
        }
    }
}
