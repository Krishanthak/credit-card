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

        private string NumberValidation(string creditCard)
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


                //ArrayList CheckNumbers = new ArrayList();

                //creditCard = creditCard.Replace(" ", "");
                //int CardLength = creditCard.Length;

                //for (int i = CardLength - 2; i >= 0; i = i - 2)
                //{
                //    CheckNumbers.Add(Int32.Parse(creditCard[i].ToString()) * 2);
                //}
                //int CheckSum = 0;
                //for (int iCount = 0; iCount <= CheckNumbers.Count - 1; iCount++)
                //{
                //    int _count = 0;
                //    if ((int)CheckNumbers[iCount] > 9)
                //    {
                //        int _numLength = ((int)CheckNumbers[iCount]).ToString().Length;
                //        for (int x = 0; x < _numLength; x++)
                //        {
                //            _count = _count + Int32.Parse(
                //                  ((int)CheckNumbers[iCount]).ToString()[x].ToString());
                //        }
                //    }
                //    else
                //    {
                //        _count = (int)CheckNumbers[iCount];
                //    }
                //    CheckSum = CheckSum + _count;
                //}
                //int OriginalSum = 0;
                //for (int y = CardLength - 1; y >= 0; y = y - 2)
                //{
                //    OriginalSum = OriginalSum + Int32.Parse(creditCard[y].ToString());
                //}

                //return (((OriginalSum + CheckSum) % 10) == 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private static string GenerateCardType(string creditCard)
        //{
        //    if ((Regex.IsMatch(creditCard, "^(34|37)"))) return CardType.Amex;
        //    else if ((Regex.IsMatch(creditCard, "^(51|52|53|54|55)"))) return "MasterCard";
        //    else if ((Regex.IsMatch(creditCard, "^(4)"))) return "Visa";
        //    else if ((Regex.IsMatch(creditCard, "^(6011)"))) return "Discover";
        //    else return "Unknown";
        //}



    }
}
