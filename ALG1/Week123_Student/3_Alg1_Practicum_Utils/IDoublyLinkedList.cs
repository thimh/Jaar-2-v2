using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum_Utils
{
    public interface IDoublyLinkedList
    {
        void InsertHead(NAW naw);

        void InsertTail(NAW naw);

        void Show();
    }
}