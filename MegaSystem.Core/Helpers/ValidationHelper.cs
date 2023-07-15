﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSystem.Core.Helpers
{
    public class ValidationHelper
    {
        internal static void ModelValidation(object model)
        {
            ValidationContext validationContext = new ValidationContext(model);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValue = Validator.TryValidateObject(model, validationContext, validationResults, true);
            if (!isValue)
            {
                throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
            }
        }
    }
}
