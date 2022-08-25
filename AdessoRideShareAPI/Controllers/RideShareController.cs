using AdessoRideShareAPI.Model;
using AdessoRideShareAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace AdessoRideShareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideShareController : ControllerBase
    {
        private readonly IRideShareService _service;
        private readonly IDistributedCache _distributedCache;
        public RideShareController(IRideShareService service, IDistributedCache distributedCache)
        {
            _service = service;
            _distributedCache = distributedCache;
        }
        [HttpPost("InsertTravelPlan")]
        public async Task<Boolean> Insert(TravelPlanRequest request)
        {
            try
            {
                string cachedDataString = JsonSerializer.Serialize(request);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));
                await _distributedCache.SetAsync("", dataToCache, options);
                return await _service.InsertTravelPlanAsync(request);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("UpdateTravelPlan")]
        public async Task<Boolean> Update(TravelPlanUpdateRequest request)
        {
            try
            {
                string cachedDataString = JsonSerializer.Serialize(request);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));
                await _distributedCache.SetAsync(request.id.ToString(), dataToCache, options);
                return await _service.UpdateTravelPlanAsync(request);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("SelectTravelPlan")]
        public async Task<List<TravelPlanSelectResponse>> Update(TravelPlanSelectRequest request)
        {
            try
            {
                var model = _service.SelectTravelPlanAsync(request);
                string cachedDataString = JsonSerializer.Serialize(model);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));
                await _distributedCache.SetAsync("", dataToCache, options);
                return model.Result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost("UpdateNumberSeat")]
        public async Task<string> UpdateNumberSeat(TravelPlanUpdateNumberSeatRequest request)
        {
            try
            {
                string cachedDataString = JsonSerializer.Serialize(request);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                .SetSlidingExpiration(TimeSpan.FromMinutes(3));
                await _distributedCache.SetAsync(request.id.ToString(), dataToCache, options);
                return await _service.UpdateNumberSeatAsync(request);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
