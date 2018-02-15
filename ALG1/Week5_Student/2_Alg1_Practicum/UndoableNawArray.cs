using Alg1_Practicum_Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg1_Practicum
{
    public class UndoableNawArray : NawArrayOrdered
    {
        private UndoLink _currentUndoLink;
        private UndoLink _first;

        //
        // Workshop methodes
        //

        public override void Add(NAW naw)
        {
            base.Add(naw);
            AddOperation(Operation.ADD, naw);
        }

        public override bool Remove(NAW naw)
        {
            if (base.Remove(naw))
            {
                AddOperation(Operation.REMOVE, naw);
                return true;
            }
            return false;
        }

        private void AddOperation(Operation operation, NAW naw)
        {
            throw new NotImplementedException();
        }

        //
        // Huiswerk methodes
        //

        public void Undo()
        {
            throw new NotImplementedException();
        }

        public void Redo()
        {
            throw new NotImplementedException();
        }
        

        //
        // Hulp methodes, deze moet/mag je niet wijzigen of weggooien
        //

        public UndoLink First
        {
            get { return _first; }
        }

        public UndoLink Current
        {
            get { return _currentUndoLink; }
        }


        public UndoableNawArray(int size)
            : base(size)
        {
            _first = null;
            _currentUndoLink = null;
        }



    }
}
