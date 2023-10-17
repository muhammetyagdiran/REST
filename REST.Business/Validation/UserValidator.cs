using FluentValidation;
using REST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST.Business.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Last Name is required");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required");
        }
    }
}
