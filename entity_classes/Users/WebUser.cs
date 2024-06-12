using exceptions;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace entity_classes
{
    public class WebUser : User
    {
        private string caption;

        public WebUser(int idUser, string username, string email, string password, string caption)
            : base(idUser, username, email, password)
        {
            Caption = caption;
        }

        public string Caption
        {
            get { return Caption; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullUserException(nameof(Caption));

                if (caption.Length > 400)
                    throw new InvalidCaptionLengthException();

            caption = value; }}
        }
    }