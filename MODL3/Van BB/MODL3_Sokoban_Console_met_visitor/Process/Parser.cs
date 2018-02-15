using Sokoban;
using System;
using System.Collections.Generic;
using System.IO;


namespace Sokoban.Domain
{
    class Parser
    {
        private string _pathName = "";
        private FileStream _inputStream;
        private StreamReader _streamReader;

        private Maze _maze;

        public Maze LoadMaze(int number)
        {
            _maze = new Maze();
            _pathName = String.Concat("..\\..\\Doolhof\\doolhof", number, ".txt");

            List<BaseField> previousLine = null;
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
                        List<BaseField> currentLine;
                        currentLine = procesLine(lineString, lineCounter);
                        if (previousLine != null)
                        {
                            linkLines(previousLine, currentLine);
                        }
                        else
                        {
                            _maze.Origin = currentLine[0];
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

                return _maze;
            }
            catch(Exception_MazeIncorrectFileFormat e)
            {
                throw;
            }
            
            catch(Exception e)
            {
                throw;
            }
        }


        private List<BaseField> procesLine(string lineString, int y)
        {
            List<BaseField> fieldLine = new List<BaseField>();
            BaseField previousField = null;
            for (int x = 0; x < lineString.Length; x++)
            {
                                // nieuw Vakje object maken
                BaseField field;

                switch (lineString[x])
                {
                    case '#':
                        field = new WallField();
                        break;
                    case '@':
                    case 'o':
                    case '.':
                        field = new FloorField();
                        break;
                    case 'x':
                        field = new TargetField();
                        break;
                    case ' ':
                        field = new EmptyField();
                        break;
                    default:
                        throw new Exception_MazeIncorrectFileFormat(lineString[x]);

                }

                // koppelen met Vakje op dezelfde regel
                if (previousField != null)
                {
                    field.FieldToLeft = previousField;
                    previousField.FieldToRight = field;
                }
                previousField = field;
                fieldLine.Add(field);

                // truck toevoegen en koppelen, indien nodig
                if (lineString[x] == '@')
                {
                    Truck newTruck = new Truck(field);
                    _maze.TheTruck = newTruck;
                    ((FloorField)field).Place(newTruck);
                }

                // krat toevoegen en koppelen, indien nodig
                if (lineString[x] == 'o')
                {
                    Crate newCrate = new Crate(field);
                    _maze.AddCrate(newCrate);
                    ((FloorField)field).Place(newCrate);
                }

            }
            return fieldLine;
        }



        private void linkLines(List<BaseField> previousLine, List<BaseField> currentLine)
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
                _maze.Width = x;
                _maze.Height = y;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
