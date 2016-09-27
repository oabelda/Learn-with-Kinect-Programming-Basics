using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for TypeIdentification.xaml
    /// </summary>
    public partial class TypeIdentification : UserControl, ExperienceInterface
    {
        // utilities
        private class QuestionBubble
        {
            //Bubble Settings
            private static int defaultBubbleSize = 150;
            private static SolidColorBrush bubbleFill = new SolidColorBrush(Colors.White);
            private static SolidColorBrush bubbleStroke = new SolidColorBrush(Colors.Black);
            private static int bubbleStrokeThickness = 10;

            // Bubble Controllers
            private int fallingSpeed;
            bool isGripinInteraction = false; //Variable to track GripInterationStatus
            TypeIdentification parent; // Parent class

            // Bubble Variables
            private Grid bubble;
            public string rightAnswer;
            public double Height
            {
                get
                {
                    return bubble.ActualHeight;
                }
            }
            public double Width
            {
                get
                {
                    if (bubble.ActualWidth != 0) return bubble.ActualWidth;
                    double width = 0;
                    foreach (UIElement child in bubble.Children)
                    {
                        if (width < (double)child.GetValue(WidthProperty)) width = (double)child.GetValue(WidthProperty);
                        if (width < (double)child.GetValue(ActualWidthProperty)) width = (double)child.GetValue(ActualWidthProperty);
                    }
                    return width;

                }
            }
            public int ZIndex
            {
                get
                {
                    return Grid.GetZIndex(bubble);
                }
                set
                {
                    Grid.SetZIndex(bubble, value);
                }
            }

            // Bubble Manipulation
            public void setPosition(double left, double top)
            {
                bubble.Margin = new Thickness(left, top, 0, 0);
            }
            public Point Pos
            {
                get
                {
                    return new Point(bubble.Margin.Left, bubble.Margin.Top);
                }
            }
            public void DrawIn(Grid parentGrid)
            {
                parentGrid.Children.Add(bubble);
            }
            public void Erase()
            {
                try { ((Panel)bubble.Parent).Children.Remove(bubble);} catch{} // Already remove from the grid
                try { parent.timerTickEvent -= falling; } catch { } // Already stoped

                KinectRegion.SetIsGripTarget(bubble, false);
                KinectRegion.RemoveHandPointerGripHandler(bubble, this.OnHandPointerGrip);
                KinectRegion.RemoveHandPointerGripReleaseHandler(bubble, this.OnHandPointerGripRealease);
                KinectRegion.RemoveQueryInteractionStatusHandler(bubble, this.OnQuery);
            }
            public void StopFalling()
            {
                parent.timerTickEvent -= falling;
            }
            public void Fall()
            {
                parent.timerTickEvent += falling;
            }

            // Constructors
            public QuestionBubble(int fallingSpeed, TypeIdentification parent, string bubbleContent, string rightAnswer)
                : this(fallingSpeed, parent, bubbleContent, rightAnswer, defaultBubbleSize) { }
            public QuestionBubble(int fallingSpeed, TypeIdentification parent, string bubbleContent, string rightAnswer, int bubbleWidth)
                : this(fallingSpeed, parent, bubbleContent, rightAnswer, bubbleWidth, defaultBubbleSize) { }
            public QuestionBubble(int fallingSpeed, TypeIdentification parent, string bubbleContent, string rightAnswer, int bubbleWidth, int bubbleHeight)
            {
                this.fallingSpeed = fallingSpeed;
                this.parent = parent;
                this.rightAnswer = rightAnswer;

                bubble = new Grid() { VerticalAlignment = VerticalAlignment.Top, HorizontalAlignment = HorizontalAlignment.Left };
                bubble.Children.Add(new Ellipse() { StrokeThickness = bubbleStrokeThickness, Stroke = bubbleStroke, Fill = bubbleFill, Height = bubbleHeight, Width = bubbleWidth });
                bubble.Children.Add(new TextBlock() { Text = bubbleContent, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center });

                KinectRegion.SetIsGripTarget(bubble, true);
                KinectRegion.AddHandPointerGripHandler(bubble, this.OnHandPointerGrip);
                KinectRegion.AddHandPointerGripReleaseHandler(bubble, this.OnHandPointerGripRealease);
                KinectRegion.AddQueryInteractionStatusHandler(bubble, this.OnQuery);

            }

            // On Event
            void falling(object sender, EventArgs e)
            {
                if ((Panel)bubble.Parent == null) { Erase(); return; }

                setPosition(bubble.Margin.Left, bubble.Margin.Top + fallingSpeed);

                if (bubble.Margin.Top > ((Panel)bubble.Parent).ActualHeight)
                {
                    Erase();
                    if (null != bubblelostEvent) this.bubblelostEvent(this, EventArgs.Empty);
                }
            }

            // Events
            public event EventHandler<EventArgs> GripEvent;
            public event EventHandler<EventArgs> GripReleaseEvent;
            public event EventHandler<EventArgs> bubblelostEvent;
            private void OnHandPointerGrip(object sender, HandPointerEventArgs e)
            {
                if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;
                if (null != GripEvent) this.GripEvent(this, e);

            }
            private void OnHandPointerGripRealease(object sender, HandPointerEventArgs e)
            {
                if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;
                if (null != GripReleaseEvent) this.GripReleaseEvent(this, e);
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
        }

        // settings
        private int lossesAllowed = 5; // Lifes - Maximum number of missed bubbles.
        private string lifesImageURI = "Content/TypeIdentification_Resources/Life.png"; // Ubication of the lifes image
        private const int TicksPerSecond = 60; // Trigger's ticks per second
        private TimeSpan initialSpawnTime = TimeSpan.FromSeconds(3); // Time before beggining
        private TimeSpan spawnInterval // Interval between two bubbles function
        {
            get
            {
                // A random value between minInterval and maxInterval is choosed - minInterval and maxInterval depends on the score
                double max_min;  // the max, value minInterval can take
                double min_min;  // the min, value minInterval can take
                double max_max; // the max, value maxInterval can take
                double min_max;  // the min, value maxInterval can take
                if (actualLevel == 0) {
                    max_min = 5; 
                    min_min = 1; 
                    max_max = 10;
                    min_max = 2; 
                }
                else if (actualLevel == 1)
                {
                    max_min = 4; 
                    min_min = 1; 
                    max_max = 8; 
                    min_max = 2; 
                }
                else
                {
                    max_min = 3; 
                    min_min = 1; 
                    max_max = 5; 
                    min_max = 1; 
                }

                const int topSuccess = 50; // Number of success with supposed no error where topScore is reach
                long topScore = successScore * topSuccess; // Score at wich we take the min_minInterval value and min_maxInterval value
                const long botScore = 0; // Score at wich we take the max_minInterval value and max_maxInterval value

                // Normalize the score value between topScore and botScore
                double scoreNormalized = (Mathf.Clamp(Score,botScore,topScore) - botScore)/(topScore - botScore);

                // Calculate the minInterval and maxInterval
                double minInterval = (1-scoreNormalized) * (max_min - min_min) + min_min;
                double maxInterval = (1-scoreNormalized) * (max_max - min_max) + min_max;

                // Take a normalized random value between minInterval and maxInterval
                double random = rnd.NextDouble();

                return TimeSpan.FromSeconds( random * (maxInterval - minInterval) + minInterval); // Return the timeSpan
            }
        }
        private int fallingSpeed
        {
            get
            {
                //Console.WriteLine(3 + 3 * actualLevel);
                return 3 + 3*actualLevel;
            }
        } // Bubbles falling speed function
        private long successScore
        {
            get
            {
                return 10000;
            }
        } // Score bonus per success function
        private long failScorePenalization
        {
            get
            {
                return successScore / 4;
            }
        } // Score penalization per fail function

        // controllers
        private readonly DispatcherTimer timer = new DispatcherTimer(); // Timer to handle the experience ticks
        private readonly DispatcherTimer SpawnTimer = new DispatcherTimer(); // Timer to handle the the bubble spawns
        /// <summary> Event call on each tick, used for make other objects act on timer.tick </summary>
        internal event EventHandler<EventArgs> timerTickEvent;
        private Random rnd = new Random(); // Random variable shared for all random needs
        private QuestionBubble gripedQuestion = null;
        private Image hoverBox = null;
        private Image[] boxes;

        // knobs
        private int errorsNumber; // Number of errors commited
        private int successNumber;
        private long Score // Score
        {
            get
            {
                return Convert.ToInt64(ScoreLabel.Text);
            }
            set
            {
                ScoreLabel.Text = string.Format("{0:0000000000}", value);
            }
        }

        private int actualLevel = 0; // 0 Easy, 1 Medium, 2 Hard

        /// <summary> Initializes a new instance of the <see cref="TypeIdentification"/> class.  </summary>
        public TypeIdentification(object param)
        {
            InitializeComponent();

            PromptMenu.ParentContent = this;
            WelcomeMenu.ParentContent = this;
            WelcomeMenu.Text.Text = (string) param;


            // initialize the eventhandlers
            KinectRegion.AddHandPointerMoveHandler(this, OnHandPointerMove);

            boxes = new Image[] { Box1, Box2, Box3, Box4 };
            
            this.timer.Interval = TimeSpan.FromMilliseconds(1000 / TicksPerSecond);
            this.timer.Tick += (s, args) =>
            {
                this.timer.Stop();
                Update();
                if (LifePanel.Children.Count != 0) this.timer.Start();
            };

            this.SpawnTimer.Interval = initialSpawnTime;
            this.SpawnTimer.Tick += SpawnTimer_Tick;

            Retry();

            WelcomeMenu.Show();
        }

        bool answerSuccess
        {
            get
            {
                return hoverBox.Tag.Equals(gripedQuestion.rightAnswer);
            }
        }

        //Main Commands

        public void BackToMenu()
        {
            this.BeginStoryboard((Storyboard)this.FindResource("UnloadStoryboard"));
        }

        public void Retry() {
            Retry(actualLevel);
        }
        public void Retry(int level)
        {
            actualLevel = level;

            // Reset controllers
            this.SpawnTimer.Interval = initialSpawnTime;
            gripedQuestion = null;
            HandPointerGrid.Children.Clear();
            // Reset knobs
            Score = 0;
            errorsNumber = 0;
            successNumber = 0;
            setLifePanel();
            
            Play();
        }
        public void Play()
        {
            this.SpawnTimer.Start();
            this.timer.Start();
        }
        public void Pause()
        {
            this.SpawnTimer.Stop();
            this.timer.Stop();
        }
        private void EndExperience()
        {
            this.Pause();

            ScoreArchivementsText.Text = "";
            ScoreArchivementsText.Text += (string)this.FindResource("NHits") + ": " + successNumber;
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("HightScore") + ": " + successNumber + " " + (string)this.FindResource("hit") + "s x " + successScore + (string)this.FindResource("score") + "/" + (string)this.FindResource("hit") + " = " + successNumber * successScore;
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("NErrors") + ": " + errorsNumber;
            ScoreArchivementsText.Text += "\n" + (string)this.FindResource("Penalization") + ": " + errorsNumber + " " + (string)this.FindResource("errors") + " x " + failScorePenalization + (string)this.FindResource("score") + "/" + (string)this.FindResource("fail") + " = " + errorsNumber * failScorePenalization;

            FinalScoreText.Text = Score.ToString();

            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(ScoreView, "Normal", false);
            VisualStateManager.GoToElementState(ScoreView, "FadeIn", true);

        }

        // Events

        private void Update()
        {
            if (null != timerTickEvent) this.timerTickEvent(this, EventArgs.Empty);
        }

        void SpawnTimer_Tick(object sender, EventArgs e)
        {
            this.SpawnTimer.Stop();

            // Spawn a new questionBubble
            QuestionBubble newQuestion = newQuestionBubble();
                // Set the event listeners
                newQuestion.GripEvent += bubble_GripEvent;
                newQuestion.GripReleaseEvent += bubble_GripReleaseEvent;
                newQuestion.bubblelostEvent += bubble_bubbleLostEvent;
                // Add to the grid
                newQuestion.DrawIn(HandPointerGrid);
                newQuestion.setPosition(rnd.Next((int)SpawnZone.TranslatePoint(new Point(0, 0), grid).X, Convert.ToInt32(SpawnZone.TranslatePoint(new Point(0, 0), grid).X + SpawnZone.ActualWidth - newQuestion.Width)), 0 - newQuestion.Width);
                // Start falling
                newQuestion.Fall();

            // New interval
            if (LifePanel.Children.Count != 0)
            {
                SpawnTimer.Interval = spawnInterval;
                SpawnTimer.Start();
            }
        }

        private void OnHandPointerMove(object sender, HandPointerEventArgs e)
        {
            if (!e.HandPointer.IsPrimaryHandOfUser || !e.HandPointer.IsPrimaryUser) return;

            Point handPos = e.HandPointer.GetPosition(grid);

            foreach (Image box in boxes)
            {
                Point boxOrigin = box.TranslatePoint(new Point(0, 0),grid);
                if (
                    (boxOrigin.X <= handPos.X && (boxOrigin.X + box.ActualWidth) >= handPos.X) &&
                    (boxOrigin.Y <= handPos.Y && (boxOrigin.Y + box.ActualHeight) >= handPos.Y)
                    )
                {
                    TransformGroup transformAnimation = new TransformGroup();
                    transformAnimation.Children.Add(new ScaleTransform() { ScaleX = 1.1, ScaleY = 1.1 });
                    box.RenderTransform = transformAnimation;
                    hoverBox = box;
                    break;
                }
                else
                {
                    TransformGroup transformAnimation = new TransformGroup();
                    box.RenderTransform = transformAnimation;
                }
                hoverBox = null;
            }


            if (gripedQuestion == null) return;

            gripedQuestion.setPosition(handPos.X - gripedQuestion.Width / 2, handPos.Y - gripedQuestion.Height / 2);           

        }

        void bubble_GripReleaseEvent(object sender, EventArgs e)
        {
            if (gripedQuestion != null)
            {
                Point spawnOrigin = SpawnZone.TranslatePoint(new Point(0, 0), grid);
                if ( // If the gripedQuestion is inside SpawnZone
                    (spawnOrigin.X <= gripedQuestion.Pos.X && (spawnOrigin.X + SpawnZone.ActualWidth) >= gripedQuestion.Pos.X) &&
                    (spawnOrigin.Y <= gripedQuestion.Pos.Y && (spawnOrigin.Y + SpawnZone.ActualHeight) >= gripedQuestion.Pos.Y)
                    ) {
                        gripedQuestion.ZIndex = gripedQuestion.ZIndex;
                        gripedQuestion.Fall();
                    }
                else if (hoverBox == null) // If the gripedQuestion is not over any box
                {
                    // Return the gripedQuestion to a random X position of the SpawnZone. Keep the Y pos
                    gripedQuestion.setPosition(rnd.Next((int)SpawnZone.TranslatePoint(new Point(0, 0), grid).X, Convert.ToInt32(SpawnZone.TranslatePoint(new Point(0, 0), grid).X + SpawnZone.ActualWidth - gripedQuestion.Width)), gripedQuestion.Pos.Y);
                    gripedQuestion.ZIndex = gripedQuestion.ZIndex;
                    gripedQuestion.Fall();
                }
                else if (answerSuccess){ // If success
                    successNumber++;
                    Score = Score + successScore; // Add points
                    gripedQuestion.Erase(); // Remove the bubble
                }
                else // If Fail
                {
                    errorsNumber++; // +1 error
                    Score = Score - failScorePenalization; // Score penalization
                    gripedQuestion.Erase(); // Remove the bubble;
                    looseLife(); // Life lost
                } 
                
                gripedQuestion = null;
            }
        }

        void bubble_GripEvent(object sender, EventArgs e)
        {
            if (gripedQuestion == null)
            {
                gripedQuestion = (QuestionBubble)sender;
                gripedQuestion.StopFalling();
                gripedQuestion.ZIndex = gripedQuestion.ZIndex + 10;
            }
        }

        private void bubble_bubbleLostEvent(object sender, EventArgs e)
        {
            looseLife();
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

        // Auxiliary Methods

        private void setLifePanel()
        {
            LifePanel.Children.Clear();
            for (int i = 0; i < lossesAllowed; i++)
            {
                LifePanel.Children.Add(new Image() { Source = new BitmapImage(PackUriHelper.CreatePackUri(lifesImageURI)) });
            }
        }
        private void looseLife()
        {
            LifePanel.Children.RemoveAt(0);
            if (LifePanel.Children.Count == 0) EndExperience();
        }

        private bool setBox(Image box, String tag)
        {
            if (getBox(tag) != null) return false;

            box.Tag = tag;
            ((TextBlock)((Panel)box.Parent).Children[1]).Text = tag;
            return true;
        }
        private Image getBox(String tag)
        {
            foreach (Image box in boxes)
                if (box.Tag.Equals(tag))
                    return box;
            return null;
        }

        private QuestionBubble newQuestionBubble()
        {
            // Two versions of the code, the old version takes a value from a resource list, the new version generate it randomly
            bool useOldVersion = false;
            if (!useOldVersion) return newQuestionBubble_v2();

            // Get the resource list
            ArrayList QuestionList = (ArrayList)this.FindResource("TypeIdentification_Questions");

            // Get values
            int random = rnd.Next(0, QuestionList.Count);
                // Choose answer field
                ArrayList AnswerList = (ArrayList)QuestionList[random];

                // Choose a question
                random = rnd.Next(0, ((ArrayList)AnswerList[1]).Count);
                ArrayList Question = ((ArrayList)((ArrayList)AnswerList[1])[random]);

            // Return methods
            if (Question.Count == 1) return new QuestionBubble(fallingSpeed, this, (string)Question[0], (string)AnswerList[0]);
            if (Question.Count == 2) return new QuestionBubble(fallingSpeed, this, (string)Question[0], (string)AnswerList[0], (int)Question[1]);
            if (Question.Count == 3) return new QuestionBubble(fallingSpeed, this, (string)Question[0], (string)AnswerList[0], (int)Question[1], (int)Question[2]);

            return null;
        }

        string[] strings;

        private QuestionBubble newQuestionBubble_v2()
        {
            if (strings == null) createStrings();

            // This must creates a question bubble randomly
            const string Answer_Integer = "Integer";
            const string Answer_Float = "Float";
            const string Answer_Bool = "Boolean";
            const string Answer_String = "String";

            string newQuest = "";
            string anws = "";

            // First choose the type of the answer
            switch (rnd.Next(0, 4))
            {
                // Work eather way
                case 0: // The answer is Integer
                    anws = Answer_Integer;
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Primitive value
                            newQuest = randomPrimInt().ToString();
                            break;
                        case 1: // Operative value
                            newQuest = randomOpIn();
                            break;
                    }
                    break;
                case 1: //The answer is Float
                    anws = Answer_Float;
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Primitive value
                            newQuest = string.Format("{0:0.00}", randomPrimFloat());
                            break;
                        case 1: // Operative value
                            newQuest = randomOpFloat();
                            break;
                    }
                    break;
                case 2: //The answer is Bool
                    anws = Answer_Bool;
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Primitive value
                            newQuest = randomPrimBool();
                            break;
                        case 1: // Operative value
                            newQuest = randomOpBool();
                            break;
                    }
                    break;
                case 3: // The answer is String
                    anws = Answer_String;
                    newQuest = randomString();
                    break;
            }

            return new QuestionBubble(fallingSpeed, this, newQuest, anws, 250);
                
        }

        private string addQuotes(string s)
        {
            return ("\""+s+"\"");
        }

        private int randomPrimInt()
        {
            return (rnd.Next(0, 10));
        }

        private string randomOpIn()
        {
            switch (rnd.Next(0, 4))
            {
                case 0:
                    return (randomPrimInt().ToString() + "+" + randomPrimInt().ToString());
                case 1:
                    return (randomPrimInt().ToString() + "-" + randomPrimInt().ToString());
                case 2:
                    return (randomPrimInt().ToString() + "*" + randomPrimInt().ToString());
                case 3:
                    return (randomPrimInt().ToString() + "/" + randomPrimInt().ToString());
            }
            return null;
        }

        private float randomPrimFloat()
        {
            return ((float)rnd.NextDouble()*10);
        }

        private string randomOpFloat()
        {
            switch (rnd.Next(0, 4))
            {
                case 0:
                    return (string.Format("{0:0.00}+{1:0.00}",randomPrimFloat(),randomPrimFloat()));
                case 1:
                    return (string.Format("{0:0.00}-{1:0.00}", randomPrimFloat(), randomPrimFloat()));
                case 2:
                    return (string.Format("{0:0.00}/{1:0.00}", randomPrimFloat(), randomPrimFloat()));
                case 3:
                    return (string.Format("{0:0.00}*{1:0.00}", randomPrimFloat(), randomPrimFloat()));
            }
            return null;
        }

        private string randomPrimBool()
        {
            if (rnd.Next(0, 2) ==  0) return "true";
            return "false";
        }

        private string randomOpBool()
        {
            switch (rnd.Next(0, 3))
            {
                case 0: // &&
                    return (randomPrimBool() + " && " + randomPrimBool());
                case 1: // ||
                    return (randomPrimBool() + " || " + randomPrimBool());
                case 2: // Other
                    switch (rnd.Next(0, 6))
                    {
                        case 0: // ==
                            return randomOpForOpBool("==");
                        case 1: // !=
                            return randomOpForOpBool("!=");
                        case 2: // <
                            return randomOpForOpBool("<");
                        case 3: // >
                            return randomOpForOpBool(">");
                        case 4: // <=
                            return randomOpForOpBool("<=");
                        case 5: // >=
                            return randomOpForOpBool(">=");
                    }
                    return null;
            }
            return null;
        }

        private string randomOpForOpBool(string op)
        {
            switch (rnd.Next(0, 4)) {
                case 0: // String con string
                    return randomString() + op + randomString();
                case 1: // Float con float
                    return (string.Format("{0:0.0}{1}{2:0.0}", randomPrimFloat(), op, randomPrimFloat()));
                case 2: // Int con Int
                    return (randomPrimInt().ToString() + op + randomPrimInt().ToString());
                case 3: //Float con Int
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Float con Int
                            return (string.Format("{0:0.0}{1}{2:0}", randomPrimFloat(), op, randomPrimInt()));
                        case 1: // Int con Float
                            return (string.Format("{2:0}{1}{0:0.0}", randomPrimFloat(), op, randomPrimInt()));

                    }
                    break;
            }
            return null;
        }

        private string randomString()
        {
            switch (rnd.Next(0, 4))
            {
                case 0:
                    return addQuotes(filtredPrimitive());
                default:
                    return addQuotes(strings[rnd.Next(0, strings.Length)]);
            }
        }

        private void createStrings()
        {

            // Get the resource string
            string resourcesStrings = "";

            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "es-ES":
                    resourcesStrings = (String)this.FindResource("TypeIdentification_Strings_es");
                    break;
                case "en-US":
                    resourcesStrings = (String)this.FindResource("TypeIdentification_Strings_en");
                    break;
                default:
                    resourcesStrings = (String)this.FindResource("TypeIdentification_Strings_en");
                    break;
            }

            strings = resourcesStrings.Split(' ');
        }

        private string filtredPrimitive()
        {
            switch (rnd.Next(0, 3))
            {
                // Work eather way
                case 0: // The answer is Integer
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Primitive value
                            return randomPrimInt().ToString();
                        case 1: // Operative value
                            return randomOpIn();
                    }
                    break;
                case 1: //The answer is Float
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Primitive value
                            return string.Format("{0:0.00}", randomPrimFloat());
                        case 1: // Operative value
                            return randomOpFloat();
                    }
                    break;
                case 2: //The answer is Bool
                    switch (rnd.Next(0, 2))
                    {
                        case 0: // Primitive value
                            return randomPrimBool();
                        case 1: // Operative value
                            return randomOpBool();
                    }
                    break;
            }
            return null;
        }
    }
}
