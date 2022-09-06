using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Project.Validators
{
    public class IsDateTimeValid : ValidationAttribute, IClientValidatable
    {
        // This Interface must be implemented if we want validation on client side as well.
        // Additionally some jquery code must be added, that's why I put the datetimevalidation.js script.
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("now", DateTime.Now);
            rule.ValidationType = "datetime";
            yield return rule;
        }

        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            if (dateTime == null)
            {
                return false;
            }

            return dateTime >= DateTime.Now;
        }
    }
}