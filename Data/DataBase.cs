using Camping.Models;
using LiteDB;
namespace Camping.Data
{
    public class DataBase : DataContext
    {
        LiteDatabase db = new LiteDatabase("data.db");
        const string spots = "Spots";
        const string users = "users";
        public void AddSpot (Spot spot)
        {
            db.GetCollection<Spot>(spots).Insert(spot);
        }
        public IEnumerable<Spot> GetSpots ()
        {
            return db.GetCollection<Spot>(spots).FindAll();
        }

        public ILiteCollection<User> Users { get { return db.GetCollection<User>(users); } }

        public User LogIn (User user)
        {
            var query = Users.Find(Query.EQ("Email", user.Email));
            var find = query.FirstOrDefault();
            if (find != null && find.Password == user.Password)
            {
                return find;
            }
            return null;
        }
        public void UserRegestration (User user)
        {
            Users.Insert(user);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return Users.FindAll();
        }
        public User GetUserById(int id)
        {
            return Users.FindOne(e_user=>e_user.userId == id);
        }
        public void UpdateUser(int id,User user)
        {
            Users.Update(id,user);
        }

        public void AddBooking(Booking booking)
        {
            db.GetCollection<Booking>("bookings").Insert(booking);
        }
        public IEnumerable<Booking> GetBookingByUser(int userId)
        {
            return db.GetCollection<Booking>("bookings").Find(e_booking => e_booking.UserId == userId);
        }


    }
}
