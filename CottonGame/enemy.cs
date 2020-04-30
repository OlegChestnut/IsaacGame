using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottonGame
{
    struct Enemy_parameter
    {
        public int speed;
        public double x, y, angle;
    }
    class Enemy
    {
        public List<Enemy_parameter> enemy_Parameters = new List<Enemy_parameter>();

        public Enemy()
        {
            enemy_Parameters.Add(new Enemy_parameter() { speed = 3, x=0, y=0 });
        }

        public double getAngle(double x2, double y2, int i)
        {
            return Math.Atan2((enemy_Parameters[i].x - x2),(enemy_Parameters[i].y - y2));
        }
        public char ChangePosition(int i)
        {
            char sp_direct='N';
            var temp = enemy_Parameters[i];
            double x, y;
            x = enemy_Parameters[i].speed * Math.Sin(enemy_Parameters[i].angle);
            temp.x -= x;
            y = enemy_Parameters[i].speed * Math.Cos(enemy_Parameters[i].angle);
            temp.y -= y;
            if (x<=y) {
                if (x>=0)
                {
                    sp_direct = 'U';
                }
                else sp_direct = 'R';
            }
            else
            {
                if (y >= 0)
                {
                    sp_direct = 'L';
                }
                else sp_direct = 'D';
            }
            enemy_Parameters[i] = temp;
            return sp_direct;
        }
    }
}
