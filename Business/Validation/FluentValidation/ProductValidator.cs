using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(3).WithMessage("Name must be longer than 3").NotNull().WithMessage("cannot be null");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0").NotNull();
        }
    }
}
