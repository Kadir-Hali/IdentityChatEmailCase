using Microsoft.AspNetCore.Identity;

namespace IdentityChatEmailCase.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az bir tane büyük harf girişi yapınız!"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az bir tane küçük harf girişi yapınız!"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az bir tane rakam girişi yapınız!"
            };
        }


        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphaNumeric",
                Description = "Lütfen en az bir tane sembol girişi yapınız!"
            };
        }

        public override IdentityError PasswordTooShort(int lenght)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Lütfen en az {lenght} karakter uzunluğunda şifre girişi yapınız!"
            };
        }
    }
}
