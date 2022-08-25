using AdessoRideShareAPI.Model;

namespace AdessoRideShareAPI.Services
{
    public interface IRideShareService
    {
        Task<Boolean> InsertTravelPlanAsync(TravelPlanRequest request);
        Task<Boolean> UpdateTravelPlanAsync(TravelPlanUpdateRequest request);
        Task<List<TravelPlanSelectResponse>> SelectTravelPlanAsync(TravelPlanSelectRequest request);
        Task<string> UpdateNumberSeatAsync(TravelPlanUpdateNumberSeatRequest request);
    }
}
