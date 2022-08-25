using AdessoRideShareAPI.Context;
using AdessoRideShareAPI.Model;

namespace AdessoRideShareAPI.Services
{
    public class RideShareService : IRideShareService
    {
        private readonly RideShareDbContext db;
        public RideShareService(RideShareDbContext db)
        {
            this.db = db;
        }
        public async Task<Boolean> InsertTravelPlanAsync(TravelPlanRequest request)
        {
            try
            {
                db.Add(new TravelModel()
                {
                    from = request.from,
                    to = request.to,
                    date = request.date,
                    explaining = request.explaining,
                    numberSeat = request.numberSeat,
                    emptyNumberSeat = request.numberSeat,
                    isActive = true
                });
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Boolean> UpdateTravelPlanAsync(TravelPlanUpdateRequest request)
        {
            try
            {
                var model = db.travel.FirstOrDefault(b => b.id == request.id);
                model.isActive = request.isActive;
                db.travel.Update(model);
                db.SaveChanges();
                return true;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        public async Task<List<TravelPlanSelectResponse>> SelectTravelPlanAsync(TravelPlanSelectRequest request)
        {
            try
            {
                var model = db.travel.Where(b => b.from == request.from && b.to == request.to && b.isActive == true).ToList();
                List<TravelPlanSelectResponse> response = new List<TravelPlanSelectResponse>();
                for (int i = 0; i < model.Count; i++)
                {
                    response.Add(new TravelPlanSelectResponse()
                    {
                        from = model[i].from,
                        to = model[i].to,
                        date = model[i].date,
                        explaining = model[i].explaining,
                        numberSeat = model[i].numberSeat,
                        isActive = model[i].isActive,
                        emptyNumberSeat = model[i].emptyNumberSeat,
                    });
                }
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> UpdateNumberSeatAsync(TravelPlanUpdateNumberSeatRequest request)
        {
            string OutMessage = "";
            try
            {
                var model = db.travel.FirstOrDefault(b => b.id == request.id && b.isActive == true);
                if (model.emptyNumberSeat - request.numberSeat < 0)
                {
                    return OutMessage = "Maximum " + model.emptyNumberSeat + " boş koltuk bulunmaktadır!";
                }
                model.emptyNumberSeat = model.emptyNumberSeat - request.numberSeat;
                db.travel.Update(model);
                db.SaveChanges();
                return OutMessage = "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                return OutMessage = ex.Message;
            }
        }
    }
}
