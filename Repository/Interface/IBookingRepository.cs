using Clara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository.Interface
{
    public interface IBookingRepository
    {
        void AddBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }
}
