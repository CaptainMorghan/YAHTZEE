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
        bool ThreeOfAKind = false;
        bool AcesUsed = false;
        bool TwosUsed = false;
        bool ThreesUsed = false;
        bool FoursUsed = false;
        bool FivesUsed = false;
        bool SixesUsed = false;
        int Counter;
        int UpperSectionScore;
        int LowerSectionScore;
        int Bonus = 35;
        int GrandTotal;
        int AcesPoints;
        int TwosPoints;
        int ThreesPoints;
        int FoursPoints;
        int FivesPoints;
        int SixesPoints;
        int ThreeOfAKindPoints;
        int FourOfAKindPoints;
        int FullHousePoints;
        int SmallStraightPoints;
        int LargeStarightPoints;
        int YahtzeePoints;



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
            //lblAces.Content = 0; //resets the values to 0 everytime the dice gets rolled so when you roll the dice it doesnt add numbers from the previous roll
           // lblTwos.Content = 0;
           // lblThrees.Content = 0;
            //lblFours.Content = 0;
          // lblFives.Content = 0;
           // lblSoxes.Content = 0;
          //  lblThreeofaKind.Content = 0;
           // lblFourOfaKind.Content = 0;
            //lblFullHouse.Content = 0;
          //  lblSmallStraight.Content = 0;
            //lblLargeStraight.Content = 0;
         //   lblYAHTZE.Content = 0;

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
                  //  lblAces.Content = Counter;
                    AcesPoints = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 2)
                {
                    Counter++;
                  //  lblTwos.Content = Counter;
                    TwosPoints = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 3)
                {
                    Counter++;
                    //lblThrees.Content = Counter;
                    ThreesPoints = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 4)
                {
                    Counter++;
                 //   lblFours.Content = Counter;
                    FoursPoints = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 5)
                {
                    Counter++;
                 //   lblFives.Content = Counter;
                    FivesPoints = Counter;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 6)
                {
                    Counter++;
                    //lblSoxes.Content = Counter;
                    SixesPoints = Counter;
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
                  //  lblThreeofaKind.Content = Counter * 1;
                    ThreeOfAKindPoints = Counter * 1;
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
                  //  lblThreeofaKind.Content = Counter * 2;
                    ThreeOfAKindPoints = Counter * 2;
                    ThreeOfAKind = true;
                    TwosUsed = true;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 3)
                    Counter++;
                if (Counter >= 3)
                {
                  //  lblThreeofaKind.Content = Counter * 3;
                    ThreeOfAKindPoints = Counter * 3;
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
                 //   lblThreeofaKind.Content = Counter * 4;
                    ThreeOfAKindPoints = Counter * 4;
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
                  //  lblThreeofaKind.Content = Counter * 5;
                    ThreeOfAKindPoints = Counter * 5;
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
                 //   lblThreeofaKind.Content = Counter * 6;
                    ThreeOfAKindPoints = Counter * 6;
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
               //     lblFourOfaKind.Content = Counter * 1;
                    FourOfAKindPoints = Counter * 1;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 2)
                    Counter++;
                if (Counter >= 4)
                {
             //       lblFourOfaKind.Content = Counter * 2;
                    FourOfAKindPoints = Counter * 2;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 3)
                    Counter++;
                if (Counter >= 4)
                {
                   // lblFourOfaKind.Content = Counter * 3;
                    FourOfAKindPoints = Counter * 3;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 4)
                    Counter++;
                if (Counter >= 4)
                {
                  //  lblFourOfaKind.Content = Counter * 4;
                    FourOfAKindPoints = Counter * 4;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 5)
                    Counter++;
                if (Counter >= 4)
                {
           //         lblFourOfaKind.Content = Counter * 5;
                    FourOfAKindPoints = Counter * 5;
                }
            }
            Counter = 0;
            for (int i = 0; i < DiceArray.Length; i++)
            {

                if (DiceArray[i] == 6)
                    Counter++;
                if (Counter >= 4)
                {
                 //   lblFourOfaKind.Content = Counter * 6;
                    FourOfAKindPoints = Counter * 6;
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
                    //    lblFullHouse.Content = 25;
                        FullHousePoints = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 2 && TwosUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                      //  lblFullHouse.Content = 25;
                        FullHousePoints = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 3 && ThreesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                   //     lblFullHouse.Content = 25;
                        FullHousePoints = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 4 && FoursUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                     //   lblFullHouse.Content = 25;
                        FullHousePoints = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 5 && FivesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                       // lblFullHouse.Content = 25;
                        FullHousePoints = 25;
                    }
                }
                Counter = 0;
                for (int i = 0; i < DiceArray.Length; i++)
                {

                    if (DiceArray[i] == 6 && SixesUsed == false)
                        Counter++;
                    if (Counter == 2)
                    {
                      //  lblFullHouse.Content = 25;
                        FullHousePoints = 25;
                    }
                }
                
                //Yahtzee Code
                //Due to there being 7776 combinations with the 5 dice only one of which can be a yahtzee it's likally you will never get one in your average game
                //Despite this I know that the code works as I set all the dice equal to 1 and ran the program and it showed  that it can recognize a yatzee
                Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 1)
                            Counter++;
                        if (Counter >= 5)
                        {
                         //   lblYAHTZE.Content = 50;
                        YahtzeePoints = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 2)
                            Counter++;
                        if (Counter >= 5)
                        {
                           // lblYAHTZE.Content = 50;
                        YahtzeePoints = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 3)
                            Counter++;
                        if (Counter >= 5)
                        {
                          //  lblYAHTZE.Content = 50;
                        YahtzeePoints = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 4)
                            Counter++;
                        if (Counter >= 5)
                        {
                       //     lblYAHTZE.Content = 50;
                        YahtzeePoints = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 5)
                            Counter++;
                        if (Counter >= 5)
                        {
                   //         lblYAHTZE.Content = 50;
                        YahtzeePoints = 50;
                        }
                    }
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 6)
                            Counter++;
                        if (Counter >= 5)
                        {
                    //        lblYAHTZE.Content = 50;
                        YahtzeePoints = 50;
                        }
                    }
                }



            }
        //Spent three days trying to get straights to work not understanding why I couldnt get it to work I've discovered because I used the xUsed
        // int for calculating a full house some of the values were already set which interferes with the straight calculation. By moving them to a seperate button
        //for testing and setting them to false again has resolved this issue

        private void StraightTest_Click(object sender, RoutedEventArgs e)
        {
            //Small Straight Code
            AcesUsed = false;
            TwosUsed = false;
            ThreesUsed = false;
            FoursUsed = false;
            FivesUsed = false;
            SixesUsed = false;

            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 1)
                {
                    Counter++;
                    if (Counter == 1 || Counter == 2)
                    {
                        AcesUsed = true;
                    }
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 2)
                {
                    Counter++;
                    if (Counter == 1 || Counter == 2)
                    {
                        TwosUsed = true;
                    }
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 3)
                {
                    Counter++;
                    if (Counter == 1 || Counter == 2)
                    {
                        ThreesUsed = true;
                    }
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 4)
                {
                    Counter++;
                    if (Counter == 1 || Counter == 2)
                        FoursUsed = true;
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 5)
                {
                    Counter++;
                    if (Counter == 1 || Counter == 2)
                    {
                        FivesUsed = true;
                    }
                }
            }
            Counter = 0;
            for
                 (int i = 0; i < DiceArray.Length; i++)
            {
                if (DiceArray[i] == 6)
                {
                    Counter++;
                    if (Counter == 1 || Counter == 2)
                    {
                        SixesUsed = true;
                    }
                }
            }
            if (AcesUsed == true && TwosUsed == true && ThreesUsed == true && FoursUsed == true)
            {
             //   lblSmallStraight.Content = 30;
                SmallStraightPoints = 30;
            }
            if (TwosUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true)
            {
             //   lblSmallStraight.Content = 30;
                SmallStraightPoints = 30;
            }
            if (ThreesUsed == true && FoursUsed == true && FivesUsed == true && SixesUsed == true)
            {
          //      lblSmallStraight.Content = 30;
                SmallStraightPoints = 30;
            }
            //Large Straight Code
            if (AcesUsed == true && TwosUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true)
            {
           //     lblLargeStraight.Content = 40;
                LargeStarightPoints = 40;
            }
            if (TwosUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true && SixesUsed == true)
            {
            //    lblLargeStraight.Content = 40;
                SmallStraightPoints = 40;
            }
        }

        private void TotalScore_Click(object sender, RoutedEventArgs e)
        {
            //Upper section code
            UpperSectionScore = AcesPoints + TwosPoints + ThreesPoints + FoursPoints + FivesPoints + SixesPoints;
            if (UpperSectionScore > 63)
            {
                Bonus = 35;
            }
            else
            {
                Bonus = 0;
            }
            LowerSectionScore = ThreeOfAKindPoints + FourOfAKindPoints + FullHousePoints + SmallStraightPoints + LargeStarightPoints + YahtzeePoints;
            GrandTotal = UpperSectionScore + Bonus + LowerSectionScore;
         //   lblTotalPoints.Content = GrandTotal;

        }
    }
    }

