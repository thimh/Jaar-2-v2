using Sokoban.Presentation;
using System;

namespace Sokoban.Domain
{
    public class Controller
    {
        public const int KeyCancel = -1;
        public const int KeyReset = -2;
        public const int IsMazeSolved = 1;
        public const int FirstStart = -9;
        private InputView _inputview;
        private OutputView _outputview;
        private MazeViewController _mazeViewController;
        private Maze _maze;

        public Controller()
        {
            _inputview = new InputView();
            _mazeViewController = new MazeViewController();
            _outputview = new OutputView(_mazeViewController);
        }


        public void Go()
        {
            bool proceed = true;
            int inputkey = 1;
            Parser parser = new Parser();
            int state = FirstStart;

            while (proceed)
            {
                if (state == FirstStart)
                {
                    // alleen bij start een doolhofnummer vragen
                    _outputview.ShowGameStart();
                    inputkey = _inputview.AskForMazeNumber();

                    if (inputkey == KeyCancel)
                    {
                        proceed = false;
                    }
                }

                if (proceed)
                {
                    try
                    {
                        _maze = parser.LoadMaze(inputkey);
                        _mazeViewController.MazeViewed = _maze;
                        _outputview.ShowBoardState(_maze);
                        state = RunAround();
                        if (state == IsMazeSolved)
                        {
                            _outputview.ShowMazeSolved();
                            state = FirstStart;
                        }
                        else if (state == KeyCancel)
                        {
                            state = FirstStart;
                        }
                    }
                    catch (Exception_MazeIncorrectFileFormat e)
                    {
                        string message = String.Concat("doolhof", inputkey, " bevat een fout: \n\t", e.ToString());
                        _outputview.ShowError(message);
                    }

                    catch (System.IO.FileNotFoundException e)
                    {
                        string message = String.Concat("doolhof", inputkey, " niet gevonden: \n\t", e.FileName);
                        _outputview.ShowError(message);
                    }

                    catch (System.IO.DirectoryNotFoundException e)
                    {
                        string message = String.Concat("doolhof", inputkey, " niet gevonden: \n\t", e.Message);
                        _outputview.ShowError(message);
                    }
                }

            }

        }

        private int RunAround()
        {
            bool proceed = true;
            int inputkey;
            int returnValue = 0;
            while (proceed)
            {
                inputkey = _inputview.AskForMove();
                if (inputkey == KeyCancel)
                {
                    proceed = false;
                    returnValue = KeyCancel;
                }
                else if (inputkey == KeyReset)
                {
                    proceed = false;
                    returnValue = KeyReset;
                }
                else
                {
                    Direction direction = (Direction)inputkey;
                    _maze.TheTruck.Move(direction);

                    if (_maze.IsSolved)
                    {
                        proceed = false;
                        returnValue = IsMazeSolved;
                    }

                    _outputview.ShowBoardState(_maze);
                }
            }
            return returnValue;
        }
    }
}


