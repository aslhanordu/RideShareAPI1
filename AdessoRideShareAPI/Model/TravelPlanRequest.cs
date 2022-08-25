namespace AdessoRideShareAPI.Model
{
    public class TravelPlanRequest
    {
        public string from { get; set; }
        public string to { get; set; }
        public DateTime? date { get; set; }
        public string explaining { get; set; }
        public int numberSeat { get; set; }
    }
}
