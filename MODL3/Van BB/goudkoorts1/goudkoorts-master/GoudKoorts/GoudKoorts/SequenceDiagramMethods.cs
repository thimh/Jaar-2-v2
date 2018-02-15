using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoudKoorts
{
    class SequenceDiagramMethods
    {
        Field currentField = new Rail('-');        
        Field startpoint = new StartPoint('A');


        private void move()
        {
            Cart cart = new Cart(startpoint);            
            cart.MakeMove(cart.WayToMove());
        }

        private void place()
        {
            Cart cart = new Cart(currentField);

            Field rail = new Rail('-');

            rail.Place(cart);
        }

        private void tochar()
        {
            Ship ship = new Ship(currentField);
            Cart cart = new Cart(startpoint);
     
            EmptyField emptyField = new EmptyField();
            Dock dock = new Dock();
            Rail rail = new Rail('-');
            StartPoint startpointer = new StartPoint('A');
            Storage storage = new Storage();
            Switch switchje = new Switch('S');
            Water water = new Water();

            ship.ToChar();
            cart.ToChar();

            emptyField.ToChar();
            dock.ToChar();
            rail.ToChar();
            startpointer.ToChar();
            storage.ToChar();
            switchje.ToChar();
            water.ToChar();
            
        }

       
    }
}
