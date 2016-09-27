using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TFG_AIK_OscarJoseAbeldaFernandez.Controls;
using TFG_AIK_OscarJoseAbeldaFernandez.Experiences;
using TFG_AIK_OscarJoseAbeldaFernandez.Utilities;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Content.Experiences
{
    /// <summary>
    /// Interaction logic for TypeDefinition.xaml
    /// </summary>
    public partial class TypeDefinition : UserControl, ExperienceInterface
    {
        // utilities
        private class question
        {
            internal string type;
            internal int memoryCells;
            internal SolidColorBrush color;
        }

        // settings
        /// <summary> Trigger's ticks per second </summary>
        private const int TicksPerSecond = 10;
        private const int actualMemoryCellsCount = 8; // MAY BE NON CONSTANT LATER
        private const int actualParallelQuestionsCount = 1; // MAY BE NON CONSTANT LATER
        private const int minColorContrast = 50; // Min contrast between parallel colors
        private int penalizationPerFailInSeconds // Seconds added for each fail
        {
            get
            {
                return 20 + 20 * actualLevel;
            }
        }

        // controllers
        private Grid actualQuestionGrid;
        private ObservableCollection<question> actualQuestions;
        private ObservableCollection<ObservableCollection<question>> nextQuestions;
        /// <summary> Timer to handle the experience ticks events </summary>
        private readonly DispatcherTimer timer = new DispatcherTimer();
        /// <summary> Random variable shared for all random needs </summary>
        private Random rnd = new Random();
        private Brush defaultMemoryColor; // Set on runtime

        private int numberOfQuestions
        {
            get { return 20 + 10 * actualLevel; }
        }
        // knobs
        private int remainingQuestions = 20;
        private int errorsNumber; // Number of errors commited
        /// <summary> Saves the passed time </summary>
        private long ClockTime = 0;

        private int actualLevel = 0;

        /// <summary> Initializes a new instance of the <see cref="TypeDefinition"/> class.  </summary>
        public TypeDefinition(object param)
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
                this.timer.Start();
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
            errorsNumber = 0; // errors
            ClockTime = 0; // time
            remainingQuestions = numberOfQuestions; // questions

            // Clear the panel
            QuestionsGrid.Children.Clear();

            // Reset the questions lists
            if (actualQuestions != null) actualQuestions.Clear();
            if (nextQuestions != null)
            {
                nextQuestions.Clear();
            }
            else
            {
                nextQuestions = new ObservableCollection<ObservableCollection<question>>();
            }

            // Prepare a valid game
            while (actualQuestions == null || actualQuestions.Count == 0)
            {
                makeQuestion();
            }

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
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("Time") + ": " + ClockConverter.ticksToTenthsSecondsMinutesFormat(ClockTime, TicksPerSecond, Properties.Resources.timeFormat);
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("NErrors") + ": " + errorsNumber;
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("Penalization") + ": " + penalizationPerFailInSeconds + "s x " + errorsNumber + " " + (string)this.FindResource("errors") + " = " + errorsNumber * penalizationPerFailInSeconds + "s";

            ScoreFinalTimeText.Text = ClockConverter.ticksToTenthsSecondsMinutesFormat(ClockTime + errorsNumber * penalizationPerFailInSeconds * TicksPerSecond, TicksPerSecond, Properties.Resources.timeFormat);

            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(ScoreView, "Normal", false);
            VisualStateManager.GoToElementState(ScoreView, "FadeIn", true);

        }

        // Events

        private void timerTick()
        {
            ClockTime++;
            TimeCounter.Text = ClockConverter.ticksToTenthsSecondsMinutesFormat(ClockTime, TicksPerSecond, Properties.Resources.timeFormat);
        }

        void OnClick(object sender, RoutedEventArgs e)
        {
            KinectTileButton button = (KinectTileButton)e.OriginalSource;

            if (null == defaultMemoryColor) defaultMemoryColor = button.Background;

            if (button.Background == defaultMemoryColor)
            {
                button.Background = actualQuestions[0].color;
                e.Handled = true;
            }
            else
            {
                for (int i = 0; i < actualQuestions.Count; i++)
                {
                    if (button.Background == actualQuestions[i].color)
                    {
                        try
                        {
                            button.Background = actualQuestions[i + 1].color;
                            e.Handled = true;
                        }
                        catch // Array index out of bounds exception
                        {
                            button.Background = defaultMemoryColor;
                            e.Handled = true;
                        }
                        break;
                    }
                }
                if (!e.Handled)
                {
                    throw new Exception("The button color is not default or one of the question colors - check code errors");
                }
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            int[] count = countOnMemory();
            bool success = true;
            for (int i = 0; i < count.Length; i++)
            {
                if (actualQuestions[i].memoryCells != count[i])
                {
                    success = false;
                    break;
                }
            }

            // Create new image as checkMark
            Image checkMark = new Image() { Height = 80, Margin = new Thickness(350, 0, 0, 0) };

            if (success)
            {
                checkMark.Source = new BitmapImage(PackUriHelper.CreatePackUri("Content/TypeDefinition_Resources/Green_tick.png"));
            }
            else // not success  
            {
                checkMark.Source = new BitmapImage(PackUriHelper.CreatePackUri("Content/TypeDefinition_Resources/Red_tick.png"));
                errorsNumber++;
            }

            // Either way
            // Add checkMark
            checkMark.SetValue(Grid.RowSpanProperty, actualQuestionGrid.RowDefinitions.Count); // Set the image grid.rowspan to cover all rows
            actualQuestionGrid.Children.Add(checkMark);

            // New Question
            makeQuestion();
        }

        /// <summary> Called when the UnloadStoryboard storyboard completes. </summary>
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

        // Auxiliar Methods

        /// <summary>
        /// Checks how many consecutive cells have been take for each actual question.
        /// </summary>
        /// <returns>An int array in same order as actual question</returns>
        int[] countOnMemory()
        {
            int[] count = new int [actualQuestions.Count];
            for (int i = 0; i < count.Length; i++ ) count[i] = 0;

            for (int i = 0; i < count.Length; i++ )
            {
                bool consecutive = true;
                foreach (KinectTileButton cell in MemoryPanel.Children)
                {
                    if (cell.Background == actualQuestions[i].color)
                    {
                        count[i] = (consecutive) ? count[i]+1 : -1;
                        if (!consecutive) break;
                    }
                    else if (count[i] > 0) consecutive = false; ;
                }
            }

            return count;
        }

        private void makeQuestion()
        {
            // Move up and erase the upper one
            for (int i = 0; i < QuestionsGrid.Children.Count; i++) //(Grid grid in QuestionsGrid.Children)
            {
                if ((int)QuestionsGrid.Children[i].GetValue(Grid.RowProperty) == 0)
                {
                    QuestionsGrid.Children.Remove(QuestionsGrid.Children[i]);
                    i--;
                }
                else
                {
                    QuestionsGrid.Children[i].SetValue(Grid.RowProperty, (int)QuestionsGrid.Children[i].GetValue(Grid.RowProperty) - 1);
                    if ((int)QuestionsGrid.Children[i].GetValue(Grid.RowProperty) == QuestionsGrid.RowDefinitions.Count / 2)
                    {
                        actualQuestionGrid = (Grid)QuestionsGrid.Children[i];
                    }
                }
            }
            // Change the actualQuestions
            if (nextQuestions != null && (nextQuestions.Count == (QuestionsGrid.RowDefinitions.Count - (QuestionsGrid.RowDefinitions.Count / 2) - 1) || remainingQuestions <= 0))
            {
                try
                {
                    actualQuestions = nextQuestions[0];
                    nextQuestions.RemoveAt(0);
                    setMemory(actualMemoryCellsCount);
                }
                catch // Exception ArgumentOutOfRangeException -> remainingQuestions == 0 && nextQuestions.Count == 0
                {
                    EndExperience();
                }
            }

            if (remainingQuestions > 0)
            {
                // Create the new question
                ObservableCollection<question> newQuestions = newQuestion(actualParallelQuestionsCount);
                nextQuestions.Add(newQuestions);
                remainingQuestions--;

                // Create a new grid and add it
                Grid newGrid = new Grid() { Margin = new Thickness(60, 0, 0, 0), VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Left };

                for (int i = 0; i < newQuestions.Count; i++)
                {

                    newGrid.RowDefinitions.Add(new RowDefinition());

                    TextBlock text = new TextBlock() { Text = newQuestions[i].type, Foreground = newQuestions[i].color, VerticalAlignment = VerticalAlignment.Center };
                    text.SetValue(Grid.RowProperty, i);

                    newGrid.Children.Add(text);
                }

                newGrid.SetValue(Grid.RowProperty, (QuestionsGrid.RowDefinitions.Count - 1));
                QuestionsGrid.Children.Add(newGrid);
            }
        }

        /// <summary>
        /// Create a new question list
        /// </summary>
        /// <param name="numberOfQuestions">number of parallel questions</param>
        /// <returns>question coloured list</returns>
        private ObservableCollection<question> newQuestion(int numberOfQuestions)
        {
            /// JUST TESTING CODE RIGHT NOW
            // Object to return
            ObservableCollection<question> newQuest = new ObservableCollection<question>();

            // Get the resource list
            ArrayList QuestionList = (ArrayList)this.FindResource("TypeDefinition_Questions");

            // Create each question
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int random = rnd.Next(0, QuestionList.Count);

                if (random % 2 != 0) // Odd number
                {
                    random--;
                }

                question quest = new question();
                quest.type = (string)QuestionList[random];
                quest.memoryCells = (int)QuestionList[random + 1];

                newQuest.Add(quest);
            }

            // Colour each question
            randomColors(newQuest, minColorContrast);

            // Return
            return newQuest;
            
        }

        /// <summary>
        /// Colours a list of questions with different colors.
        /// </summary>
        /// <param name="list">question list wich is coloured</param>
        /// <param name="colorMinContrast">min contrast between all taken colors</param>
        private void randomColors(ObservableCollection<question> list, int colorMinContrast)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].color = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(50, 205), (byte)rnd.Next(50, 205), (byte)rnd.Next(50, 205)));
                for (int j = i - 1; j > 0; j--)
                {
                    if (ColorHelper.areSimilarColors(list[j].color, list[i].color, colorMinContrast))
                    {
                        i--;
                        break;
                    }
                }
            }
        }

        /// <summary> Clear the Memory and set a new one </summary>
        /// <param name="cells">Number of cells displayed </param>
        private void setMemory(int cells)
        {
            // Clear out placeholder content
            MemoryPanel.Children.Clear();

            // Add in display context
            for (int i = 0; i < cells; i++)
                MemoryPanel.Children.Add(new KinectTileButton { Style = (Style)this.FindResource("MemoryCellTileButton") });
        }
    }
}
