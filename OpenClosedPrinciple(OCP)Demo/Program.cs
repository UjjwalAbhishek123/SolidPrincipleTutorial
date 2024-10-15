namespace OpenClosedPrinciple_OCP_Demo
{
    /* Before applying Open Closed Principle */
    //public class Rectangle
    //{
    //    public double width { get; set; }
    //    public double height { get; set; }
    //}

    //public class Circle
    //{
    //    public double radius { get; set; }
    //}

    //public class Shape
    //{
    //    public double CalculateArea(object shape)
    //    {
    //        //if shape is rectangle
    //        if(shape is Rectangle rectangle)
    //        {
    //            //return area
    //            return rectangle.height * rectangle.width;
    //        }
    //        //if shape is Circle
    //        else if(shape is Circle circle)
    //        {
    //            //return area
    //            return Math.PI * circle.radius * circle.radius;
    //        }

    //        throw new ArgumentException("unknown Shape");
    //    }

    //    /* It will work for these 2 shapes, but if we have any other shape, then we have to modify the clas
    //     * in accordance to fit that shape condition,
    //     * 
    //     * So, it Violates Open closed Principle
    //     */
    //}

    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //object of class Shape
    //        Shape shapeAreaCalc = new Shape();

    //        //object of class Rectangle
    //        Rectangle rect = new Rectangle() { height = 10, width = 5 };

    //        //Object of Circle Class
    //        Circle circle = new Circle() { radius = 3 };

    //        Console.WriteLine("Rectangle Area: " + shapeAreaCalc.CalculateArea(rect));
    //        Console.WriteLine("Circle Area: " + shapeAreaCalc.CalculateArea(circle));
    //    }
    //}

    // Solution based on Open Closed Principle
    //create an interface/abstarct class that will have method for calculating area for all kind of shapes
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    //Rectangle class extending base class Shape, without modification in base class
    public class Rectangle : Shape
    {
        public double width { get; set; }
        public double height { get; set; }
        public override double CalculateArea()
        {
            return width * height;
        }
    }

    //Circle class extending base class Shape, without modification in base class
    public class Circle : Shape
    {
        public double radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    //Now we can add any kind of shape without modifying existing code
    //Traingle class added
    public class Triangle : Shape
    {
        public double baseLength {get; set;}
        public double height {get; set;}
        public override double CalculateArea()
        {
            return 0.5 * baseLength * height;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //using Polymorphism to handle different shapes
            Shape rectangle = new Rectangle() { height = 10, width = 5 };

            Shape circle = new Circle() { radius = 3 };

            Shape triangle = new Triangle() { baseLength = 4, height = 6 };

            Console.WriteLine("Rectangle Area: " + rectangle.CalculateArea());
            Console.WriteLine("Circle Area: " + circle.CalculateArea());
            Console.WriteLine("Triangle Area: " + triangle.CalculateArea());
        }
    }
}
