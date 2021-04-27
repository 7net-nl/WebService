using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.Service.ApplicationService.Common
{
    public class TokenValidator<TEntity> : AbstractValidator<TEntity> where TEntity : IToken
    {
        public TokenValidator()
        {
          RuleFor(c => c.Token).NotEmpty().NotNull().Must(TokenGen).WithMessage("Autentication Erorr");
        }

        private bool TokenGen(string arg)
        {
            return TokenDecoder.DeGen(arg);
        }
    }
}
