using CreditCard.Common.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Common.Model.CreditCard
{
    public class CardTypeInfo
    {
        public string RegEx { get; set; }
        public int Length { get; set; }
        public CardType Type { get; set; }
    }
}
