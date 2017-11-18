using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AppLaMejor.controlmanager
{
    public static class Validator
    {
        // This could return a ValidationResult object etc
        public static IEnumerable<string> Validate(object o)
        {
            Type type = o.GetType();
            PropertyInfo[] properties = type.GetProperties();
            Type attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in properties)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);

                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;

                    bool isValid = validationAttribute.IsValid(propertyInfo.GetValue(o, BindingFlags.GetProperty, null, null, null));

                    if (!isValid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }

}
