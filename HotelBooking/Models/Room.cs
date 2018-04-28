using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Room
    {
        [Display(Name = "Numer")]
        public int ID { get; set; }
        [Display(Name = "Nazwa"), StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Ilość miejsc"), Range(1, 10)]
        public string Capacity { get; set; }
        [Display(Name = "Łazienka")]
        public bool Bathroom { get; set; }
        [Display(Name = "Dostępność")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Cena"), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public virtual Booking Booking { get; set; }
    }
}