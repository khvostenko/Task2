using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates A1;
            Coordinates B1;
            double sizeForRectangle1;

            Coordinates A2;
            Coordinates B2;
            double sizeForRectangle2;

            Rectangle rectangle1 = ReadFromFile("Rectangle1.txt", out A1, out B1, out sizeForRectangle1);
            Rectangle rectangle2 = ReadFromFile("Rectangle2.txt", out A2, out B2, out sizeForRectangle2);

            Console.WriteLine("The first rectangle: ");
            rectangle1.DisplayRectangle();

            Console.WriteLine("The second rectangle: ");
            rectangle2.DisplayRectangle();

            Console.WriteLine("The smallest rectangle: ");
            Rectangle.TheSmallestRectangle(rectangle1, rectangle2).DisplayRectangle();

            Console.WriteLine("Intersection of rectangles: ");
            try
            {
                Rectangle.CrossRectangles(rectangle1, rectangle2).DisplayRectangle();
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Сhange the size of the first rectangle on {0}: ", sizeForRectangle1);
            Rectangle.ChangeSize(rectangle1, sizeForRectangle1).DisplayRectangle();

            Console.WriteLine("Сhange the size of the second rectangle on {0}: ", sizeForRectangle2);
            Rectangle.ChangeSize(rectangle2, sizeForRectangle2).DisplayRectangle();

            Console.WriteLine("Moving the first rectangle on point A({0}; {1}) and point D({2}; {3})", A1.x, A1.y, B1.x, B1.y);
            Rectangle.MovingRectangle(rectangle1, A1, B1).DisplayRectangle();

            Console.WriteLine("Moving the second rectangle on point A({0}; {1}) and point D({2}; {3})", A2.x, A2.y, B2.x, B2.y);
            Rectangle.MovingRectangle(rectangle2, A2, B2).DisplayRectangle();

            Console.ReadLine();          
        }
        public static Rectangle ReadFromFile(string path, out Coordinates coords1, out Coordinates coords2, out double size)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                Coordinates A = new Coordinates();
                Coordinates B = new Coordinates();

                string[] text = sr.ReadLine().Split(' ');
                A.x = double.Parse(text[0]);
                A.y = double.Parse(text[1]);

                text = sr.ReadLine().Split(' ');
                B.x = double.Parse(text[0]);
                B.y = double.Parse(text[1]);

                Rectangle rectangle = new Rectangle(A, B);

                text = sr.ReadLine().Split(' ');
                coords1.x = double.Parse(text[0]);
                coords1.y = double.Parse(text[1]);

                text = sr.ReadLine().Split(' ');
                coords2.x = double.Parse(text[0]);
                coords2.y = double.Parse(text[1]);

                size = double.Parse(sr.ReadLine());

                return rectangle;
            }
        }
    }
}
