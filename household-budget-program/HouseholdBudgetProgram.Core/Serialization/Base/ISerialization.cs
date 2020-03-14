using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdBudgetProgram.Core.Serialization.Base
{
    interface ISerialization
    {
        bool Serialize(string fileName, object obj);

        object Deserialize(string fileName);
    }
}
