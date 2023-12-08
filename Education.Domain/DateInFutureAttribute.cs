using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain
{
    public class DateInFutureAttribute : ValidationAttribute
    {
        private readonly Func<DateTime> _datetimeNowProvider;

        public DateInFutureAttribute(): this(()=> DateTime.Now)
        {   }

        public DateInFutureAttribute(Func<DateTime> datetimeNowProvider)
        {
            _datetimeNowProvider = datetimeNowProvider;
            ErrorMessage = "La Fecha debe ser del Futuro";
        }

        public override bool IsValid(object? value)
        {
            bool isValid = false;
            if (value is DateTime dateTime)
            {
                isValid = dateTime > _datetimeNowProvider();
            }
            return isValid;
        }
    }
}
