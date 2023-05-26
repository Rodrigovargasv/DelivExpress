using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelivExpress.Domain.Validation
{
    // Metado para validação de erro nas Entities
    public class DomainExceptionValdation : Exception
    {
        public DomainExceptionValdation(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new DomainExceptionValdation(error);
            }
        }
    }
}
