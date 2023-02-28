using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperApp.Entities
{
    public interface IReadOnlyPepper
    {
        bool IsReadOnly { get; }
    }
}
