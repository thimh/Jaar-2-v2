using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using View;

namespace Controller
{
	public class Controller
	{        
        private InputView _inputView;
        private OutputView _outputView;
        private GameBoard _gameBoard;
        private Parser _parser;
        private Timer _gameTimer;
        private Timer _cartTimer;                
        private Timer _shipTimer;        

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
           
            InitializeTimers();
        }

      
        public void Go()
        {           
            // Nieuwe parser aanmaken
            _parser = new Parser();
            // Welkom scherm weergeven
            _outputView.showStart();
            
            // Inlezen van de map
            _gameBoard = _parser.LoadGameBoard(this);
            _gameBoard.Collision = false;

            // Gameboard updaten
            _outputView.UpdateBoard(_gameBoard);

            // Timers starten
            _gameTimer.Start();
            _cartTimer.Start();
            _shipTimer.Start();

            _gameBoard.ThrowNewShip();

            // spelen
            while (!_gameBoard.Collision)
            {
                if (_gameBoard.ChangeSwitchStands(_inputView.AskForSwitch()))
                {
                    _outputView.UpdateBoard(_gameBoard);
                } 
            }

            // Timers stoppen
            _gameTimer.Stop();
            _cartTimer.Stop();
            _shipTimer.Stop();

            // Gameover weergeven
            _outputView.showGameOver(_gameBoard);
        }

        // de gameplay timer met update carts
        private void OnTimedEventGame(object source, ElapsedEventArgs e)
        {
            // new kartje laten komen
            if (!_gameBoard.Collision)
            {
                _gameBoard.moveCarts();
                _outputView.UpdateBoard(_gameBoard);  
            }          
        }

        // de cartspawn timer
        private void OnTimedEventCart(object source, ElapsedEventArgs e)
        {
            // new kartje laten komen
            if (!_gameBoard.Collision)
            {
                _gameBoard.ThrowNewCart();
            }
        }

        private void OnTimedEventShip(object source, ElapsedEventArgs e)
        {
            // new ship laten komen
            if(_gameBoard.checkScoreShip() == 0 && _gameBoard.NumberOfItemsInShipList() == 0)
            {
                _gameBoard.ThrowNewShip();
            }
            _gameBoard.moveShip();           
        }

        public void incrementNewCartSpeed()
        {
            _cartTimer.Interval = _cartTimer.Interval - TimeSpan.FromMilliseconds(250).TotalMilliseconds;
            _gameTimer.Interval = _gameTimer.Interval - TimeSpan.FromMilliseconds(10).TotalMilliseconds;
        }

        private void InitializeTimers()
        {
            _gameTimer = new Timer();
            _gameTimer.Elapsed += new ElapsedEventHandler(OnTimedEventGame);
            _gameTimer.Interval = 1500;
   
            _cartTimer = new Timer();
            _cartTimer.Elapsed += new ElapsedEventHandler(OnTimedEventCart);
            _cartTimer.Interval = 8000;

            _shipTimer = new Timer();
            _gameTimer.Elapsed += new ElapsedEventHandler(OnTimedEventShip);
            _shipTimer.Interval = 1500;
        }        
	}
}

