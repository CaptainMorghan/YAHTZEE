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
        bool TwoOfAKind = false;
        bool ThreeOfAKind = false;
        
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
        int Counter = 0;
        bool AcesUsed = false;
        bool TwoUsed = false;
        bool ThreesUsed = false;
        bool FoursUsed = false;
        bool FivesUsed = false;
        bool SixesUsed = false;
        

        Dice dice;
        Dice diceTwo;
        Dice diceThree;
        Dice diceFour;
        Dice diceFive;

        int[] DiceArray = new int[5];

       



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
            lblOnes.Content = 0; //resets the values to 0 everytime the dice gets rolled so when you roll the dice it doesnt add numbers from the previous roll
            lblTwos.Content = 0;
            lblThrees.Content = 0;
            lblFours.Content = 0;
            lblFives.Content = 0;
            lblSoxes.Content = 0;
            lblThreeofaKind.Content = 0;
            lblFourOfaKind.Content = 0;
            lblFullHouse.Content = 0;
            lblSmallStraight.Content = 0;
            lblLargeStraight.Content = 0;
            lblYAHTZE.Content = 0;

            Dice = random.Next(1, 7);//picks number from 1-6 and sets the die value to it when the value is set the sprite for the dice will update to match the value 
            dice.dieValue = Dice;
            dice.drawDie();//Draws the die with the value generated above
            DiceArray[0] = Dice; //sets dice array to the generated number so we can find how many times a certin number appears on the dice


            Dice2 = random.Next(1, 7);
            diceTwo.dieValue = Dice2;
            diceTwo.drawDie();
            DiceArray[1] = Dice2;

            Dice3 = random.Next(1, 7);
            diceThree.dieValue = Dice3;
            diceThree.drawDie();
            DiceArray[2] = Dice3;

            Dice4 = random.Next(1, 7);
            diceFour.dieValue = Dice4;
            diceFour.drawDie();
            DiceArray[3] = Dice4;

            Dice5 = random.Next(1, 7);
            diceFive.dieValue = Dice5;
            diceFive.drawDie();
            DiceArray[4] = Dice5;
            
            
        }

        private void Ones_Click(object sender, RoutedEventArgs e)
        {
            Counter = 0; //resets counter to 0 everytime you click the button to prevent cheating by adding scores from previous dice rolls
            for
                 (int i = 0; i < DiceArray.Length; i++) //uses a loop and an array to check all the dice and then determine how many times
                                                        //a  number appears. say a number 1 shows on 4 dice then the counter would display 4 points
            {
                if (DiceArray[i] == 1)
                {
                    Counter++;
                    lblOnes.Content = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 2)
                {
                    Counter++;
                    lblTwos.Content = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 3)
                {
                    Counter++;
                    lblThrees.Content = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 4)
                {
                    Counter++;
                    lblFours.Content = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 5)
                {
                    Counter++;
                    lblFives.Content = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 6)
                {
                    Counter++;
                    lblSoxes.Content = Counter;
                }
            }
            //code for Three of a kind
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 1)
                    Counter++;
                if (Counter >= 3)
                {
                    lblThreeofaKind.Content = Counter * 1;
                    ThreeOfAKind = true;
                    AcesUsed = true;

                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 2)
                    Counter++;
                if (Counter >= 3)
                {
                    lblThreeofaKind.Content = Counter * 2;
                    ThreeOfAKind = true;
                    TwoUsed = true;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 3)
                    Counter++;
                if (Counter >= 3)
                {
                    lblThreeofaKind.Content = Counter * 3;
                    ThreeOfAKind = true;
                    ThreesUsed = true;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 4)
                    Counter++;
                if (Counter >= 3)
                {
                    lblThreeofaKind.Content = Counter * 4;
                    ThreeOfAKind = true;
                    FoursUsed = true;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 5)
                    Counter++;
                if (Counter >= 3)
                {
                    lblThreeofaKind.Content = Counter * 5;
                    ThreeOfAKind = true;
                    FivesUsed = true;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 6)
                    Counter++;
                if (Counter >= 3)
                {
                    lblThreeofaKind.Content = Counter * 6;
                    ThreeOfAKind = true;
                    SixesUsed = true;
                }
            }
            //Code for 4 of a Kind
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 1)
                    Counter++;
                if (Counter >= 4)
                {
                    lblFourOfaKind.Content = Counter * 1;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 2)
                    Counter++;
                if (Counter >= 4)
                {
                    lblFourOfaKind.Content = Counter * 2;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 3)
                    Counter++;
                if (Counter >= 4)
                {
                    lblFourOfaKind.Content = Counter * 3;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 4)
                    Counter++;
                if (Counter >= 4)
                {
                    lblFourOfaKind.Content = Counter * 4;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 5)
                    Counter++;
                if (Counter >= 4)
                {
                    lblFourOfaKind.Content = Counter * 5;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 6)
                    Counter++;
                if (Counter >= 4)
                {
                    lblFourOfaKind.Content = Counter * 6;
                }
            }
            //Code for Full House
            /* my original idea was to just  if(Three of a kind  == true && twoOfakind ==true) but I discovered that the computer is stuipid and would count a 3 of a kind and 2 of a kind as the same meaning 
             * if you had Three 2's a 4 and a 6 it would count it as a full house as it counted the 2's as both a 3 of a kind and a two of a kind. The soloution was to 
             * find a way to make it once the number of the 3 of a kind are used they can't get used again i just created a bool and made it true in the code for three of a kind
             * if it was true then the two of a kind must be made of of the remaining tow numbers
             */

            Counter = 0;
            if (ThreeOfAKind == true)
            {
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 1 && AcesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                        lblFullHouse.Content = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 2 && TwoUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                        lblFullHouse.Content = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 3 && ThreesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                        lblFullHouse.Content = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 4 && FoursUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                        lblFullHouse.Content = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 5 && FivesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                        lblFullHouse.Content = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 6 && SixesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                        lblFullHouse.Content = 25;
                    }
                }
                //small straight code
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (NumberOfAces >= 1 && NumberOfTwos >= 1)
                    {
                         if (NumberOfThrees >= 1 && NumberOfFours >= 1)
                            
                        {
                            lblSmallStraight.Content = 30;
                        }
                    }
                  else if (NumberOfTwos >= 1 && NumberOfThrees >= 1)
                    {
                        if (NumberOfFours >= 1 && NumberOfFives >= 1)
                        {
                            lblSmallStraight.Content = 30;
                        }
                    }
                  else if (NumberOfThrees >= 1 && NumberOfFours >= 1)
                    {
                        if (NumberOfFives >= 1 && NumberOfSixes >= 1)
                        {
                            lblSmallStraight.Content = 30;
                        }
                    }
                }
                    //Large straight code
                    Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 1)
                    {
                        Counter++;
                        if (Counter == 1)
                        {
                            AcesUsed = true;
                        }
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 2)
                    {
                        Counter++;
                        if (Counter == 1)
                        {
                            TwoUsed = true;
                        }
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 3)
                    {
                        Counter++;
                        if (Counter == 1)
                        {
                            ThreesUsed = true;
                        }
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 4)
                    {
                        Counter++;
                        if (Counter == 1)
                        {
                            FoursUsed = true;
                        }
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 5)
                    {
                        Counter++;
                        if (Counter == 1)
                        {
                            FivesUsed = true;
                        }
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 6)
                    {
                        Counter++;
                        if (Counter == 1)
                        {
                            SixesUsed = true;
                        }
                    }
                }
                {
                        if (AcesUsed == true && TwoUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true)
                    { 
                            lblLargeStraight.Content = 40;
                        }
                        else if(TwoUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true && SixesUsed == true)
                    {
                        lblLargeStraight.Content = 40;
                    }
                        
                    }
                    //Yahtzee Code
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 1)
                            Counter++;
                        if (Counter >= 5)
                        {
                            lblYAHTZE.Content = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 2)
                            Counter++;
                        if (Counter >= 5)
                        {
                            lblYAHTZE.Content = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 3)
                            Counter++;
                        if (Counter >= 5)
                        {
                            lblYAHTZE.Content = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 4)
                            Counter++;
                        if (Counter >= 5)
                        {
                            lblYAHTZE.Content = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 5)
                            Counter++;
                        if (Counter >= 5)
                        {
                            lblYAHTZE.Content = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 6)
                            Counter++;
                        if (Counter >= 5)
                        {
                            lblYAHTZE.Content = 50;
                        }
                    }
                }



            }









        
      }
    }

