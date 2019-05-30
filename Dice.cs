using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data; 
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yahtzee
{
    class Dice
    {
        //Variables -  Canvas, Rectangle, Ellipse[], int
        Canvas canvas;
        Ellipse[] dots;
        Rectangle diceRectangle;
        int drawSize ;
        public int dieValue;
        /// <summary>
        /// Creates a dice
        /// </summary>
        /// <param name="c">The canvas to draw on</param>
        /// <param name="p">A starting point on the canvas for the top-left corner</param>
        public Dice(Canvas c, Point p)
        {
            canvas = c;
            //set up the rectanlge

            diceRectangle = new Rectangle();
            diceRectangle.Fill = Brushes.White;
            diceRectangle.Stroke = Brushes.Black;
            drawSize = 100;
            diceRectangle.Height = drawSize;
            diceRectangle.Width = drawSize;
            canvas.Children.Add(diceRectangle);
            Canvas.SetLeft(diceRectangle, p.X);
            Canvas.SetTop(diceRectangle, p.Y);

            dots = new Ellipse[9];
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i] = new Ellipse();
                dots[i].Fill = Brushes.Black;
                dots[i].Height = drawSize / 9;
                dots[i].Width = dots[i].Height;
                canvas.Children.Add(dots[i]);
                Canvas.SetLeft(dots[i], p.X + (dots[i].Width*2 * ((i%3)+1)));
                Canvas.SetTop(dots[i], p.Y + ((i / 3)+1) * dots[i].Height*2);
            }
        }
        public void drawDie()
        {
            clearDie();
            if (dieValue == 1)
            {
                dots[4].Fill = Brushes.Black;
            }
            else if (dieValue == 2)
            {
                dots[0].Fill = Brushes.Black;
                dots[8].Fill = Brushes.Black;
            }
            else if (dieValue == 3)
            {
                dots[0].Fill = Brushes.Black;
                dots[4].Fill = Brushes.Black;
                dots[8].Fill = Brushes.Black;
            }
            else if (dieValue == 4)
            {
                dots[0].Fill = Brushes.Black;
                dots[2].Fill = Brushes.Black;
                dots[6].Fill = Brushes.Black;
                dots[8].Fill = Brushes.Black;
            }
            else if (dieValue == 5)
            {
                dots[0].Fill = Brushes.Black;
                dots[2].Fill = Brushes.Black;
                dots[4].Fill = Brushes.Black;
                dots[6].Fill = Brushes.Black;
                dots[8].Fill = Brushes.Black;
            }
            else if (dieValue == 6)
            {
                dots[0].Fill = Brushes.Black;
                dots[2].Fill = Brushes.Black;
                dots[3].Fill = Brushes.Black;
                dots[5].Fill = Brushes.Black;
                dots[6].Fill = Brushes.Black;
                dots[8].Fill = Brushes.Black;
            }
           
            
        }
            public void clearDie()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].Fill = Brushes.White;
            }
        }
    }


}
