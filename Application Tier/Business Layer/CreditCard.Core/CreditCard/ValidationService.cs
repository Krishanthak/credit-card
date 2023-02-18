using CreditCard.Common.Model.CreditCard;
using CreditCard.Common.Model.Enum;
using CreditCard.Core.API.CreditCard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCard.Core.CreditCard
{
    public class ValidationService : IValidationService
    {
        public ValidationService()
        {
        }

        public Validation CreditCardValidation(string creditCard)
        {
            creditCard = creditCard.Replace(" ", "");
            string cardType = Enum.GetName(typeof(CardType), CardTypeInfoService.GetCardType(creditCard));
            string validity = NumberValidation(creditCard);
            Validation returnData = new Validation()
            {
                CardNumber = creditCard,
                CardType = cardType,
                Validity = validity
            };

            return returnData;
        }

        private static string NumberValidation(string creditCard)
        {
            try
            {
                IEnumerable<char> reversedCreditCard = creditCard.Reverse();

                int sum = 0;
                foreach (var x in reversedCreditCard.Select((value, index) => new { value, index }))
                {
                    if (x.index % 2 != 0)
                    {
                        int temp = Int32.Parse(x.value.ToString()) * 2;
                        if (temp > 9)
                        {
                            sum += (temp / 10) + (temp % 10);
                        }
                        else
                        {
                            sum += temp;
                        }
                    }
                    else
                    {
                        sum += Int32.Parse(x.value.ToString());
                    }
                }
                return sum % 10 == 0 ? "Valid" : "Invalid";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
