﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Views;
    public class Controller
	{
        Dice dice = new Dice();
        WordView wordView = new WordView();
        InputView inputView = new InputView();
        DotView dotView = new DotView();
        DigitView digitView = new DigitView();
        public virtual void Go()
		{
            //throw new System.NotImplementedException();
            ConsoleKeyInfo input = Console.ReadKey();
            char x = input.KeyChar;

            while (x != 's')
            {
                if (x == 'g')
                {
                    dice.Throw();
                }
            }

            inputView.ShowEnd();
		}

	}
}
