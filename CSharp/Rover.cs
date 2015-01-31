using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    //enumerable type to specify direction
    enum Direction { N, S, E, W};

    class Rover
    {
        //properties of Rover
        public Point currentPos { get; private set; }
        public Direction currentDir { get; private set; }

        private Grid grid;     //current grid rover is in

        //constructor that takes initial position and direction
        public Rover(int startingX = 0, int startingY = 0, Direction startingDir = Direction.N)
        {
            currentPos = new Point(startingX, startingY);
            currentDir = startingDir;
        }

        //method to assign grid to rover
        public void assignGrid(Grid grid)
        {
            this.grid = grid;

            if (grid.obstacles.Contains(currentPos))
            {
                Console.Write("Grid has obstacle at rover starting position. Landed rover at ");
                //verify that current position of rover is not an obstacle
                while (grid.obstacles.Contains(currentPos))
                    moveForward();

                Console.Write("(" + currentPos.X + ", " + currentPos.Y + ") instead\n");
            }
        }

        //method to move rover one step forward
        //displays error (and return false) if obstalce lies ahead
        public bool moveForward()
        {
            switch(currentDir)
            {
                case Direction.N: incrementY();
                    break;

                case Direction.S: decrementY();
                    break;

                case Direction.E: incrementX();
                    break;

                case Direction.W: decrementX();
                    break;
            }

            //if new current position has obstacle, move back and report it
            if(grid.obstacles.Contains(currentPos))
            {
                Console.WriteLine("Cannot move forward. Obstacle present ahead at (" + currentPos.X + ", " + currentPos.Y + ")");
                moveBackward();
                return false;
            }

            return true;
        }

        //method to move rover one step backward
        //displays error (and return false) if obstalce lies behind
        public bool moveBackward()
        {
            switch (currentDir)
            {
                case Direction.N: decrementY();
                    break;

                case Direction.S: incrementY();
                    break;

                case Direction.E: decrementX();
                    break;

                case Direction.W: incrementX();
                    break;
            }

            //if new current position has obstacle, move back and report it
            if (grid.obstacles.Contains(currentPos))
            {
                Console.WriteLine("Cannot move backward. Obstacle present behind at (" + currentPos.X + ", " + currentPos.Y + ")");
                moveForward();
                return false;
            }

            return true;
        }

        //method to turn rover to the left
        public void turnLeft()
        {
            switch (currentDir)
            {
                case Direction.N: currentDir = Direction.W;
                    break;

                case Direction.S: currentDir = Direction.E;
                    break;

                case Direction.E: currentDir = Direction.N;
                    break;

                case Direction.W: currentDir = Direction.S;
                    break;
            }
        }

        //method to turn rover to the right
        public void turnRight()
        {
            switch (currentDir)
            {
                case Direction.N: currentDir = Direction.E;
                    break;

                case Direction.S: currentDir = Direction.W;
                    break;

                case Direction.E: currentDir = Direction.S;
                    break;

                case Direction.W: currentDir = Direction.N;
                    break;
            }
        }

        //method to increment rover's x position (with wrap around)
        private void incrementX()
        {
            int newX = currentPos.X + 1;

            if (newX > grid.maxX)
                newX = grid.minX;

            currentPos = new Point(newX, currentPos.Y);
        }

        //method to decrement rover's x position (with wrap around)
        private void decrementX()
        {
            int newX = currentPos.X - 1;

            if (newX < grid.minX)
                newX = grid.maxX;

            currentPos = new Point(newX, currentPos.Y);
        }

        //method to increment rover's y position (with wrap around)
        private void incrementY()
        {
            int newY = currentPos.Y + 1;

            if (newY > grid.maxY)
                newY = grid.minY;

            currentPos = new Point(currentPos.X, newY);
        }

        //method to decrement rover's y position (with wrap around)
        private void decrementY()
        {
            int newY = currentPos.Y - 1;

            if (newY < grid.minY)
                newY = grid.maxY;

            currentPos = new Point(currentPos.X, newY);
        }

        //method to display new rover position and direction
        public void displayNewPosition()
        {
            Console.Write("New rover position is (" + currentPos.X + ", " + currentPos.Y + ") facing ");

            switch(currentDir)
            {
                case Direction.N: Console.Write("North.\n");
                    break;

                case Direction.S: Console.Write("South.\n");
                    break;

                case Direction.E: Console.Write("East.\n");
                    break;

                case Direction.W: Console.Write("West.\n");
                    break;
            }
        }
    }
}
