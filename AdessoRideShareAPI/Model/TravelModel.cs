using System.ComponentModel.DataAnnotations;

namespace AdessoRideShareAPI.Model
{
    public class TravelModel
    {
        [Key]
        public int id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public DateTime? date { get; set; }
        public string explaining { get; set; }
        public int numberSeat { get; set; }
        public Boolean isActive { get; set; }
        public int emptyNumberSeat { get; set; }
    }
}
