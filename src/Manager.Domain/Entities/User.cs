using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        //Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //EF
        protected User() {}
        
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
            
            Validate();
        }
        
        //Comportamentos
        public void changeName(string name)
        {
            Name = name;
            Validate();
        }

        public void changePassword(string password)
        {
            Password = password;
            Validate();
        }

        public void changeEmail(string email)
        {
            Email = email;
            Validate();
        }        
        //AutoValidação
        public override bool Validate()
        {
           var validator = new UserValidator();
           var result = validator.Validate(this);
           
           if (!result.IsValid)
           {
               foreach (var error in result.Errors)
               {
                   _errors.Add(error.ErrorMessage);

                   throw new DomainException("Some fields are invalid", _errors);
               }                
           }
           return true;
        }
    }
}