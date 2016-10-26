using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mymento.Common.Validation
{
    public static class ObjectValidations
    {
        public static void ArgumentShouldNotBeNull(this object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
