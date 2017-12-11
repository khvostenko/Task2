using System;

namespace Task2
{
    class Rectangle
    {
        private Coordinates coordsA;
        private Coordinates coordsB;

        public Rectangle() { }

        public Rectangle(Coordinates coordsA, Coordinates coordsB)
        {
            this.coordsA = coordsA;
            this.coordsB = coordsB;
        }

        public Coordinates GetCoordsA
        {
            get
            {
                return coordsA;
            }
            set
            {
                if (coordsA.x < coordsB.x && coordsA.y > coordsB.y)
                {
                    coordsA = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Coordinates GetCoordsB
        {
            get
            {
                return coordsB;
            }
            set
            {
                if (coordsA.x < coordsB.x && coordsA.y > coordsB.y)
                {
                    coordsA = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        public void DisplayRectangle()
        {
            Console.WriteLine("Point A({0}; {1})\nPoint B({2}; {3})\nPoint C({4}; {5})\nPoint D({6}; {7})",
                coordsA.x, coordsA.y, coordsB.x, coordsA.y, coordsA.x, coordsB.y, coordsB.x, coordsB.y);
        }

        public static double Width(Coordinates A, Coordinates B)
        {
            return Math.Abs(A.x - B.x);
        }

        public static double Height(Coordinates A, Coordinates B)
        {
            return Math.Abs(A.y - B.y);
        }

        public static Rectangle MovingRectangle(Rectangle rectangle, Coordinates coordsA, Coordinates coordsB)
        {
            rectangle.coordsA.x = coordsA.x;
            rectangle.coordsA.y = coordsA.y;
            rectangle.coordsB.x = coordsB.x;
            rectangle.coordsB.y = coordsB.y;

            return rectangle;
        }

        public static Rectangle ChangeSize(Rectangle rectangle, double size)
        {
            rectangle.coordsA.x += size / 2;
            rectangle.coordsA.y += size / 2;
            rectangle.coordsB.x += size / 2;
            rectangle.coordsB.y += size / 2;

            return rectangle;
        }

        public static Rectangle TheSmallestRectangle(Rectangle rect1, Rectangle rect2)
        {
            if (Rectangle.Height(rect1.coordsA, rect1.coordsB) * Rectangle.Width(rect1.coordsA, rect1.coordsB) >
               Rectangle.Height(rect2.coordsA, rect2.coordsB) * Rectangle.Width(rect2.coordsA, rect2.coordsB)) 
            {
                return rect1;
            }
            else
            {
                return rect2;
            }
        }

        public static bool ChekCross(Rectangle rect1, Coordinates A)
        {
            if (A.x > rect1.coordsA.x && A.x < rect1.coordsB.x && A.y < rect1.coordsA.y && A.y > rect1.coordsB.y) 
            {
                return true;
            }
            return false;
        }

        public static Rectangle CrossRectangles(Rectangle rect1, Rectangle rect2)
        {
            Coordinates B = new Coordinates(rect2.coordsB.x, rect2.coordsA.y);
            Coordinates C = new Coordinates(rect2.coordsA.x, rect2.coordsB.y);

            Rectangle rectTemp = new Rectangle();

            if (Height(rect1.coordsA, rect1.coordsB) * Width(rect1.coordsA, rect1.coordsB) <
                Height(rect2.coordsA, rect2.coordsB) * Width(rect2.coordsA, rect2.coordsB)) 
            {
                rectTemp = rect1;
                rect1 = rect2;
                rect2 = rectTemp;
            }


            if (ChekCross(rect1, rect2.coordsA) == true)
            {
                Rectangle rect3 = new Rectangle();

                if (ChekCross(rect1, B) == true)
                {
                    Coordinates coord = new Coordinates(rect2.coordsB.x,rect1.coordsB.y);

                    rect3.coordsA = rect2.coordsA;
                    rect3.coordsB = coord;           
                }

                if (ChekCross(rect1, C) == true)
                {
                    Coordinates coord = new Coordinates(rect1.coordsB.x, rect2.coordsB.y);
                    rect3.coordsA = rect2.coordsA;
                    rect3.coordsB = coord;
                }

                else
                {
                    rect3.coordsA = rect2.coordsA;
                    rect3.coordsB = rect1.coordsB;
                }
              
                return rect3;
            }

            if (ChekCross(rect1, rect2.coordsB) == true) 
            {
                Rectangle rect3 = new Rectangle();

                if (ChekCross(rect1, B) == true)
                {
                    Coordinates coord = new Coordinates(rect1.coordsA.x, rect2.coordsA.y);

                    rect3.coordsB = rect2.coordsB;
                    rect3.coordsA = coord;
                }

                if (ChekCross(rect1, C) == true)
                {
                    Coordinates coord = new Coordinates(rect2.coordsA.x, rect1.coordsA.y);
                    rect3.coordsB = rect2.coordsB;
                    rect3.coordsA = coord;
                }

                else
                {
                    rect3.coordsA = rect1.coordsA;
                    rect3.coordsB = rect2.coordsB;
                }

                return rect3;
            }

            if (ChekCross(rect1, C)) 
            {
                Rectangle rect3 = new Rectangle();

                Coordinates coordA = new Coordinates(rect2.coordsA.x, rect1.coordsA.y);
                Coordinates coordB = new Coordinates(rect1.coordsB.x, rect2.coordsB.y);

                rect3.coordsA = coordA;
                rect3.coordsB = coordB;

                return rect3;
            }

            if (ChekCross(rect1, B))
            {
                Rectangle rect3 = new Rectangle();

                Coordinates coordA = new Coordinates(rect1.coordsA.x, rect2.coordsA.y);
                Coordinates coordB = new Coordinates(rect2.coordsB.x, rect1.coordsB.y);

                rect3.coordsA = coordA;
                rect3.coordsB = coordB;

                return rect3;
            }

            if (ChekCross(rect1, rect2.coordsB) == true && ChekCross(rect1, rect2.coordsA) == true) 
            {
                return rect2;
            }

            throw new InvalidOperationException();  
        }
    }
}
