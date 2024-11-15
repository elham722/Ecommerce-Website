using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;


namespace ShopCenter.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }

     
    }
}
