using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface INawArrayOrdered : INawArray
    {
        int Find(NAW item);
        
        void RemoveAtIndex(int index);
        
        bool Update(NAW oldValue, NAW newValue);

    }

    public interface INawArrayOrdered_docent
    {
        bool Remove(NAW item);
        void UpdateAll(NAW item, NAW newValue);
    }

}
