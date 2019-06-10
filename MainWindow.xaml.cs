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
        bool MAcesUsed;
        bool MTwosUsed;
        bool MThreesUsed;
        bool MFoursUsed;
        bool MFivesUsed;
        bool MSixesUsed;
        bool MThreeOfAKindUsed;
        bool MFourOfAKindUsed;
        bool MFullHouseUsed;
        bool MSmStraightUsed;
        bool MLgStraightUsed;
        bool MYahtzeeUsed;
        bool MChanceUsed;
        bool MUpperSectionUsed;
        bool MLowerSectionUsed;
        bool MGRandTotalUsed;
        bool MBonus;
        bool UpperSection;
        int ChancePoints;
        bool FourOfAKind;
        bool FullHouse;
        bool Yahtzee;
        bool SmallStraight;
        bool LargeStraight;
        bool ScoreMade = true; //used to determin if the player has rolled the dice if they have they can't roll again until the player marks a score on the scorecard
        
        //Any bools using "M" before the name is being used to determin if the player has already filled in a square. This prevents a bug in which if you click a square and put in a variable
        //and then clicking it again after rolling the dice i would overlap differnt numbers.

        Dice dice;
        Dice diceTwo;
        Dice diceThree;
        Dice diceFour;
        Dice diceFive;
        int[] DiceArray = new int[5];
        Random random = new Random();
        Board board;
        public MainWindow()
        {
            InitializeComponent();
            //reposition later
            dice = new Dice(canvas, new Point(500, 10));
            diceTwo = new Dice(canvas, new Point(610, 10));
            diceThree = new Dice(canvas, new Point(720, 10));
            diceFour = new Dice(canvas, new Point(830, 10));
            diceFive = new Dice(canvas, new Point(940, 10));

            board = new Board(canvas);
            board.Roll_Dice();
            board.Rick_Roll();
            board.New_Game();
            board.High_Score();
        }
        //Spent three days trying to get straights to work not understanding why I couldnt get it to work I've discovered because I used the xUsed
        // int for calculating a full house some of the values were already set which interferes with the straight calculation. By moving them to a seperate button
        //for testing and setting them to false again has resolved this issue
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = Mouse.GetPosition(canvas);
            if (p.X > 730 && p.X < 830 && p.Y > 135 && p.Y < 160)
                //Code For Picking A Random Number From 1-6 for Each Die
            {
                if (ScoreMade == false)
                {
                    MessageBox.Show("You Must Make A Play Before Rolling Again");
                }
                if (ScoreMade == true)
                {
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
                    ScoreMade = false;
                }
             
            }
            else if (p.X > 300 && p.X < 450 && p.Y < 25)
                //Code For Aces
            {
                Counter = 0;
                //resets counter to 0 everytime you click the button to prevent cheating by adding scores from previous dice rolls
                if (MAcesUsed == true)
                {
                    MessageBox.Show("Sorry But You Already used this space");
                }
                else
                {

                    Counter = 0;       
                    for
                         (int i = 0; i < DiceArray.Length; i++) //uses a loop and an array to check all the dice and then determine how many times
                                                                //a  number appears. say a number 1 shows on 4 dice then the counter would display 4 points
                    {
                        if (DiceArray[i] == 1)
                        {
                            Counter++;
                            AcesPoints = Counter * 1;
                        }
                    }
                }
                board.addStringRemove(AcesPoints.ToString(), 300, 0);
                MAcesUsed = true;
                ScoreMade = true;
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 25 && p.Y < 50)
                //Code For Twos
            {
                Counter = 0;
                if (MTwosUsed == true)
                {
                    MessageBox.Show("Sorry But You Already Used This Space");
                }
                else
                {
                    for
                         (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 2)
                        {
                            Counter++;
                            TwosPoints = Counter * 2;
                        }
                    }
                }
                board.addStringRemove(TwosPoints.ToString(), 300, 25);
                MTwosUsed = true;
                ScoreMade = true;
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 50 && p.Y < 75)
                //Code For Threes
            {
                Counter = 0;
                if (MThreesUsed == true)
                {
                    MessageBox.Show("Take a Hint. This Space Is Already Used");
                }
                for
                 (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 3)
                    {
                        Counter++;
                        ThreesPoints = Counter * 3;
                    }
                }
                board.addStringRemove(ThreesPoints.ToString(), 300, 50);
                MThreesUsed = true;
                ScoreMade = true;
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 75 && p.Y < 100)
                //Code For Fours
            {
                Counter = 0;
                if (MFoursUsed == true)
                {
                    MessageBox.Show("FYI You Already Scored Here");
                }
                for
                     (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 4)
                    {
                        Counter++;
                        FoursPoints = Counter * 4;
                    }
                }
                board.addStringRemove(FoursPoints.ToString(), 300, 75);
                MFoursUsed = true;
                ScoreMade = true;
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 100 && p.Y < 125)
                //Code For Fives
            {
                Counter = 0;
                if (MFivesUsed == true)
                {
                    MessageBox.Show("Comeone Give up already. (You Already Used This Space)");
                }
                for
         (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 5)
                    {
                        Counter++;
                        FivesPoints = Counter * 5;
                    }
                }
                board.addStringRemove(FivesPoints.ToString(), 300, 100);
                MFivesUsed = true;
                ScoreMade = true;
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 125 && p.Y < 150)
                //Code For Sixes
            {
                Counter = 0;
                if (MSixesUsed == true)
                {
                    MessageBox.Show("We Get It You Like To Cheat(You Already Used This Space)");
                }
                for
                (int i = 0; i < DiceArray.Length; i++)
                {
                    if (DiceArray[i] == 6)
                    {
                        Counter++;
                        SixesPoints = Counter * 6;
                    }
                }
                board.addStringRemove(SixesPoints.ToString(), 300, 125);
                MSixesUsed = true;
                ScoreMade = true;
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 150 && p.Y < 175)
                //Code For Upper Section Score Before Bonus is added
            {
                if (MAcesUsed == true && MTwosUsed == true && MThreesUsed == true && MFoursUsed == true && MFivesUsed == true && MSixesUsed == true)
                {
                    UpperSectionScore = AcesPoints + TwosPoints + ThreesPoints + FoursPoints + FivesPoints + SixesPoints;
                    board.addString(UpperSectionScore.ToString(), 300, 150);
                    UpperSection = true;
                }
                else
                {
                    MessageBox.Show("Fill Out The Above Spaces Before you Calculate Your Score");
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 175 && p.Y < 200)
                //Code For Bonus
            {
                if (UpperSectionScore > 63 && UpperSection == true)
                {
                    Bonus = 35;
                    MBonus = true;
                }
                else if (UpperSectionScore < 63 && UpperSection == true)
                {
                    Bonus = 0;
                    MBonus = true;
                }
                board.addStringRemove(Bonus.ToString(), 300, 175);
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 200 && p.Y < 225)
                //Code for Upper Section Total
            {
                if (UpperSection == true)
                    if (MBonus == false)
                    {
                        MessageBox.Show("You must Calculate Bonus Before You Click this");
                    }
                    else
                    {
                        int UpperTotalScore = UpperSectionScore + Bonus;
                        board.addStringRemove(UpperTotalScore.ToString(), 300, 200);
                    }
                else
                {
                    MessageBox.Show("You Must First Complete The Above Spaces Before you Calculate Score");
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 225 && p.Y < 250)
                //Code For Three of A Kind
            {
                if (MThreeOfAKindUsed == true)
                {
                    MessageBox.Show("You Already Used this Space (You Daft Or Somthing?)");
                }
                else
                {
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 1)
                        {
                            Counter++;
                        }
                        if (Counter >= 3)
                        {
                            ThreeOfAKindPoints = Counter * 1;
                            ThreeOfAKind = true;
                            AcesUsed = true;
                        }
                        }
                        MThreeOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 2)
                        {
                            Counter++;
                        }
                            if (Counter >= 3)
                            {
                                ThreeOfAKindPoints = Counter * 2;
                                ThreeOfAKind = true;
                                TwosUsed = true;
                            }
                    }
                    MThreeOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 3)
                        {
                            Counter++;
                        }
                            if (Counter >= 3)
                            {
                                ThreeOfAKindPoints = Counter * 3;
                                ThreeOfAKind = true;
                                ThreesUsed = true;
                            }
                    }
                    MThreeOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 4)
                        {
                            Counter++;
                        }
                            if (Counter >= 3)
                            {
                                ThreeOfAKindPoints = Counter * 4;
                                ThreeOfAKind = true;
                                FoursUsed = true;
                            }
                    }
                    MThreeOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 5)
                        {
                            Counter++;
                        }
                            if (Counter >= 3)
                            {
                                ThreeOfAKindPoints = Counter * 5;
                                ThreeOfAKind = true;
                                FivesUsed = true;
                            }
                    }
                    MThreeOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 6)
                        {
                            Counter++;
                        }
                            if (Counter >= 3)
                            {
                                ThreeOfAKindPoints = Counter * 6;
                                ThreeOfAKind = true;
                                SixesUsed = true;
                            }
                    }
                    MThreeOfAKindUsed = true;
                    if (ThreeOfAKind == true)
                    {
                        board.addStringRemove(ThreeOfAKindPoints.ToString(), 300, 225);
                        ScoreMade = true;
                    }
                    else
                    {
                        board.addStringRemove("0", 300, 225);
                        ScoreMade = true;
                    }
                    //Soved issue where 0 would overlap numbers. Because I had board.addString(ThreeOfAKindPoints.ToString(), 300, 225); written 6 times one for each number when the code ran it would
                    //Display the correct number but overlap 0 overtop of it. the issue was it was running all 6 instances at the same time so while one of them would = what it should the other 5 would spit out 0 as they are false;
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 250 && p.Y < 275)
            {
                if (MFourOfAKindUsed == true)
                {
                    MessageBox.Show("If You Want To Cheat Then Pray To Your Code Gobblin Overlords ( Space Is Already Used)");
                }
                else
                {
                    //Code for 4 of a Kind
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {

                        if (DiceArray[i] == 1)
                            Counter++;
                        if (Counter >= 4)
                        {
                            FourOfAKindPoints = Counter * 1;
                            FourOfAKind = true;
                        }
                    }
                    MFourOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 2)
                            Counter++;
                        if (Counter >= 4)
                        {
                            FourOfAKindPoints = Counter * 2;
                            FourOfAKind = true;
                        }
                    }
                    MFourOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 3)
                            Counter++;
                        if (Counter >= 4)
                        {
                            FourOfAKindPoints = Counter * 3;
                            FourOfAKind = true;
                        }
                    }
                    MFourOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 4)
                            Counter++;
                        if (Counter >= 4)
                        {
                            FourOfAKindPoints = Counter * 4;
                            FourOfAKind = true;
                        }
                    }
                    MFourOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 5)
                            Counter++;
                        if (Counter >= 4)
                        {
                            FourOfAKindPoints = Counter * 5;
                            FourOfAKind = true;
                        }
                    }
                    MFourOfAKindUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 6)
                            Counter++;
                        if (Counter >= 4)
                        {
                            FourOfAKindPoints = Counter * 6;
                            FourOfAKind = true;
                        }
                    }
                    MFourOfAKindUsed = true;
                    if (FourOfAKind == true)
                    {
                        board.addStringRemove(FourOfAKindPoints.ToString(), 300, 250);
                        ScoreMade = true;
                    }
                    else
                    {
                        board.addStringRemove("0", 300, 250);
                        ScoreMade = true;
                    }
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 275 && p.Y < 300)
            {
                if (MFullHouseUsed == true)
                {
                    MessageBox.Show("I'm getting writers block trying to think of new ways to tell you that this space is already used");
                }
                else
                {
                    //Code for Full House
                    /* my original idea was to just  if(Three of a kind  == true && twoOfakind ==true) but I discovered that the computer is stuipid and would count a 3 of a kind and 2 of a kind as the same meaning 
                     * if you had Three 2's a 4 and a 6 it would count it as a full house as it counted the 2's as both a 3 of a kind and a two of a kind. The soloution was to 
                     * find a way to make it once the number of the 3 of a kind are used they can't get used again i just created a bool and made it true in the code for three of a kind
                     * if it was true then the two of a kind must be made of of the remaining tow numbers
                     * New Bug Discovered where Full House will = 0 when it shouldnt I've spend hours trying to fix it but the issue is inconsistant making solving near impossible
                     */
                    ThreeOfAKind = false;
                       
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 1)
                            Counter++;
                        if (Counter >= 3)
                        {
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
                            ThreeOfAKind = true;
                            SixesUsed = true;
                        }
                    }
                    if (ThreeOfAKind == true)
                    {
                        Counter = 0;
                        for (int i = 0; i < DiceArray.Length; i++)
                        {
                            if (DiceArray[i] == 1 && AcesUsed == false)
                                Counter++;
                            if (Counter == 2)
                            {
                                FullHousePoints = 25;
                                FullHouse = true;
                            }
                        }
                        MFullHouseUsed = true;
                        Counter = 0;
                        for (int i = 0; i < DiceArray.Length; i++)
                        {
                            if (DiceArray[i] == 2 && TwosUsed == false)
                                Counter++;
                            if (Counter == 2)
                            {
                                FullHousePoints = 25;
                                FullHouse = true;
                            }
                        }
                        MFullHouseUsed = true;
                        Counter = 0;
                        for (int i = 0; i < DiceArray.Length; i++)
                        {
                            if (DiceArray[i] == 3 && ThreesUsed == false)
                                Counter++;
                            if (Counter == 2)
                            {
                                FullHousePoints = 25;
                                FullHouse = true;
                            }
                        }
                        MFullHouseUsed = true;
                        Counter = 0;
                        for (int i = 0; i < DiceArray.Length; i++)
                        {
                            if (DiceArray[i] == 4 && FoursUsed == false)
                                Counter++;
                            if (Counter == 2)
                            {
                                FullHousePoints = 25;
                                FullHouse = true;
                            }
                        }
                        MFullHouseUsed = true;
                        Counter = 0;
                        for (int i = 0; i < DiceArray.Length; i++)
                        {
                            if (DiceArray[i] == 5 && FivesUsed == false)
                                Counter++;
                            if (Counter == 2)
                            {
                                FullHousePoints = 25;
                                FullHouse = true;
                            }
                        }
                        MFullHouseUsed = true;
                        Counter = 0;
                        for (int i = 0; i < DiceArray.Length; i++)
                        {
                            if (DiceArray[i] == 6 && SixesUsed == false)
                                Counter++;
                            if (Counter == 2)
                            {
                                FullHousePoints = 25;
                                FullHouse = true;
                            }
                        }
                        MFullHouseUsed = true;
                    }
                }
                if ( FullHouse == true)
                {
                    board.addStringRemove(FullHousePoints.ToString(), 300, 275);
                    ScoreMade = true;
                }
                else if (FullHouse == false)
                {
                    board.addStringRemove("0", 300, 275);
                    ScoreMade = true;
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 300 && p.Y < 325)
            {
                if (MSmStraightUsed == true)
                {
                    MessageBox.Show("Get On With it");
                }
                else
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
                        SmallStraightPoints = 30;
                        SmallStraight = true;
                        MSmStraightUsed = true;
                    }
                    if (TwosUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true)
                    {
                        SmallStraightPoints = 30;
                        SmallStraight = true;
                        MSmStraightUsed = true;
                    }
                    if (ThreesUsed == true && FoursUsed == true && FivesUsed == true && SixesUsed == true)
                    {
                        SmallStraightPoints = 30;
                        SmallStraight = true;
                        MSmStraightUsed = true;
                    }
                }
                if (SmallStraight == true)
                {
                    board.addStringRemove(SmallStraightPoints.ToString(), 300, 300);
                    ScoreMade = true;
                }
                else
                {
                    board.addStringRemove("0", 300, 300);
                    ScoreMade = true;
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 325 && p.Y < 350)
            {
                if (MLgStraightUsed == true)
                {
                    MessageBox.Show("Ask for me tomorrow, and you shall find me a grave man. I am peppered, I warrant, for this world. A plague o' both your houses!");
                }
                else
                {
                    //Large Straight Code
                    if (AcesUsed == true && TwosUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true)
                    {
                        LargeStarightPoints = 40;
                        LargeStraight = true;
                        MLgStraightUsed = true;
                    }
                    if (TwosUsed == true && ThreesUsed == true && FoursUsed == true && FivesUsed == true && SixesUsed == true)
                    {
                        LargeStarightPoints = 40;
                        LargeStraight = true;
                        MLgStraightUsed = true;
                    }
                }
                if ( LargeStraight == true)
                {
                    board.addStringRemove(LargeStarightPoints.ToString(), 300, 325);
                    ScoreMade = true;
                }
                else
                {
                    board.addStringRemove("0", 300, 325);
                    ScoreMade = true;
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 350 && p.Y < 375)
            {
                if (MYahtzeeUsed == true)
                {
                    MessageBox.Show("Press Secret to get Rick Rolled");
                }
                else
                {
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
                            YahtzeePoints = 50;
                            Yahtzee = true;
                        }
                    }
                    MYahtzeeUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 2)
                            Counter++;
                        if (Counter >= 5)
                        {
                            YahtzeePoints = 50;
                            Yahtzee = true;
                        }
                    }
                    MYahtzeeUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 3)
                            Counter++;
                        if (Counter >= 5)
                        {
                            YahtzeePoints = 50;
                            Yahtzee = true;
                        }
                    }
                    MYahtzeeUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 4)
                            Counter++;
                        if (Counter >= 5)
                        {
                            YahtzeePoints = 50;
                            Yahtzee = true;
                        }
                    }
                    MYahtzeeUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 5)
                            Counter++;
                        if (Counter >= 5)
                        {
                            YahtzeePoints = 50;
                            Yahtzee = true;
                        }
                    }
                    MYahtzeeUsed = true;
                    Counter = 0;
                    for (int i = 0; i < DiceArray.Length; i++)
                    {
                        if (DiceArray[i] == 6)
                            Counter++;
                        if (Counter >= 5)
                        {
                            YahtzeePoints = 50;
                            Yahtzee = true;
                        }
                    }
                    MYahtzeeUsed = true;
                }
                if ( Yahtzee == true)
                {
                    board.addStringRemove(YahtzeePoints.ToString(), 300, 350);
                    ScoreMade = true;
                }
                else
                {
                    board.addStringRemove("0", 300, 350);
                    ScoreMade = true;
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 375 && p.Y < 400)
                //Chance Code
                if (MChanceUsed == true)
                {
                    MessageBox.Show("All that glitters is not gold");
                }
                else
                {
                    ChancePoints = Dice + Dice2 + Dice3 + Dice4 + Dice5;
                    board.addStringRemove(ChancePoints.ToString(), 300, 375);
                    MChanceUsed = true;
                    ScoreMade = true;
                }
            else if (p.X > 300 && p.X < 450 && p.Y > 400 && p.Y < 425)
                //Upper Section Score Code
                if (MUpperSectionUsed == true)
                {
                    MessageBox.Show("Complete The Upper Section Before Clicking this");
                }
                else
                {
                    board.addStringRemove(UpperSectionScore.ToString(), 300, 400);
                    MUpperSectionUsed = true;
                }
            else if (p.X > 300 && p.X < 450 && p.Y > 425 && p.Y < 450)
               //Lower Section Score Code
            {
                if (MLowerSectionUsed == true)
                {
                    MessageBox.Show("You Must Fill out the lower Section before Clicking this");
                }
                else
                {
                    LowerSectionScore = ThreeOfAKindPoints + FourOfAKindPoints + FullHousePoints + SmallStraightPoints + LargeStarightPoints + YahtzeePoints + ChancePoints;
                    board.addStringRemove(LowerSectionScore.ToString(), 300, 425);
                    MLowerSectionUsed = true;
                }
            }
            else if (p.X > 300 && p.X < 450 && p.Y > 450 && p.Y < 475)
                //Grand Total Code
            {
                if (MGRandTotalUsed == true)
                {
                    MessageBox.Show("You Must Complete UpperSection and Lower Section Totals Before Clicking This");
                }
                else
                {
                    GrandTotal = UpperSectionScore + LowerSectionScore;
                    board.addStringRemove(GrandTotal.ToString(), 300, 450);
                    MGRandTotalUsed = true;
                }
            }
            else if (p.X > 730 && p.X < 830 && p.Y > 300 && p.Y < 325)
                //Code For Surprise
            {
                int Surprise;
                Surprise = random.Next(1, 12);
                if (Surprise ==  1)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
                }
                else if (Surprise == 2)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=rY-FJvRqK0E");
                }
                else if(Surprise == 3)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=LhjMOtaBqVc&t=1612s");
                }
                else if (Surprise == 4)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=pH1Zaef7XXA");
                }
                else if (Surprise == 5)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=3cwDBEaNSe8");
                }
                else if (Surprise == 6)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=pcnFbCCgTo4");
                }
                else if (Surprise == 7)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=RXnM1uHhsOI");
                }
                else if (Surprise == 8)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=Vqbk9cDX0l0&list=WL&index=40&t=0s");
                }
                else if (Surprise == 9)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=knxgMae1_pM&list=WL&index=41");
                }
                else if (Surprise == 10)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=W4c_l0s814g&list=WL&index=60");
                }
                else if (Surprise == 11)
                {
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=KzsQONYBvKc&list=WL&index=59");
                }

            }
            else if (p.X > 730 && p.X < 830 && p.Y > 200 && p.Y < 225)
                //Code For New Game
            {
              
                canvas.Children.RemoveRange(129, canvas.Children.Count - 129);
                ScoreMade = true;
                MAcesUsed = false;
                MTwosUsed = false;
                MThreesUsed = false;
                MFoursUsed = false;
                MFivesUsed = false;
                MSixesUsed = false;
                MUpperSectionUsed = false;
                MBonus = false;
                MThreeOfAKindUsed = false;
                MFourOfAKindUsed = false;
                MFullHouseUsed = false;
                MSmStraightUsed = false;
                MLgStraightUsed = false;
                MYahtzeeUsed = false;
                MChanceUsed = false;
                MLowerSectionUsed = false;
                MGRandTotalUsed = false;
                //Failed attempt at a HighScore Feature
                /*
                int HighScore;
                string HighScoreS;
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader("HighScore.txt");


                    while (!sr.EndOfStream)
                    {
                        HighScoreS = sr.ReadLine();
                        board.addString(HighScoreS, 0, 500);
                    }
                    


                } //end try
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }//end catch
                if (GrandTotal > HighScore)
                {
                    try
                    {
                        System.IO.StreamWriter sw =  new System.IO.StreamWriter();
                        sw.WriteLine(GrandTotal);
                        sw.Flush();
                        sw.Close();
                    }//end try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }//end catch
                    */
                }
            } 
        }
    }
        
    





    

        

  
    

