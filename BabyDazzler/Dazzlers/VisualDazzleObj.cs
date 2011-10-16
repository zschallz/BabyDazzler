using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace BabyDazzler.Dazzlers
{
    class VisualDazzleObj
    {
        private Shape shape;

        public VisualDazzleObj()
        {
            this.shape = randomShape();
        }

        private Shape randomShape()
        {
            Random random = new Random();
            int randomNum = random.Next(0, 2);

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
            throw new NotImplementedException();
        }

        private Ellipse buildEllipse()
        {
            throw new NotImplementedException();
        }

        public StackPanel GetView()
        {
            throw new NotImplementedException();
        }
    }
}
