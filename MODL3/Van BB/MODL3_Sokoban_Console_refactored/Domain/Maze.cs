using System;
using System.Collections.Generic;

namespace Sokoban.Domain
{
    public class Maze
    {
        private List<Crate> _crates = new List<Crate>();

        public bool IsSolved
        {
            get
            {
                int numberOfCrates = _crates.Count;
                int numberOfCratesOnTarget = 0;
                foreach(Crate crate in _crates)
                {   
                    if (crate.IsOnTarget())
                    {
                        numberOfCratesOnTarget++;
                    }
                }
                return (numberOfCrates == numberOfCratesOnTarget);
            }
        }

        public BaseField Origin
        {
            get;
            set;
        }

        public Truck TheTruck
        {
            set;
            get;
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

        public void AddCrate(Crate k)
        {
            if(k != null)
            {
                _crates.Add(k);
            }
            else
            {
                throw new ArgumentNullException("crate");
            }
        }

        public void moveTruck(Direction r)
        {
            TheTruck.Move(r);
        }
    }

}
