using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sokoban.Presentation;
using Sokoban;


namespace Sokoban.Domain
{
    public class FloorField : BaseField
    {


        /*
        public Field moveTruck(Direction richting)
        {

            Field naarBuur = null;
            switch(richting)
            {
                case Direction.Right:
                    naarBuur = FieldToRight;
                    break;
                case Direction.Left:
                    naarBuur = FieldToLeft;
                    break;
                case Direction.Up:
                    naarBuur = FieldAbove;
                    break;
                case Direction.Down:
                    naarBuur = FieldBelow;
                    break;
                default:
                    throw new Exception_RichtingOnbekend();
            }

            if((naarBuur != null) && ((naarBuur.isVrij) || (naarBuur.heeftKrat)))
            {
                if(naarBuur.heeftKrat)
                {
                    try
                    {
                        naarBuur.moveKrat(richting);
                    }
                    catch(Exception_KanKratNietVerplaatsen)
                    {
                        throw new Exception_KanTruckNietVerplaatsen();
                    }
                    catch(Exception_RichtingOnbekend)
                    {
                        throw;
                    }
                }
                naarBuur.plaatsTruck(this.Truck);
                this.verwijderTruck();
                return naarBuur;
            }
            else
            {
                throw new Exception_KanTruckNietVerplaatsen();
            }
        }

        

        private void moveKrat(Direction r)
        {

            Field naarBuur = null;
            switch(r)
            {
                case Direction.Right:
                    naarBuur = FieldToRight;
                    break;
                case Direction.Left:
                    naarBuur = FieldToLeft;
                    break;
                case Direction.Up:
                    naarBuur = FieldAbove;
                    break;
                case Direction.Down:
                    naarBuur = FieldBelow;
                    break;
                default:
                    throw new Exception_RichtingOnbekend();
            }

            if((naarBuur != null) && (naarBuur.isVrij))
            {
                naarBuur.plaatsKrat(this.Krat);
                this.verwijderKrat();
            }
            else
            {
                throw new Exception_KanKratNietVerplaatsen();
            }
        }
        */

        public override PlacableObject Content
        {
            get; set;
        }
        override public bool IsEmpty()
        {
            return this.Content == null;
        }

        public override bool Place(PlacableObject objectToBePlaced)
        {
            if (this.IsEmpty())
            {
                this.Content = objectToBePlaced;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Remove()
        {
            this.Content = null;
        }

        public override char ToChar()
        {
            if (!this.IsEmpty())
            {
                return Content.ToChar();
            }
            else
            {
                return '.';
            }
        }
    }
}
