using Camping.Models;
using LiteDB;
using Microsoft.EntityFrameworkCore;

namespace Camping.Data

{
    public interface DataContext
    {
       void AddSpot(Spot spot);
        IEnumerable<Spot> GetSpots ();
        ILiteCollection<User> Users { get; }
        
        User LogIn (User user);
        void UserRegestration (User user);
        IEnumerable<User> GetAllUsers ();
        User GetUserById (int id);
        void UpdateUser(int id, User user);
        void AddBooking (Booking booking);
        IEnumerable<Booking> GetBookingByUser (int userId);
       







    }
}
