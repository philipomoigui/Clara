using Clara.DataAccess;
using Clara.Models;
using Clara.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clara.Repository
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {

        }
        public void AddBooking(Booking booking)
        {
            Create(booking);
        }

        public void DeleteBooking(Booking booking)
        {
            Delete(booking);
        }
    }
}
