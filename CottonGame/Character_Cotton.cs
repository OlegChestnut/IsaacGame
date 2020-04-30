using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CottonGame
{
    class Character_Cotton
    {
        public double x, y;
        static int width = 32, height = 32;
        public Rectangle rect = new Rectangle(0, 0, width, height);
        public char direct = 'D';

        public GraphicsPath GetCottonDirect(RectangleF Rect, int radius, char direct)
        {
            GraphicsPath GF = new GraphicsPath();
            switch (direct)
            {
                case 'L':
                    {
                        GF.AddLine(Rect.X, Rect.Y + Rect.Height/2, Rect.X, Rect.Y + Rect.Height / 2);//левая полоска
                        GF.AddArc(Rect.X + Rect.Width - radius,
                                Rect.Y + Rect.Height - radius, radius, radius, 90, -90);//правая нижняя
                        GF.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 360, -90);//верхняя правая
                        break;
                    }
                case 'R':
                    {
                        GF.AddLine(Rect.X + Rect.Width, Rect.Y + Rect.Height / 2, Rect.X + Rect.Width, Rect.Y + Rect.Height / 2);//правая полоска
                        GF.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);//левая нижняя
                        GF.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);//левая верхняя
                        break;
                    }
                case 'U':
                    {
                        GF.AddLine(Rect.X + Rect.Width / 2, Rect.Y, Rect.X + Rect.Width / 2, Rect.Y);//верхняя полоска
                        GF.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 180, -90);//левая нижняя
                        GF.AddArc(Rect.X + Rect.Width - radius,
                                Rect.Y + Rect.Height - radius, radius, radius, 90, -90);//правая нижняя
                        break;
                    }
                case 'D':
                    {
                        GF.AddLine(Rect.X + Rect.Width / 2, Rect.Y + Rect.Height, Rect.X + Rect.Width / 2, Rect.Y + Rect.Height);//нижняя полоска
                        GF.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);//левая верхняя
                        GF.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);//верхняя правая
                        break;
                    }
            }

            GF.CloseFigure();

            return GF;
        }

    }
}
