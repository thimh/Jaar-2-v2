using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
	public class GameBoard
	{
        private Controller.Controller controller;
        private List<Cart> cartList;
        private List<Ship> shipList;
        private bool _collision;
        private int _totalScore = 0;

        public GameBoard(Controller.Controller controller)
        {
            cartList = new List<Cart>();
            shipList = new List<Ship>();
            this.controller = controller;
        }

		public virtual IEnumerable<Field> Field
		{
			get;
			set;
		}

        public Field Origin
        {
            get;
            set;
        }

        public Field PointA
        {
            get;
            set;
        }

        public Field PointB
        {
            get;
            set;
        }

        public Field PointC
        {
            get;
            set;
        }

        public Switch switch1
        {
            get;
            set;
        }

        public Switch switch2
        {
            get;
            set;
        }
        public Switch switch3
        {
            get;
            set;
        }

        public Switch switch4
        {
            get;
            set;
        }
        public Switch switch5
        {
            get;
            set;
        }

        public Water ShipStart
        {
            get;
            set;
        }

        public Water ShipEnd
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public bool Collision
        {
            get
            {
                return _collision;
            }
            set
            {
                _collision = value;
            }
        }

        public int TotalScore
        {
            get
            {
                return _totalScore;
            }
            set
            {
                _totalScore = value;
                controller.incrementNewCartSpeed();
            }
        }


        public bool ChangeSwitchStands(int switchNumber)
        {
            switch (switchNumber)
            {
                case 1:
                    switch1.ChangeSwitchState();
                    return true;              
                case 2:
                    switch2.ChangeSwitchState();
                    return true;
                case 3:
                    switch3.ChangeSwitchState();
                    return true;
                case 4:
                    switch4.ChangeSwitchState();
                    return true;
                case 5:
                    switch5.ChangeSwitchState();                    
                    return true;
            }
            return false;
        }    

        public void ThrowNewCart()
        {
            Field newStartField = generateStartField();
            Cart newCart = new Cart(newStartField);
            cartList.Add(newCart);
            newStartField.Place(newCart);
        }

        public void ThrowNewShip()
        {
            Ship newShip = new Ship(ShipStart);
            shipList.Add(newShip);
            ShipStart.Place(newShip);
        }

        public void moveShip()
        {
            foreach (Ship ship in shipList.ToList())
            {
                Direction richting = ship.WayToMove();
                if (richting != Direction.nulldirection)
                    if(richting.Equals(Direction.Remove))
                    {
                        shipList.Remove(ship);
                        ShipEnd.ToChar1 = '█';
                        Water field1 = (Water)ShipEnd.FieldToRight;
                        field1.ToChar1 = '█';
                        field1.Remove();
                        Water field2 = (Water)ShipEnd.FieldToRight.FieldToRight;
                        field2.ToChar1 = '█';
                        field2.Remove();
                        Water field3 = (Water)ShipEnd.FieldToRight.FieldToRight.FieldToRight;
                        field3.ToChar1 = '█';
                        field3.Remove();
                        TotalScore += 10;
                    }
                    else
                        ship.MakeMove(richting);
            }
        }

        public int checkScoreShip()
        {
            if(shipList.Count != 0)
                return shipList.First().CountOfLoads;

            return 0;
        }

        public int NumberOfItemsInShipList()
        {
            return shipList.Count;
        }
        public void moveCarts()
        {
            foreach (Cart cart in cartList.ToList())
            {
                if (cart.checkGameOver())
                    Collision = true;

                Direction richting = cart.WayToMove();
                if (richting != Direction.nulldirection)
                    if (richting == Direction.Remove)
                    {
                        cartList.Remove(cart);
                        ShipEnd.FieldBelow.FieldBelow.Remove();
                    }
                    else
                        cart.MakeMove(richting);

                if (cart.checkScore())
                {
                    if (shipList.Count != 0)
                    {
                        shipList.First().CountOfLoads++;
                        TotalScore++;
                    }
                }                                   
            }
        }

        private Field generateStartField()
        {
            List<Field> startPointList = new List<Field>();
            startPointList.Add(PointA);
            startPointList.Add(PointB);
            startPointList.Add(PointC);
            Random rnd = new Random();
            int r = rnd.Next(startPointList.Count);
            return (Field)startPointList[r];
        }
	}
}

