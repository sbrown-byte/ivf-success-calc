using backend.Models;

namespace backend.Services
{
    public interface ICalculateSuccessRateService
    {
        Task<double> CalculateIVFSuccessRate(UserInput input);
    }
}
