using CreditCard.Common.Model.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Core.API.CreditCard
{
    public interface IValidationService
    {
        Validation CreditCardValidation(string creditCard);
    }
}
