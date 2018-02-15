using Alg1_Practicum_Utils;
using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class LinkedList : ILinkedList
    {
        protected Link _first; // wijst naar eerste element in de lijst
        protected Link _last;  // wijst naar laatste element in de lijst
        protected int _length; // is gelijk aan het aantal links in de lijst 


        //
        // Workshop methodes
        //

        public void InsertHead(NAW naw)
        {
            //throw new NotImplementedException();
            if (_first != null)
            {
                Link _current = _first;
                Link _newLink = new(Link);
                _first.Naw = naw;
                _first.Next = _current;
                _length++;
            }
            else
            {
                _first.Naw = naw;
                _first.Next = null;
                _length++;
            }
        }

        public void RemoveHead()
        {
            //throw new NotImplementedException();
            if (_first != null)
            {
                Link _current =  _first;
                _first = _current.Next;
                _length--;
            }
        }

        public int CountCalculated()
        {
            //throw new NotImplementedException();
            int _lengthCalculated = 0;
            Link _current = _first;

            while (_current != null)
            {
                _current = _current.Next;
                _lengthCalculated++;
            }

            return _lengthCalculated;
        }

        public int CountStored()
        {
            return _length;
        }

        public int FindNaw(NAW naw)
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }


        //
        // Huiswerk methodes
        //

        public virtual void InsertTail(NAW naw) // <= virtual keyword niet weghalen i.v.m. testscripts
        {
            throw new NotImplementedException();
        }

        public void RemoveTail()
        {
            throw new NotImplementedException();
        }



        public void RemoveAllNaw(NAW naw)
        {
            throw new NotImplementedException();
        }

        public NAW GetNawAt(int index)
        {
            throw new NotImplementedException();
        }

        public void SetNawAt(int index, NAW naw)
        {
            throw new NotImplementedException();
        }

        public void BubbleSort()
        {
            throw new NotImplementedException();
        }       

        public BigO OrderOfBubbleSort()
        {
            return BigO.One; // Pas de returnwaarde aan naar het juiste antwoord
        }


        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public Link Head()
        {
            return _first;
        }

        public Link Tail()
        {
            return _last;
        }

    }
}
