using entity_classes;

namespace DBHelpers
{
    public interface IDBUserHelper
    {
        DesktopUser GetDesktopUser(string email, string hashedPassword);
        void InsertDesktopUser(DesktopUser desktopUser);
    }
}