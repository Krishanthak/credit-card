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

            //Actual
            ValidationService validationService = new ValidationService();
            Validation actual_result1 = validationService.CreditCardValidation("4111111111111111");
            Validation actual_result2 = validationService.CreditCardValidation("4111111111111");

            Assert.AreEqual(expected_result1.CardType, actual_result1.CardType);
            Assert.AreEqual(expected_result1.Validity, actual_result1.Validity);
            Assert.AreEqual(expected_result2.CardType, actual_result2.CardType);
            Assert.AreEqual(expected_result2.Validity, actual_result2.Validity);
        }
    }
}
