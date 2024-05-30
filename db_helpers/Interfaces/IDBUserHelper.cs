using entity_classes;

namespace db_helpers
{
    public interface IDBUserHelper
    {
        DesktopUser GetDesktopUser(string email, string hashedPassword);
        void InsertDesktopUser(DesktopUser desktopUser);
    }
}