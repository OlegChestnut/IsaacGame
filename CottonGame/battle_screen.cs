using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CottonGame
{
    public partial class battle_screen : Form
    {
        public Bitmap bitmap;

        Image sp_enemy = new Bitmap("Resources/sprite_enemy_evilplant.png", true);
        Image sp_enemy_d = new Bitmap("Resources/sprite_enemy_evilplant_d.png", true);
        Image sp_enemy_l = new Bitmap("Resources/sprite_enemy_evilplant_l.png", true);
        Image sp_enemy_r = new Bitmap("Resources/sprite_enemy_evilplant_r.png", true);

        Image sp_bullet = new Bitmap("Resources/sprite_bullet_fairy.png", true);
        Image sp_bullet_d = new Bitmap("Resources/sprite_bullet_fairy_d.png", true);
        Image sp_bullet_l = new Bitmap("Resources/sprite_bullet_fairy_l.png", true);
        Image sp_bullet_r = new Bitmap("Resources/sprite_bullet_fairy_r.png", true);

        Image sp_tile_evil = new Bitmap("Resources/sprite_tile_evil.png", true);
        Image sp_flower = new Bitmap("Resources/sprite_tile_center_flower.png", true);
        Image back = new Bitmap("Resources/sp_green_background.png", true);

        Character_Cotton Cotton;
        Enemy enemy;
        Bullet bullet;

        Pen pink = new Pen(Color.Pink,2);
        SolidBrush lavender = new SolidBrush(Color.LavenderBlush);
        
        bool down_press = false, up_press = false, left_press = false, right_press = false;
        bool down_shooting = false, up_shooting = false, left_shooting = false, right_shooting = false;


        int width = 10, height = 10, score=0;
        public battle_screen()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            KeyPreview = true;
            Cotton = new Character_Cotton();
            Cotton.x = pictureBox1.Width / 2;
            Cotton.y = pictureBox1.Height / 2;
            Cotton.rect.X = (int)Cotton.x;
            Cotton.rect.Y = (int)Cotton.y;
            enemy = new Enemy();
            bullet = new Bullet();
        }

        void DrawEnv()//отрисовка окрyжения
        {
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((j == 0) || (i == 0) || (j == width - 1) || (i == height - 1))
                        g.DrawImage(sp_tile_evil, j * 64, i * 64);
                }
            }
            g.DrawImage(sp_flower, (float)Cotton.x - 64, (float)Cotton.y - 64);
        }

        void DrawEnemy()//отрисовка врага
        {
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = enemy.enemy_Parameters.Count() - 1; i >= 0; i--)
            {
                var temp = enemy.enemy_Parameters[i];
                temp.angle = enemy.getAngle(Cotton.rect.Left, Cotton.rect.Top, i);
                enemy.enemy_Parameters[i] = temp;
                switch (enemy.ChangePosition(i))
                {
                    case 'U':
                        {
                            g.DrawImage(sp_enemy, (float)enemy.enemy_Parameters[i].x, (float)enemy.enemy_Parameters[i].y);
                            break;
                        }
                    case 'D':
                        {
                            g.DrawImage(sp_enemy_d, (float)enemy.enemy_Parameters[i].x, (float)enemy.enemy_Parameters[i].y);
                            break;
                        }
                    case 'L':
                        {
                            g.DrawImage(sp_enemy_l, (float)enemy.enemy_Parameters[i].x, (float)enemy.enemy_Parameters[i].y);
                            break;
                        }
                    case 'R':
                        {
                            g.DrawImage(sp_enemy_r, (float)enemy.enemy_Parameters[i].x, (float)enemy.enemy_Parameters[i].y);
                            break;
                        }
                }
            }
        }

        void ChangePos()//перемещение персонажа
        {
            Graphics g = Graphics.FromImage(bitmap);
            if (left_press)
            {
                Cotton.rect.Location = new Point(Cotton.rect.Left - 5, Cotton.rect.Top);
            }
            if (right_press)
            {
                Cotton.rect.Location = new Point(Cotton.rect.Left + 5, Cotton.rect.Top);
            }
            if (up_press)
            {
                Cotton.rect.Location = new Point(Cotton.rect.Left, Cotton.rect.Top - 5);
            }
            if (down_press)
            {
                Cotton.rect.Location = new Point(Cotton.rect.Left, Cotton.rect.Top + 5);
            }
            GraphicsPath gf = Cotton.GetCottonDirect(Cotton.rect, Cotton.rect.Width, Cotton.direct);
            g.FillPath(lavender, gf);
            g.DrawPath(pink, gf);
        }

        void DrawBullets()//отрисовка пулек
        {
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = bullet.coordinats.Count() - 1; i >= 0; i--)
            {
                bool breaker = false;
                var temp = bullet.coordinats[i];
                switch (bullet.coordinats[i].direct)
                {
                    case 'U':
                        {
                            temp.y -= 10;
                            bullet.coordinats[i] = temp;
                            g.DrawImage(sp_bullet_d, bullet.coordinats[i].x, bullet.coordinats[i].y);
                            break;
                        }
                    case 'D':
                        {
                            temp.y += 10;
                            bullet.coordinats[i] = temp;
                            g.DrawImage(sp_bullet, bullet.coordinats[i].x, bullet.coordinats[i].y);
                            break;
                        }
                    case 'L':
                        {
                            temp.x -= 10;
                            bullet.coordinats[i] = temp;
                            g.DrawImage(sp_bullet_r, bullet.coordinats[i].x, bullet.coordinats[i].y);
                            break;
                        }
                    case 'R':
                        {
                            temp.x += 10;
                            bullet.coordinats[i] = temp;
                            g.DrawImage(sp_bullet_l, bullet.coordinats[i].x, bullet.coordinats[i].y);
                            break;
                        }
                }
                //удаление пульки
                for (int j = enemy.enemy_Parameters.Count() - 1; j >= 0; j--)
                {
                    
                        if ((bullet.coordinats[i].x > enemy.enemy_Parameters[j].x - 20) && (bullet.coordinats[i].x < enemy.enemy_Parameters[j].x + 20) && (bullet.coordinats[i].y < enemy.enemy_Parameters[j].y + 20) && (bullet.coordinats[i].y > enemy.enemy_Parameters[j].y - 20)){
                            bullet.coordinats.RemoveAt(i);
                            enemy.enemy_Parameters.RemoveAt(j);
                            score++;
                            breaker=true;
                        }
                    if (breaker) break;
                }
                if (breaker) break;
                if ((bullet.coordinats[i].x <= 20) || (bullet.coordinats[i].y <= 20) || (bullet.coordinats[i].x >= pictureBox1.Width - 40) || (bullet.coordinats[i].y >= pictureBox1.Height - 40))
                {
                    bullet.coordinats.RemoveAt(i);
                }
            }
        }
        private void timer_generator_Tick(object sender, EventArgs e)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int cord_x, cord_y;
            do
            {
                cord_x = rand.Next(1,640);
                cord_y = rand.Next(1, 640);
            } while (!(cord_x < 32|| cord_x > 600)&&!(cord_y < 10 || cord_y > 632));
            enemy.enemy_Parameters.Add(new Enemy_parameter() { speed = 3, x = cord_x, y = cord_y });
        }

        private void timer_bullet_Tick(object sender, EventArgs e)
        {
                bullet.coordinats.Add(new Coordinat_bullet() { speed = 30, x = Cotton.rect.X, y = Cotton.rect.Y, direct = Cotton.direct });
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bitmap);
            label1.Text = ("SCORE: " + score.ToString());

            if (!(down_shooting || left_shooting || right_shooting || up_shooting)) timer_bullet.Stop();

            g.Clear(Color.LightGreen);
            g.DrawImage(back, 0, 0);

            DrawBullets();
            DrawEnemy();
            ChangePos();
            DrawEnv();
            pictureBox1.Image = bitmap;
        }

        private void battle_screen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up": {
                        timer_bullet.Enabled = true;
                        up_shooting = true;
                        Cotton.direct = 'U';
                        break;
                    }
                case "Left": {
                        timer_bullet.Enabled = true;
                        left_shooting = true;
                        Cotton.direct = 'L';
                        break;
                    }
                case "Down": {
                        timer_bullet.Enabled = true;
                        down_shooting = true;
                        Cotton.direct = 'D';
                        break;
                    }
                case "Right": {
                        timer_bullet.Enabled = true;
                        right_shooting = true;
                        Cotton.direct = 'R';
                        break;
                    }
            }
            if (e.KeyCode == Keys.A)
            {
                left_press = true;
            }
            if (e.KeyCode == Keys.D)
            {
                right_press = true;
            }
            if (e.KeyCode == Keys.W)
            {
                up_press = true;
            }
            if (e.KeyCode == Keys.S)
            {
                down_press = true;
            }
        }
        private void battle_screen_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                left_press = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right_press = false;
            }
            if (e.KeyCode == Keys.W)
            {
                up_press = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down_press = false;
            }

            switch (e.KeyCode.ToString())
            {
                case "Up":
                    {
                        up_shooting = false;
                        break;
                    }
                case "Left":
                    {
                        left_shooting = false;
                        break;
                    }
                case "Down":
                    {
                        down_shooting = false;
                        break;
                    }
                case "Right":
                    {
                        right_shooting = false;
                        break;
                    }
            }
        }
    }
}
