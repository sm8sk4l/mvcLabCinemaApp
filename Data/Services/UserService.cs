using KinoProject.Models;

namespace KinoProject.Data.Services
{
    public class UserService
    {
        public static bool ValidateUser(User user)
        {
            if (user == null)
                return false;
            if (user.Name == null || user.Name == "")
                return false;
            if (user.Mail == null || user.Mail == "")
                return false;
            if (user.Password == null || user.Password == "")
                return false;

            return true;
        }
    }
}
