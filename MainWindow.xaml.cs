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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variables for dice
        int Dice;
        int Dice2;
        int Dice3;
        int Dice4;
        int Dice5;
        //variables for what box you select for scoring
        //UpperSection
        int Aces;
        int Twos;
        int Threes;
        int Fours;
        int Fives;
        int Sixes;
        int UpperSection;
        int UpperSectionSubTotal;
        int UpperSectionBonus;
        int UpperSectionTotal;
        //LowerSection
        int ThreeOfAKind;
        int FourOfAKind;
        int FullHouse;
        int SmallStraight;
        int LargeStraight;
        int Yahtzee;
        int YahtzeeBonus;
        int YahtzeeBonus2;
        int BottomSectionTotal;
        int GrandTotal;
        //Variables for the amount of a certin number this willbe needed to calculate score for allupper section points and certin lower section points
        int NumberOfAces;
        int NumberOfTwos;
        int NumberOfThrees;
        int NumberOfFours;
        int NumberOfFives;
        int NumberOfSixes;

        Dice dice;
        Dice diceTwo;
        Dice diceThree;
        Dice diceFour;
        Dice diceFive;
       



        Random random = new Random();

        
        public MainWindow()
        {
            InitializeComponent();

            //reposition later
            dice = new Dice(canvas, new Point(10, 10));
            diceTwo = new Dice(canvas, new Point(120, 10));
            diceThree = new Dice(canvas, new Point(230, 10));
            diceFour = new Dice(canvas, new Point(340, 10));
            diceFive = new Dice(canvas, new Point(450, 10));
            
        }

        private void RollDice_Click(object sender, RoutedEventArgs e)
        {
            Dice = random.Next(1, 7);
            dice.dieValue = Dice;
            dice.drawDie();

            Dice2 = random.Next(1, 7);
            diceTwo.dieValue = Dice2;
            diceTwo.drawDie();

            Dice3 = random.Next(1, 7);
            diceThree.dieValue = Dice3;
            diceThree.drawDie();

            Dice4 = random.Next(1, 7);
            diceFour.dieValue = Dice4;
            diceFour.drawDie();

            Dice5 = random.Next(1, 7);
            diceFive.dieValue = Dice5;
            diceFive.drawDie();
            
            
        }

        private void Ones_Click(object sender, RoutedEventArgs e)
        {
            lblOnes.Content = ("Dice 1: " + dice.dieValue.ToString() + "\n" + "Dice 2: " + diceTwo.dieValue.ToString());
            
               
            }
            

        }
    }

