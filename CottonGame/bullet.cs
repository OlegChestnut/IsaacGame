using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CottonGame
{
    struct Coordinat_bullet
    {
        public int y, x, speed;
        public char direct;
    }
    class Bullet
    {
            public List<Coordinat_bullet> coordinats = new List<Coordinat_bullet>();
        public void GenerateBullet()
        {
            coordinats.Add(new Coordinat_bullet() { x = 0, y = 0, speed = 30 });
        }
    }
}
