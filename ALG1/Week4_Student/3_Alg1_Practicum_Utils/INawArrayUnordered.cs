using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface INawArrayUnordered : INawArray, INawArrayUnordered_wk1, INawArrayUnordered_wk2
    { }

    public interface INawArrayUnordered_docenten
    {
        int FindAdres(string itemAdres);

        int FindWoonplaats(string itemWoonplaats);

        int FindAdresAndWoonplaats(string itemAdres, string itemWoonplaats);

        void Show();
    }

    public interface INawArrayUnordered_wk1 
    {
        int FindNaam(string itemNaam);

        void RemoveAtIndex(int index);

        void RemoveFirstNaam(string itemNaam);

        void RemoveLastNaam(string itemNaam);

        int RemoveAllNaam(string itemNaam);
    }

    public interface INawArrayUnordered_wk2 
    {
        INawArrayOrdered ToNawArrayOrdered();

  
    }
}
