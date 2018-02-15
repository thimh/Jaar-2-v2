using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Model;
using Exceptions;

namespace Controller
{
	public class Parser
	{
        private string _pathName = "";
        private FileStream _inputStream;
        private StreamReader _streamReader;
        private GameBoard _gameBoard;       
        private Controller _controller;

        public Model.GameBoard GameBoard
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public GameBoard LoadGameBoard(Controller _controller)
        {
            this._controller = _controller;
            _gameBoard = new GameBoard(_controller);
            _pathName = String.Concat("..\\..\\GameBoard\\GameBoard", ".txt");      
            
            List<Field> previousLine = null;
            int lineCounter = 0;
            try
            {
                detectDimensions();
                _inputStream = new FileStream(_pathName, FileMode.Open, FileAccess.Read);
                _streamReader = new StreamReader(_inputStream); 
                string lineString = _streamReader.ReadLine();
                do
                {
                    if (lineString != null)
                    {
                        List<Field> currentLine;
                        currentLine = procesLine(lineString, lineCounter);
                        if (previousLine != null)
                        {
                            linkLines(previousLine, currentLine);
                        }
                        else
                        {
                            _gameBoard.Origin = currentLine[0];
                        }
                        previousLine = currentLine;
                        lineCounter++;
                        lineString = _streamReader.ReadLine();
                    }
                    else
                    {
                        _streamReader.Close();
                        _inputStream.Close();
                    }
                }
                while (lineString != null);

                return _gameBoard;
            } 
            catch (Exception_GameBoardIncorrectFileFormat e)
            {
                throw;
            }
            
            catch(Exception e)
            {
                throw;
            }
        }

        private List<Field> procesLine(string lineString, int y)
        {
            List<Field> fieldLine = new List<Field>();
            Field previousField = null;
            for (int x = 0; x < lineString.Length; x++)
            {
                // nieuw Vakje object maken
                Field field;

                switch (lineString[x])
                {
                    case 'W':
                        field = new Water();
                        break;
                    case 'D':
                        field = new Dock();
                        break;
                    case 'R':
                        field = new Rail('-');
                        break;
                    case '/':
                        field = new Rail('/');
                        break;
                    case '\\':
                        field = new Rail('\\');
                        break;
                    case 'U':
                        field = new Rail('|');
                        break;
                    case '1':
                        field = new Switch('S');
                        _gameBoard.switch1 = (Switch)field;
                        _gameBoard.switch1.SwitchDirection = SwitchDirection.MIDDLE;
                        break;
                    case '2':
                        field = new Switch('S');
                        _gameBoard.switch2 = (Switch)field;
                        _gameBoard.switch2.SwitchDirection = SwitchDirection.MIDDLE;
                        break;
                    case '3':
                        field = new Switch('S');
                        _gameBoard.switch3 = (Switch)field;
                        _gameBoard.switch3.SwitchDirection = SwitchDirection.MIDDLE;
                        break;
                    case '4':
                        field = new Switch('S');
                        _gameBoard.switch4 = (Switch)field;
                        _gameBoard.switch4.SwitchDirection = SwitchDirection.MIDDLE;
                        break;
                    case '5':
                        field = new Switch('S');
                        _gameBoard.switch5 = (Switch)field;
                        _gameBoard.switch5.SwitchDirection = SwitchDirection.MIDDLE;
                        break;
                    case '8':
                        field = new Water();
                        _gameBoard.ShipEnd = (Water)field;
                        break;
                    case '9':
                        field = new Water();
                        _gameBoard.ShipStart = (Water)field;
                        break;
                    case 'A':
                        field = new StartPoint('A');
                        _gameBoard.PointA = field;
                        break;
                    case 'B':
                        field = new StartPoint('B');
                        _gameBoard.PointB = field;
                        break;
                    case 'C':
                        field = new StartPoint('C');
                        _gameBoard.PointC = field;
                        break;
                    case 'O':
                        field = new Storage();
                        break;                
                    case '.':
                        field = new EmptyField();
                        break;
                    default:
                        throw new Exception_GameBoardIncorrectFileFormat(lineString[x]);
                }

                // koppelen met Vakje op dezelfde regel
                if (previousField != null)
                {
                    field.FieldToLeft = previousField;
                    previousField.FieldToRight = field;
                }
                previousField = field;
                fieldLine.Add(field);
            }
            return fieldLine;
        }

        private void linkLines(List<Field> previousLine, List<Field> currentLine)
        {
            for (int n = 0; n < currentLine.Count; n++)
            {
                // als een van de twee null is, dan hoeft er geen link gemaakt te worden.
                if ((previousLine[n] != null) && (currentLine[n] != null))
                {
                    currentLine[n].FieldAbove = previousLine[n];
                    previousLine[n].FieldBelow = currentLine[n];
                }
            }
        }
        
        private void detectDimensions()
        {
            _inputStream = new FileStream(_pathName, FileMode.Open, FileAccess.Read);
            _streamReader = new StreamReader(_inputStream);
            int x = 0;
            int y = 0;

            try
            {
                string lineString = _streamReader.ReadLine();
                do
                {
                    if (lineString != null)
                    {
                        if (lineString.Length > x)
                        {
                            x = lineString.Length;
                        }
                        y++;
                        lineString = _streamReader.ReadLine();
                    }
                    else
                    {
                        _streamReader.Close();
                        _inputStream.Close();
                    }
                }
                while (lineString != null);
                _gameBoard.Width = x;
                _gameBoard.Height = y;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

