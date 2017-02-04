using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//Modify the Line, Circle, and Shape classes of Examples 10.12 and 10.13 to make all
//data fields private and add public methods such as GetLocation to access those fields.

namespace Exercise10_12
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Shape
    {
        //made private
        private Point location;

        public Shape()
        {
            location = new Point(0, 0);
        }

        public Shape(Point p)
        {
            location = p;
        }

        public abstract void Draw(Graphics g);

        public virtual void Move(int xamount, int yamount)
        {
            location += new Size(xamount, yamount);
        }

        public override String ToString()
        {
            return location.ToString();
        }
        //added getter for location
        public Point GetLocation()
        {
            return location;
        }
        //added setter for location
        public void SetLocation(Point point)
        {
            location = point;
        }
    }

    public class Line : Shape
    {
        //made private
        private Point end;

        public Line(int x1, int y1, int x2, int y2)
        : base(new Point(x1, y1))
        {
            end = new Point(x2, y2);
        }

        public override void Draw(Graphics g)
        {
            Pen blue = new Pen(Color.Blue, 3);
            g.DrawLine(blue, GetLocation(), end);
        }

        public override String ToString()
        {
            return "Line from " + base.ToString()
            + " to " + end;
        }

        public override void Move(int xamount, int yamount)
        {
            base.Move(xamount, yamount);
            end += new Size(xamount, yamount);
        }
        //added getter for end
        public Point GetEnd()
        {
            return end;
        }
        //added setter for end
        public void SetEnd(Point point)
        {
            end = point;
        }
    }

    public class Circle : Shape
    {
        //made private
        private int radius;

        public Circle(Point p, int r) : base(p)
        {
            radius = r;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, GetLocation().X - radius,
            GetLocation().Y - radius, 2 * radius, 2 * radius);
        }
        //added getter for radius
        public int GetRadius()
        {
            return radius;
        }
        //added setter for radius
        public void SetRadius(int x)
        {
            this.radius = x;
        }

        public override string ToString()
        {
            return "Circle at " + base.ToString()
            + " with radius " + radius;
        }
    }


}
