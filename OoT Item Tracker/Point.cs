using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoT_Item_Tracker
{
        class Point
        {
                int x;
                int y;

                public Point()
                {
                        x = 0;
                        y = 0;
                }

                public Point(int startingX, int startingY)
                {
                        x = startingX;
                        y = startingY;
                }

                public int getX()
                {
                        return x;
                }
                public int getY()
                {
                        return y;
                }
                public int[] getPoint()
                {
                        int[] point = { x, y };
                        return point;
                }

                public void setX(int newX)
                {
                        x = newX;
                }
                public void setY(int newY)
                {
                        y = newY;
                }
                public void setPoint(int newX, int newY)
                {
                        x = newX;
                        y = newY;
                }
                
        }
}
