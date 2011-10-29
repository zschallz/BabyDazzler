using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace BabyDazzler.Dazzlers
{
    class VisualDazzle
    {
        private Random random;
        private Shape shape;

        public VisualDazzle(double maxSize, Random random)
        {
            this.random = random;
            shape = randomShape();

            // if successfully made, set height and width.
            if (shape != null)
            {
                int size = random.Next(Convert.ToInt32(getMinSize(maxSize)), Convert.ToInt32(maxSize));

                shape.Width = size;
                shape.Height = size;
            }
        }

        private Shape randomShape()
        {
            // Generate random number
            //int randomNum = random.Next(0, 3);

            // debug exclude triangle
            int randomNum = random.Next(0, 2);
            // end debug

            // Build different shape depending on the number generated (expects 1, 2 or 3).
            switch (randomNum)
            {
                case 0:
                    return buildEllipse();
                case 1:
                    return buildRectangle();
                case 2:
                    return buildTriangle();
                default:
                    throw new 
                        InvalidOperationException("Expected randomNum to be between 0 and 2, was " + randomNum);
            }
        }

        private Polygon buildTriangle()
        {
            throw new NotImplementedException();
        }

        private Rectangle buildRectangle()
        {
            // Create Ellipse object
            Rectangle r = new Rectangle();
            SolidColorBrush colorBrush = new SolidColorBrush();
            colorBrush.Color = getRandomColor();

            r.Fill = colorBrush;

            return r;
        }

        private Ellipse buildEllipse()
        {
            // Create Ellipse object
            Ellipse e = new Ellipse();
            SolidColorBrush colorBrush = new SolidColorBrush();
            colorBrush.Color = getRandomColor();

            e.Fill = colorBrush;

            return e;
        }

        public Shape GetView()
        {
            return shape;
        }

        private Color getRandomColor()
        {
            return Color.FromArgb(255,
                                  Convert.ToByte(random.Next(255)),
                                  Convert.ToByte(random.Next(255)), 
                                  Convert.ToByte(random.Next(255)));
        }

        // For now, minimum size is 20% of the maximum size.
        private double getMinSize(double maxSize)
        {
            return maxSize * .20;
        }
    }
}
