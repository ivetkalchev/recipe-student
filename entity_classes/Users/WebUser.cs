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
            ValidateWebUser();
        }

        public string GetCaption()
        {
            return caption;
        }

        private void ValidateWebUser()
        {
            if (string.IsNullOrWhiteSpace(caption))
            {
                throw new InvalidCaptionLengthException();
            }
        }
    }
}