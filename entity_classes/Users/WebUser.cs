﻿using exceptions;

namespace entity_classes
{
    public class WebUser : User
    {
        private string caption;

        public WebUser(int idUser, string username, string email, string password, string caption)
            : base(idUser, username, email, password)
        {
            this.caption = caption;
        }

        public string GetCaption()
        {
            return caption;
        }
    }
}