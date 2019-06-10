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


    class Board
    {

        Canvas canvas;
        Line[] columnLines;
        Line[] rowLines;

        public Board(Canvas canvas)
        {
            this.canvas = canvas;
            String();
        }

        public void String()
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
            addString("Total Up", 0, 400);
            addString("Total Lw", 0, 425);
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
            addString("RollDice", 730, 135);
            addString("Surprise", 730, 300);
            addString("NewGame", 730, 200);
            addString("HighScore", 0, 475);

        }
        public void addString(string s, int x, int y)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 14;
            canvas.Children.Add(textBlock);
            Canvas.SetTop(textBlock, y);
            Canvas.SetLeft(textBlock, x);
        }
        public void addStringRemove(string s, int x, int y)//any strings used with this method can also be deleated en mass if the new game button is clicked
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
        public void addStringSmall(string s, int x, int y)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = s;
            textBlock.Foreground = Brushes.Black;
            textBlock.FontSize = 12;
            canvas.Children.Add(textBlock);
            Canvas.SetTop(textBlock, y);
            Canvas.SetLeft(textBlock, x);



        }
        public void createColumns()
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

        public void createRows()
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
        public void Rick_Roll()
        {
            Rectangle r = new Rectangle();
            r.Height = 25;
            r.Width = 100;
            r.Stroke = Brushes.Black;
            canvas.Children.Add(r);
            Canvas.SetTop(r, 300);
            Canvas.SetLeft(r, 730);
        }
        public void Roll_Dice()
        {
            Rectangle r = new Rectangle();
            r.Height = 25;
            r.Width = 100;
            
            r.Stroke = Brushes.Black;
            canvas.Children.Add(r);
            Canvas.SetTop(r, 135);
            Canvas.SetLeft(r, 730);
        }
        public void New_Game()
        {
            Rectangle r = new Rectangle();
            r.Height = 25;
            r.Width = 100;

            r.Stroke = Brushes.Black;
            canvas.Children.Add(r);
            Canvas.SetTop(r, 200);
            Canvas.SetLeft(r, 730);
        }
        public void High_Score()
        {
            Rectangle r = new Rectangle();
            r.Height = 25;
            r.Width = 100;

            r.Stroke = Brushes.Black;
            canvas.Children.Add(r);
            Canvas.SetTop(r, 500);
            Canvas.SetLeft(r, 0);
        }
        
       
    }
  }
    


