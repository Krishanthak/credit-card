using CreditCard.Common.Ioc;
using CreditCard.Core.API.CreditCard;
using CreditCard.Core.CreditCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditCard.Core.Service.Controllers
{
    public class ValidationController : ApiController
    {
        private readonly IValidationService _validationService;

        public ValidationController()
        {
            _validationService = IocContainer.Resolve<IValidationService>();
        }

        [Route("api/validateCreditCard/{creditCard}")]
        [HttpGet]
        public IHttpActionResult ValidateCreditCard(string creditCard)
        {
            try
            {
                var result = _validationService.CreditCardValidation(creditCard);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return this.InternalServerError();
        }
    }
}
