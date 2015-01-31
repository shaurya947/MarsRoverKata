using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    class Grid
    {         
        //properties of grid
        public int maxX { get; private set; }
        public int minX { get; private set; }
        public int maxY { get; private set; }
        public int minY { get; private set; }

        public HashSet<Point> obstacles { get; private set; }  //collection of obstacle points

        //construct grid with given parameters
        public Grid(int maxX = 10, int minX = -10, int maxY = 10, int minY = -10)
        {
            this.maxX = maxX;
            this.minX = minX;
            this.maxY = maxY;
            this.minY = minY;

            //generate obstacles in 1/10th of the map
            int numObstacles = ((maxX - minX) * (maxY - minY)) / 10;
            obstacles = new HashSet<Point>();

            Random rand = new Random(); //to generate random numbers
            int index = 1;
            while(index <= numObstacles)
            {
                //generate random point; if it is a new point, add it to set
                Point p = new Point(rand.Next(minX, maxX + 1), rand.Next(minY, maxY + 1));
                if(!obstacles.Contains(p))
                {
                    obstacles.Add(p);
                    index++;
                }
            }
        }

        //method to show obstacle points
        public void showObstacles()
        {
            foreach (Point p in obstacles)
                Console.WriteLine("(" + p.X + ", " + p.Y + ")");
        }
    }
}