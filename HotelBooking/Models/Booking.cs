using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelBooking.Models
{
    public class Booking
    {
        [Display(Name = "Numer")]
        public int ID { get; set; }
        [Display(Name = "Zaliczka"), DataType(DataType.Currency)]
        public decimal Advance { get; set; }
        [Display(Name = "Data przyjazdu"), DataType(DataType.DateTime)]
        public string StartDate { get; set; }

        [Display(Name = "Data wyjazdu"), DataType(DataType.DateTime)]
        public string EndDate { get; set; }
        public int SelectedRoomId { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

    }
}