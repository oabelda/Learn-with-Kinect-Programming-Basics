using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TFG_AIK_OscarJoseAbeldaFernandez.Experiences;
using TFG_AIK_OscarJoseAbeldaFernandez.Utilities;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences
{
    /// <summary>
    /// Interaction logic for BinaryConvert.xaml
    /// </summary>
    public partial class DecimalConvert : UserControl, ExperienceInterface
    {
        // settings
        private const int TicksPerSecond = 10; // Trigger's ticks per second
        private int secPenalizationOnFail {
            get{
                return 10 + 10 * actualLevel;
            }
        }
        private TimeSpan checkTime = TimeSpan.FromSeconds(3); // Amount of time the checkMark stays
        private const long timeInSeconds = 120; // Amount of time to play, in seconds
        private int levelRaiseRate { // The amount of right anwers to pass level
            get
            {
                if (actualLevel == 0)
                return 4;
                else if (actualLevel == 1)
                    return 2;
                else return 1;
            }
        }

        // controllers
        private readonly DispatcherTimer timer = new DispatcherTimer(); // Timer to handle the experience ticks events
        private Random rnd = new Random(); // Random variable shared for all random needs
        private bool isGripinInteraction = false; //Variable to track GripInterationStatus
        private Border hoverCell = null;
        private int questionValue; // The actual question value

        // knobs
        private int errorsNumber;
        private int successNumber;
        /// <summary> Saves the passed time </summary>
        private long ClockTime;

        private int actualLevel = 0;

        public DecimalConvert(object param)
        {
            InitializeComponent();

            foreach (Border number in NumbersGrid.Children) {
                KinectRegion.SetIsGripTarget(number, true);
                KinectRegion.AddHandPointerGripHandler(number, this.OnHandPointerGrip);
            }

            KinectRegion.AddQueryInteractionStatusHandler(this, this.OnQuery);
            KinectRegion.AddHandPointerGripReleaseHandler(this, this.OnHandPointerGripRealease);
            KinectRegion.AddHandPointerMoveHandler(this, OnHandPointerMove);

            PromptMenu.ParentContent = this;
            WelcomeMenu.ParentContent = this;
            WelcomeMenu.Text.Text = (string)param;


            this.timer.Interval = TimeSpan.FromMilliseconds(1000 / TicksPerSecond);
            this.timer.Tick += (s, args) =>
            {
                this.timer.Stop();
                Update();
            };

            Retry();

            WelcomeMenu.Show();
        }

        // Main Commands

        public void BackToMenu()
        {
            this.BeginStoryboard((Storyboard)this.FindResource("UnloadStoryboard"));
        }
        public void Retry()
        {
            Retry(actualLevel);
        }
        public void Retry(int actualLevel)
        {
            this.actualLevel = actualLevel;

            // Reset game-counters
            ClockTime = timeInSeconds * TicksPerSecond; // time
            errorsNumber = 0; // errors
            successNumber = 0;

            // Clear the panel
            Griped.Child = null;
            Griped.Visibility = Visibility.Hidden;

            newQuestion();

            Play();
        }
        public void Play()
        {
            this.timer.Start();
        }
        public void Pause()
        {
            this.timer.Stop();
        }
        private void EndExperience()
        {
            Pause();

            ScoreArchivementsText.Text = "";
            ScoreArchivementsText.Text += (string)this.FindResource("FullTime") + ": " + ClockConverter.ticksToTenthsSecondsMinutesFormat(timeInSeconds * TicksPerSecond, TicksPerSecond, Properties.Resources.timeFormat);
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("NErrors") + ": " + errorsNumber;
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("Penalization") + ": " + secPenalizationOnFail + "s x " + errorsNumber + " " + (string)this.FindResource("errors") + " = " + errorsNumber * secPenalizationOnFail + "s";
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("TotalTimePlayed") + ": " + ClockConverter.ticksToTenthsSecondsMinutesFormat((timeInSeconds - (secPenalizationOnFail * errorsNumber)) * TicksPerSecond, TicksPerSecond, Properties.Resources.timeFormat);

            ScoreFinalTimeText.Text = successNumber + " " + (string)this.FindResource("hit") + "s";

            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(ScoreView, "Normal", false);
            VisualStateManager.GoToElementState(ScoreView, "FadeIn", true);
        }

        // Events

        private void Update()
        {
            ClockTime--;
            TimeCounter.Text = ClockConverter.ticksToTenthsSecondsMinutesFormat(ClockTime, 
                TicksPerSecond, Properties.Resources.timeFormat);
            if (ClockTime <= 0) EndExperience();
            else this.timer.Start();
        }

        private void OnHandPointerGrip(object sender, HandPointerEventArgs e)
        {
            if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;

            Griped.Child = UIElementHelper.DeepClone<TextBlock>((TextBlock)((Border)sender).Child);
            ((TextBlock)Griped.Child).FontSize = 175;
            Griped.Visibility = Visibility.Visible;

        }
        private void OnHandPointerGrip2(object sender, HandPointerEventArgs e)
        {
            if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;

            ((Border)((TextBlock)sender).Parent).Child = null;
            Griped.Child = (TextBlock)sender;
            ((TextBlock)Griped.Child).FontSize = 175;
            Griped.Visibility = Visibility.Visible;
            KinectRegion.SetIsGripTarget((TextBlock)sender, false);
            KinectRegion.RemoveHandPointerGripHandler((TextBlock)sender, this.OnHandPointerGrip2);

        }
        private void OnHandPointerGripRealease(object sender, HandPointerEventArgs e)
        {
            if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;
            if (Griped.Visibility == Visibility.Visible)
            {
                // UnGrip
                Griped.Visibility = Visibility.Hidden;
                ((TextBlock)Griped.Child).FontSize = 75;
                TextBlock griped = (TextBlock)Griped.Child;
                Griped.Child = null;

                if (hoverCell != null) // If the gripedQuestion is over a cell
                {
                    hoverCell.Child = griped;
                    KinectRegion.SetIsGripTarget(griped, true);
                    KinectRegion.AddHandPointerGripHandler(griped, this.OnHandPointerGrip2);
                    // Check if the answer is full and correct
                    int actualAnswerIs = ReadAnswer();
                    if (actualAnswerIs > 0) answer(actualAnswerIs);
                }
            }
        }
        private void OnQuery(object sender, QueryInteractionStatusEventArgs handPointerEventArgs)
        {
            //If a grip detected change the cursor image to grip
            if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.Grip)
            {
                isGripinInteraction = true;
                handPointerEventArgs.IsInGripInteraction = true;
            }

           //If Grip Release detected change the cursor image to open
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.GripRelease)
            {
                isGripinInteraction = false;
                handPointerEventArgs.IsInGripInteraction = false;
            }

            //If no change in state do not change the cursor
            else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.None)
            {
                handPointerEventArgs.IsInGripInteraction = isGripinInteraction;
            }

            handPointerEventArgs.Handled = true;
        }
        private void OnHandPointerMove(object sender, HandPointerEventArgs e)
        {
            if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;

            Point handPos = e.HandPointer.GetPosition(grid);

            foreach (UIElement child in ConversionGrid.Children)
            {
                try
                {
                    Border cell = (Border)child;

                    Point cellOrigin = cell.TranslatePoint(new Point(0, 0), grid);
                    if ((cell.IsEnabled) &&
                        (cellOrigin.X <= handPos.X && (cellOrigin.X + cell.ActualWidth) >= handPos.X) &&
                        (cellOrigin.Y <= handPos.Y && (cellOrigin.Y + cell.ActualHeight) >= handPos.Y)
                        )
                    {
                        TransformGroup transformAnimation = new TransformGroup();
                        transformAnimation.Children.Add(new ScaleTransform() { ScaleX = 1.1, ScaleY = 1.1 });
                        cell.RenderTransform = transformAnimation;
                        hoverCell = cell;
                        break;
                    }
                    else
                    {
                        TransformGroup transformAnimation = new TransformGroup();
                        cell.RenderTransform = transformAnimation;
                        hoverCell = null;
                    }
                }
                catch { } // Not a Border Child
            }

            if (Griped.Visibility == Visibility.Hidden) return;

            gripedNumberPosition = handPos;

        }
        private void OnUnloadedStoryboardCompleted(object sender, System.EventArgs e)
        {
            var parent = (Panel)this.Parent;
            parent.Children.Remove(this);
        }
        private void OnScoreView_ReplayClick(object sender, RoutedEventArgs e)
        {
            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(ScoreView, "Normal", false);
            VisualStateManager.GoToElementState(ScoreView, "FadeOut", true);
            Retry(actualLevel);
        }
        private void OnScoreView_BackClick(object sender, RoutedEventArgs e)
        {
            BackToMenu();
        }

        // Auxiliary Methods

        private void newQuestion()
        {
            int q; // new Question
            int pq = questionValue; // Previous Question
            do
            {
                q = rnd.Next(1, ((int)Math.Pow(2, (QuestionGrid.ColumnDefinitions.Count))) - 1);
            } while (pq == q || Mathf.NumberOfOnesAsBit(q) > successNumber / levelRaiseRate + 1);
            Question = q;
            questionValue = q;
            updateConversionGrid();
        }
        private void answer(int solution)
        {
            if (solution == questionValue) // success
            {
                OnSuccessDone();
                newQuestion();
            }
            else // fail
            {
                OnFailDone();
            }
        }

        private void OnFailDone()
        {
            errorsNumber++;
            ClockTime -= secPenalizationOnFail * TicksPerSecond;
            AddCheckMark((SolidColorBrush)this.FindResource("PaleRed"));
        }
        private void OnSuccessDone()
        {
            successNumber++;
            AddCheckMark((SolidColorBrush)this.FindResource("PaleGreen"));
        }

        private void updateConversionGrid()
        {
            int numberOfFiguresLocked = 3 - Mathf.NumberOfFigures(questionValue);
            foreach (UIElement child in ConversionGrid.Children)
            {
                try
                {
                    Border figure = (Border)child;
                    figure.Child = null;
                    if (numberOfFiguresLocked > 0) 
                    {
                        figure.IsEnabled = false;
                        figure.Opacity = 0.5;
                        numberOfFiguresLocked--;
                    }
                    else // There are more Figures than needed
                    {
                        figure.IsEnabled = true;
                        figure.Opacity = 1;
                    }
                    
                }
                catch { } // Non KinectTileButton child
            }
        }
        private int Question
        {
            set
            {
                string s = Mathf.NumberAsBinaryString(value);
                for (int actualLength = s.Length; actualLength < QuestionGrid.ColumnDefinitions.Count; actualLength++)
                {
                    s = 0 + s;
                }
                int i = 0;
                foreach (Grid g in QuestionGrid.Children)
                {
                    ((TextBlock)g.Children[1]).Text= s[i].ToString();
                    i++;
                }
            }
        }

        private void AddCheckMark(SolidColorBrush color)
        {
            Brush auxiliary = ((Border)ConversionGrid.Children[0]).Background;

            foreach (UIElement child in ConversionGrid.Children)
            {
                try
                {
                    Border answerCell = (Border)child;
                    if (!answerCell.IsEnabled) continue;
                    answerCell.Background = color;

                }
                catch { } // Not a border child
            }

            // Control the life time of the checkMark
            DispatcherTimer checkTimer = new DispatcherTimer() { Interval = checkTime };
            checkTimer.Tick += (s, args) =>
            {
                checkTimer.Stop();
                foreach (UIElement child in ConversionGrid.Children)
                {
                    try
                    {
                        Border answerCell = (Border)child;
                        answerCell.Background = auxiliary;

                    }
                    catch { } // Not a border child
                }
            };
            checkTimer.Start();
        }
        
        private int ReadAnswer()
        {
            List<int> warehouse = new List<int>();
            foreach (UIElement child in ConversionGrid.Children)
            {
                try
                {
                    Border answerCell = (Border)child;
                    if (answerCell.IsEnabled == false) continue;
                    try
                    {
                        int readed = Convert.ToInt32(((TextBlock)answerCell.Child).Text);
                        warehouse.Add(readed);
                    }
                    catch { return -1; } // One of the elements has not a children
                    
                }
                catch { } // Not a border child
            }

            int numberOfInts = warehouse.Count;
            int solution = 0;
            foreach (int i in warehouse)
            {
                numberOfInts--;
                solution += i * (int)Math.Pow(10, numberOfInts);
            }

            return solution;
        }

        private Point gripedNumberPosition
        {
            get
            {
                return Griped.TranslatePoint(new Point(Griped.Width / 2, Griped.Height / 2), grid);
            }
            set
            {
                Griped.Margin = new Thickness(value.X - Griped.Width / 2, value.Y - Griped.Height / 2, 0, 0);
            }
        }

    }
}
