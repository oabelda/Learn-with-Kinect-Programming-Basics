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
    public partial class BinaryConvert : UserControl, ExperienceInterface
    {
        // settings
        private const int TicksPerSecond = 10; // Trigger's ticks per second
        private int secPenalizationOnFail
        {
            get
            {
                return 10 + 10 * actualLevel;
            }
        }
        private TimeSpan checkTime = TimeSpan.FromSeconds(3); // Amount of time the checkMark stays
        private const long timeInSeconds = 120; // Amount of time to play, in seconds
        private int levelRaiseRate
        { // The amount of right anwers to pass level
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

        // knobs
        private int errorsNumber;
        private int successNumber;
        /// <summary> Saves the passed time </summary>
        private long ClockTime;

        private int actualLevel = 0;

        public BinaryConvert(object param)
        {
            InitializeComponent();

            PromptMenu.ParentContent = this;
            WelcomeMenu.ParentContent = this;
            WelcomeMenu.Text.Text = (string)param;


            this.timer.Interval = TimeSpan.FromMilliseconds(1000 / TicksPerSecond);
            this.timer.Tick += (s, args) =>
            {
                this.timer.Stop();
                timerTick();
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
            clearConversionGrid();

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

        private void timerTick()
        {
            ClockTime--;
            TimeCounter.Text = ClockConverter.ticksToTenthsSecondsMinutesFormat(ClockTime, TicksPerSecond, Properties.Resources.timeFormat);
            if (ClockTime <= 0) EndExperience();
            else this.timer.Start();
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
            clearConversionGrid();
            int q; // new Question
            int pq = Question; // Previous Question
            do {
                q = rnd.Next(0, ((int)Math.Pow(2, (ConversionGrid.ColumnDefinitions.Count - 2))) - 1);
            } while (pq == q || Mathf.NumberOfOnesAsBit(q) > successNumber / levelRaiseRate + 1);
            Question = q;
        }
        private void answer(int solution)
        {          
            if (solution == Question) // success
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
            AddCheckMark(new BitmapImage(PackUriHelper.CreatePackUri("Content/BinaryConvert_Resources/Red_tick.png")));
        }

        private void OnSuccessDone()
        {
            successNumber++;
            AddCheckMark(new BitmapImage(PackUriHelper.CreatePackUri("Content/BinaryConvert_Resources/Green_tick.png")));
        }
        private void clearConversionGrid()
        {
            KinectTileButton solutionButton = (KinectTileButton)ConversionGrid.Children[ConversionGrid.ColumnDefinitions.Count - 1];

            foreach (UIElement child in ConversionGrid.Children)
            {
                try
                {
                    KinectTileButton button = (KinectTileButton)child;
                    if (button != solutionButton)
                    {
                        button.Content = "0";
                    }
                }
                catch { } // Non KinectTileButton child
            }

            ConvertSolution = 0;
        }

        private int ConvertSolution
        {
            get
            {
                return Convert.ToInt32(conversionSolution.Content);
            }
            set
            {
                conversionSolution.Content = string.Format("{0:000}", value);
            }
        }
        private int Question
        {
            get
            {
                return Convert.ToInt32(questionShow.Text);
            }
            set
            {
                questionShow.Text = string.Format("{0:0}", value);
            }
        }

        private void BitCellTileButton_Click(object sender, RoutedEventArgs e)
        {
            KinectTileButton button = (KinectTileButton)sender;
            if (button.Content.Equals("0"))
            {
                button.Content = "1";
            }
            else
            {
                button.Content = "0";
            }
        }

        private void AnswerTileButton_Click(object sender, RoutedEventArgs e)
        {
            int solution = 0;

            int buttonNumber = 0;

            foreach (UIElement child in ConversionGrid.Children)
            {
                try
                {
                    KinectTileButton button = (KinectTileButton)child;
                    if (button != (KinectTileButton)sender)
                    {
                        if (Convert.ToInt32(button.Content) != 0)
                        {
                            solution += (int)Math.Pow(Convert.ToInt32(((TextBlock)SubHeader.Children[buttonNumber * 2]).Text), Convert.ToInt32(((TextBlock)SubHeader.Children[buttonNumber * 2 + 1]).Text));
                        }
                        buttonNumber++;
                    }
                }
                catch { } // Non a KinectTileButton child
            }

            ConvertSolution = solution;

            answer(solution);
        }

        private void AddCheckMark(ImageSource source)
        {
            Image checkMark = new Image() { Source = source, MaxHeight=150, HorizontalAlignment=HorizontalAlignment.Right };
            checkMark.SetValue(Grid.ColumnProperty, ConversionGrid.ColumnDefinitions.Count); // Set the image grid.column to the last column
            ConversionGrid.Children.Add(checkMark);

            // Control the life time of the checkMark
            DispatcherTimer checkTimer = new DispatcherTimer() { Interval = checkTime };
            checkTimer.Tick += (s, args) =>
            {
                checkTimer.Stop();
                ConversionGrid.Children.Remove(checkMark);
            };
            checkTimer.Start();
        }
    }
}
