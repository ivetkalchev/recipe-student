namespace exceptions
{
    public class InvalidUserException : Exception
    {
        public InvalidUserException(string message) : base(message) { }
    }

    public class NullUserException : InvalidUserException
    {
        public NullUserException(string credentialType) : base($"The {credentialType} cannot be emprty.") { }
    }

    public class AlreadyExistUserException : InvalidUserException
    {
        public AlreadyExistUserException(string credentialType) : base($"The {credentialType} is already taken.") { }
    }

    public class InvalidBsnLengthException : InvalidUserException
    {
        public InvalidBsnLengthException() : base("The provided BSN is invalid. The BSN must be 8 or 9 digits long.") { }
    }

    public class InvalidBsnFormatException : InvalidUserException
    {
        public InvalidBsnFormatException() : base("The provided BSN is invalid. The BSN must contain only numbers.") { }
    }

    public class InvalidNameException : InvalidUserException
    {
        public InvalidNameException(string nameType) : base($"The {nameType} is invalid. The {nameType} must contain only letters.") { }
    }

    public class InvalidBirthdateException : InvalidUserException
    {
        public InvalidBirthdateException() : base("You are too young to register. The user's age must be at least 14 years old.") { }
    }

    public class InvalidPasswordFormatException : InvalidUserException
    {
        public InvalidPasswordFormatException() : base("The password you provided is not valid. The password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.") { }
    }

    public class InvalidPasswordLengthException : InvalidUserException
    {
        public InvalidPasswordLengthException() : base("The password you provided is not valid. The password must be at least 8 characters long.") { }
    }

    public class InvalidEmailException : InvalidUserException
    {
        public InvalidEmailException() : base("The email you provided is not valid.") { }
    }

    public class InvalidCaptionLengthException : InvalidUserException
    {
        public InvalidCaptionLengthException() : base("The caption you provided is too long.") { }
    }
}
