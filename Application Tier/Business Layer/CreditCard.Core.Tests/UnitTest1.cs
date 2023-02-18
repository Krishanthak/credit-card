using System;
using CreditCard.Common.Model.CreditCard;
using CreditCard.Core.CreditCard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCard.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Expected

            Validation expected_result1 = new Validation()
            {
                CardNumber = "4111111111111111",
                CardType = "Visa",
                Validity = "Valid"
            };

            Validation expected_result2 = new Validation()
            {
                CardNumber = "4111111111111",
                CardType = "Visa",
                Validity = "Invalid"
            };

            Validation expected_result3 = new Validation()
            {
                CardNumber = "4012888888881881",
                CardType = "Visa",
                Validity = "Valid"
            };

            Validation expected_result4 = new Validation()
            {
                CardNumber = "378282246310005",
                CardType = "Amex",
                Validity = "Valid"
            };

            Validation expected_result5 = new Validation()
            {
                CardNumber = "6011111111111117",
                CardType = "Discover",
                Validity = "Valid"
            };

            Validation expected_result6 = new Validation()
            {
                CardNumber = "5105105105105100",
                CardType = "MasterCard",
                Validity = "Valid"
            };

            Validation expected_result7 = new Validation()
            {
                CardNumber = "5105105105105106",
                CardType = "MasterCard",
                Validity = "Invalid"
            };

            Validation expected_result8 = new Validation()
            {
                CardNumber = "9111111111111111",
                CardType = "Unknown",
                Validity = "Invalid"
            };

            //Actual
            ValidationService validationService = new ValidationService();
            Validation actual_result1 = validationService.CreditCardValidation("4111111111111111");
            Validation actual_result2 = validationService.CreditCardValidation("4111111111111");
            Validation actual_result3 = validationService.CreditCardValidation("4012888888881881");
            Validation actual_result4 = validationService.CreditCardValidation("378282246310005");
            Validation actual_result5 = validationService.CreditCardValidation("6011111111111117");
            Validation actual_result6 = validationService.CreditCardValidation("5105105105105100");
            Validation actual_result7 = validationService.CreditCardValidation("5105 1051 0510 5106");
            Validation actual_result8 = validationService.CreditCardValidation("9111111111111111"); 

            Assert.AreEqual(expected_result1.CardNumber, actual_result1.CardNumber);
            Assert.AreEqual(expected_result1.CardType, actual_result1.CardType);
            Assert.AreEqual(expected_result1.Validity, actual_result1.Validity);

            Assert.AreEqual(expected_result2.CardNumber, actual_result2.CardNumber);
            Assert.AreEqual(expected_result2.CardType, actual_result2.CardType);
            Assert.AreEqual(expected_result2.Validity, actual_result2.Validity);

            Assert.AreEqual(expected_result3.CardNumber, actual_result3.CardNumber);
            Assert.AreEqual(expected_result3.CardType, actual_result3.CardType);
            Assert.AreEqual(expected_result3.Validity, actual_result3.Validity);

            Assert.AreEqual(expected_result4.CardNumber, actual_result4.CardNumber);
            Assert.AreEqual(expected_result4.CardType, actual_result4.CardType);
            Assert.AreEqual(expected_result4.Validity, actual_result4.Validity);

            Assert.AreEqual(expected_result5.CardNumber, actual_result5.CardNumber);
            Assert.AreEqual(expected_result5.CardType, actual_result5.CardType);
            Assert.AreEqual(expected_result5.Validity, actual_result5.Validity);

            Assert.AreEqual(expected_result6.CardNumber, actual_result6.CardNumber);
            Assert.AreEqual(expected_result6.CardType, actual_result6.CardType);
            Assert.AreEqual(expected_result6.Validity, actual_result6.Validity);

            Assert.AreEqual(expected_result7.CardNumber, actual_result7.CardNumber);
            Assert.AreEqual(expected_result7.CardType, actual_result7.CardType);
            Assert.AreEqual(expected_result7.Validity, actual_result7.Validity);

            Assert.AreEqual(expected_result8.CardNumber, actual_result8.CardNumber);
            Assert.AreEqual(expected_result8.CardType, actual_result8.CardType);
            Assert.AreEqual(expected_result8.Validity, actual_result8.Validity);
        }
    }
}
