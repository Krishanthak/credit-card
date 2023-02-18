using CreditCard.Common.Model.CreditCard;
using CreditCard.Common.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreditCard.Core.CreditCard
{
    public class CardTypeInfoService
    {
        public static CardType GetCardType(string creditCard)
        {
            List<CardTypeInfo> listCardTypeInfo = ListCardTypeInfo();
            foreach (CardTypeInfo info in listCardTypeInfo)
            {
                if (creditCard.Length == info.Length &&
                    Regex.IsMatch(creditCard, info.RegEx))
                    return info.Type;
            }

            return CardType.Unknown;
        }

        private static List<CardTypeInfo> ListCardTypeInfo()
        {
            return new List<CardTypeInfo>(){
                new CardTypeInfo() { RegEx="^(34|37)", Length = 15, Type = CardType.Amex },
                new CardTypeInfo() { RegEx="^(6011)", Length = 16, Type = CardType.Discover },
                new CardTypeInfo() { RegEx = "^(51|52|53|54|55)", Length = 16, Type = CardType.MasterCard },
                new CardTypeInfo() { RegEx="^(4)", Length = 16, Type = CardType.Visa  },
                new CardTypeInfo() { RegEx="^(4)", Length = 13, Type = CardType.Visa }
            };
        }
    }
}
