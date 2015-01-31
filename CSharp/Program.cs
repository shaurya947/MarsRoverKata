using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    class Program
    { 
        static void Main(string[] args)
        {
            Grid grid = new Grid();
            Rover rover = new Rover();

            Console.WriteLine("Landing rover at (" + rover.currentPos.X + ", " + rover.currentPos.Y + ")... landed");
            rover.assignGrid(grid);

            string input;
            Console.WriteLine("Move forward(f), move backward(b), turn left(l), turn right(r) OR exit:");
            input = Console.ReadLine();

            while(!input.Equals("exit"))
            {
                bool lastMoveSuccess = true;

                foreach (char ch in input)
                {
                    //break out of loop if encountered obstacle
                    if(lastMoveSuccess == false)
                        break;

                    //switch ignore other non valid commands
                    switch(ch)
                    {
                        case 'f':   lastMoveSuccess = rover.moveForward();
                            break;

                        case 'b':    lastMoveSuccess = rover.moveBackward();
                            break;

                        case 'l':   rover.turnLeft();
                            break;

                        case 'r':   rover.turnRight();
                            break;
                    }
                }

                rover.displayNewPosition();

                Console.WriteLine("Move forward(f), move backward(b), turn left(l), turn right(r) OR exit:");
                input = Console.ReadLine();
            }
        }
    }
}
