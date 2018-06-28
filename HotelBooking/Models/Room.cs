using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelBooking.Models
{
    public class Room
    /**
        \brief dodawanie pokoju

        \detalis dodaje informacje odnosnie pokoju
    
        \param <Name>- dodanie nazwy
        \param <ID> - dodanie numeru
        \param <Capacity> - dodanie pojemności
        \param <Bathroom> - dodanie informacji czy jest łazienka
        \param <IsAvailable> - dodanie informacji czy jest dostępny

    **/
    {
        [Display(Name = "Numer")]
        public int ID { get; set; }
        [Display(Name = "Nazwa"), StringLength(50, MinimumLength = 1)]
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