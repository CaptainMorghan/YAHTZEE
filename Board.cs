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

namespace myGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas canvas = new Canvas();
        Line[] columnLines;
        Line[] rowLines;
        public MainWindow()
        {
  

            createColumns();
            createRows();
            addString("Aces", 0, 0);
            addString("Twos", 0, 25);
            addString("Threes", 0, 50);
            addString("Fours", 0, 75);
            addString("Fives", 0, 100);
            addString("Sixes", 0, 125);
            addString("TotalScore", 0, 150);
            addString("Bonus", 0, 175);
            addString("TotalScore", 0, 200);
            addString("3 Of A Kind", 0, 225);
            addString("4 Of A Kind", 0, 250);
            addString("Full House", 0, 275);
            addString("Sm Straight", 0, 300);
            addString("Lg Straight", 0, 325);
            addString("YAHTZEE", 0, 350);
            addString("Chance", 0, 375);
            addString("Total Lw", 0, 400);
            addString("Total Up", 0, 425);
            addString("Grand Total", 0, 450);
            addStringSmall("Count and add", 150, 0);
            addStringSmall("Only Aces", 150, 10);
            addStringSmall("Count and add", 150, 25);
            addStringSmall("Only Twos", 150, 35);
            addStringSmall("Count and add", 150, 50);
            addStringSmall("Only Threes", 150, 60);
            addStringSmall("Count and add", 150, 75);
            addStringSmall("Only Fours", 150, 85);
            addStringSmall("Count and add", 150, 100);
            addStringSmall("Only Fives", 150, 110);
            addStringSmall("Count and add", 150, 125);
            addStringSmall("Only Sixes", 150, 135);
            addString("----------->", 150, 150);
            addStringSmall("If 63 Points", 150, 175);
            addStringSmall("Get Bonus 35", 150, 185);
            addString("----------->", 150, 200);
            addStringSmall("Count and add", 150, 225);
            addStringSmall("Three Like Die", 150, 235);
            addStringSmall("Count and add", 150, 250);
            addStringSmall("Four Like Die", 150, 260);
            addStringSmall("Score 25", 150, 275);
            addStringSmall("Score 30", 150, 300);
            addStringSmall("Score 40", 150, 325);
            addStringSmall("Score 50", 150, 350);
            addStringSmall("Sum of all die", 150, 375);
            addString("----------->", 150, 400);
            addString("----------->", 150, 425);
            addString("----------->", 150, 450);
        }



        private void addString(string s, int x, int y)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 14;
            canvas.Children.Add(textBlock);
            Canvas.SetTop(textBlock, y);
            Canvas.SetLeft(textBlock, x);
        }
        //Need a seperate sized font so I'm creating another method
        private void addStringSmall(string s, int x, int y)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 12;
            canvas.Children.Add(textBlock);
            Canvas.SetTop(textBlock, y);
            Canvas.SetLeft(textBlock, x);



        }
        private void createColumns()
        {
            columnLines = new Line[4];
            for (int i = 0; i < columnLines.Length; i++)
            {
                columnLines[i] = new Line();
                columnLines[i].Stroke = Brushes.Black;
                columnLines[i].X1 = 150 * i;
                columnLines[i].X2 = columnLines[i].X1;
                columnLines[i].Y1 = 0;
                columnLines[i].Y2 = 475;

                canvas.Children.Add(columnLines[i]);
            }
        }

        private void createRows()
        {
            rowLines = new Line[20];
            for (int i = 0; i < rowLines.Length; i++)
            {
                rowLines[i] = new Line();
                rowLines[i].Stroke = Brushes.Black;
                rowLines[i].Y1 = 25 * i;
                rowLines[i].Y2 = rowLines[i].Y1;
                rowLines[i].X1 = 0;
                rowLines[i].X2 = 450;

                canvas.Children.Add(rowLines[i]);
            }
        }

        private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(canvas);
            if (p.X > 300 && p.X < 450 && p.Y > 0 && p.Y < 25)
            {

            }
        }


    }
}
