﻿using entity_classes;

namespace db_helpers
{
    public interface IDBUserHelper
    {
        void DeleteUser(DesktopUser user);
        List<DesktopUser> GetAllDesktopUsers();
        List<Gender> GetAllGenders();
        DesktopUser GetDesktopUser(string username, string hashedPassword);
        Gender GetGenderById(int genderId);
        DesktopUser GetUserById(int userId);
        WebUser GetWebUser(string username, string hashedPassword);
        WebUser GetWebUserByUsername(string username);
        void InsertDesktopUser(DesktopUser newUser);
        void InsertWebUser(WebUser newUser);
        bool IsBSNTaken(int bsn);
        bool IsBsnTakenByOtherUser(DesktopUser user, int bsn);
        bool IsEmailTaken(string email);
        bool IsEmailTakenByOtherUser(int userId, string email);
        bool IsUsernameTaken(string username);
        void PromoteUserToAdmin(DesktopUser user);
        void UpdateDesktopUserDetails(DesktopUser user, string newFirstName, string newLastName, string newEmail, DateTime newBirthdate, Gender newGender, int newBSN);
        void UpdateWebUserDetails(WebUser user, string newCaption, string newEmail);
    }
}