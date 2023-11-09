using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blokus_777
{
    public partial class Form1 : Form
    {
        // Создание экземпляра объекта Shape
        Shape shape;

        // Обработка нажатий клавиш стрелок
        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (shape != null)
        //    {
        //        if (e.KeyCode == Keys.Right)
        //        {
        //            shape.MoveRight();
        //            Invalidate(); // Обновление отображения формы
        //        }
        //        else if (e.KeyCode == Keys.Left)
        //        {
        //            shape.MoveLeft();
        //            Invalidate();
        //        }
        //        else if (e.KeyCode == Keys.Up)
        //        {
        //            shape.MoveUp();
        //            Invalidate();
        //        }
        //        else if (e.KeyCode == Keys.Down)
        //        {
        //            shape.MoveDown();
        //            Invalidate();
        //        }
        //    }
        //}

        //// Создание объекта shape и отображение на форме при нажатии кнопки
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    shape = new Shape(5, 5);
        //    Invalidate(); // Обновление отображения формы
        //}

        // Создание объекта shape и отображение на форме при нажатии кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            shape = new Shape(5, 5);
            Invalidate(); // Обновление отображения формы
            this.Focus(); // Установка фокуса на форму, чтобы событие KeyDown срабатывало
        }

        // Вызов метода Form1_KeyDown при нажатии клавиш и перемещение объекта shape
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (shape != null)
            {
                if (keyData == Keys.Right)
                {
                    shape.MoveRight();
                    Invalidate(); // Обновление отображения формы
                    return true;
                }
                else if (keyData == Keys.Left)
                {
                    shape.MoveLeft();
                    Invalidate();
                    return true;
                }
                else if (keyData == Keys.Up)
                {
                    shape.MoveUp();
                    Invalidate();
                    return true;
                }
                else if (keyData == Keys.Down)
                {
                    shape.MoveDown();
                    Invalidate();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Отрисовка фигуры и сетки
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawGrid(g); // Отрисовка сетки
            if (shape != null)
            {
                DrawShape(g, shape); // Отрисовка фигуры
            }
        }

        private void DrawShape(Graphics g, Shape shape)
        {
            int size = 25; // Размер ячейки сетки

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (shape.matrix[i, j] == 1)
                    {
                        g.FillRectangle(Brushes.Black, new Rectangle(50 + (shape.x + j) * size, 100 + (shape.y + i) * size, size, size));
                    }
                }
            }
        }

        // Вызов метода Form1_KeyDown при нажатии клавиш
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        // Отрисовка сетки
        public void DrawGrid(Graphics g)
        {
            int size = 25; // Размер ячейки сетки

            for (int i = 0; i <= 20; i++)
            {
                // Отрисовка горизонтальных линий
                g.DrawLine(Pens.Black, new Point(50, 100 + i * size), new Point(50 + 20 * size, 100 + i * size));
            }
            for (int i = 0; i <= 20; i++)
            {
                // Отрисовка вертикальных линий
                g.DrawLine(Pens.Black, new Point(50 + i * size, 100), new Point(50 + i * size, 100 + 20 * size));
            }
        }

        
    }
}
