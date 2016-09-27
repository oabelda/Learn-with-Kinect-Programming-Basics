using System;

using System.IO;
using System.Linq;
using System.Text;
using System.Xaml;
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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;

using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;

using TFG_AIK_OscarJoseAbeldaFernandez.Utilities;
using TFG_AIK_OscarJoseAbeldaFernandez.Experiences;
using System.Threading;

namespace TFG_AIK_OscarJoseAbeldaFernandez
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Screen size variables
        private const int OptimalScreenWidth = 1920;
        private const int OptimalScreenHeight = 1080;

        /// <summary> Mouse movement detector. </summary>
        private readonly MouseMovementDetector movementDetector;

        /// <summary> Component that manages finding a Kinect sensor </summary>
        private readonly KinectSensorChooser sensorChooser;

        public MainWindow()
        {
            // If the main screen is less than MinimumScreenWidth x MinimumScreenHeight then warn the user it is not the optimal experience 
            /*if ((SystemParameters.PrimaryScreenWidth < OptimalScreenWidth) || (SystemParameters.PrimaryScreenHeight < OptimalScreenHeight))
            {
                if (MessageBox.Show(Properties.Resources.NotOptimalScreenResolutionMessage, Properties.Resources.NotOptimalScreenResolutionTitle, MessageBoxButton.YesNo) == MessageBoxResult.No) this.Close();
            }*/

            // Initialize components
            InitializeComponent();

            // Bind listner to scrollviwer scroll position change, and check scroll viewer position
            this.UpdateScrollButtonState();
            experienceButtonsScrollViewer.ScrollChanged += (o, e) => this.UpdateScrollButtonState();

            //Set Lenguage Dictionaries()
            SetLenguageDictionaries();

            // Initialize the experiences
            InitializeExperiences();

            // Clear and Add the wrap panel display content
            InitializeButtons();
            
            // Initialize the sensor chooser
            this.sensorChooser = new KinectSensorChooser();
            this.sensorChooser.KinectChanged += SensorChooserOnKinectChanged;
            this.sensorChooserUI.KinectSensorChooser = this.sensorChooser;
            this.sensorChooser.Start();

            // Initialize the movement detector
            this.movementDetector = new MouseMovementDetector(this);
            this.movementDetector.IsMovingChanged += this.OnIsMouseMovingChanged;
            this.movementDetector.Start();
            
        }

        /// <summary> Ask if you are sure to close the app. And performs the shutdown of the running elements.</summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (sensorChooser != null || movementDetector != null) // If its closing before creating kinect sensor or movementDetector it will not ask.
            {
                if (!closing)
                {
                    OnExitGrid.Visibility = Visibility.Visible;
                    e.Cancel = true;
                }
                else
                {
                    /// Actions needed to be done before shutdown I.E: shutdown the sensor and the movement detector.
                    this.sensorChooser.Stop();
                    this.movementDetector.Stop();
                }
            }
        }

        private bool closing = false;
        /// <summary> Handle a button click from the exit view. </summary>
        void Closing_YesButton(object sender, RoutedEventArgs e)
        {
            closing = true;          
            this.Close();
        }
        /// <summary> Handle a button click from the exit view. </summary>
        void Closing_NoButton(object sender, RoutedEventArgs e)
        {
            OnExitGrid.Visibility = Visibility.Hidden;
        }
        /// <summary> Handle the exit button. </summary>
        void Closing_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary> Called when the KinectSensorChooser gets a new sensor </summary>
        private void SensorChooserOnKinectChanged(object sender, KinectChangedEventArgs args)
        {
            if (args.OldSensor != null)
            {
                try
                {
                    args.OldSensor.DepthStream.Range = DepthRange.Default;
                    args.OldSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    args.OldSensor.DepthStream.Disable();
                    args.OldSensor.SkeletonStream.Disable();
                    //args.OldSensor.ColorStream.Disable();
                    //args.OldSensor.ColorFrameReady -= miKinect_ColorFrameReady;
                    //args.OldSensor.SkeletonFrameReady -= miKinect_SkeletonFrameReady;
                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features. E.g.: sensor might be abruptly unplugged.
                }
            }

            if (args.NewSensor != null)
            {
                try
                {
                    args.NewSensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                    args.NewSensor.SkeletonStream.Enable();
                    //args.OldSensor.ColorStream.Enable();
                    if (sensorChooser.Kinect == args.NewSensor)
                    {
                        //sensorChooser.Kinect.ColorFrameReady += miKinect_ColorFrameReady;
                        //sensorChooser.Kinect.SkeletonFrameReady += miKinect_SkeletonFrameReady;
                    }
                    try
                    {
                        args.NewSensor.DepthStream.Range = DepthRange.Near;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = true;
                    }
                    catch (InvalidOperationException)
                    {
                        // Non Kinect for Windows devices do not support Near mode, so reset back to default mode.
                        args.NewSensor.DepthStream.Range = DepthRange.Default;
                        args.NewSensor.SkeletonStream.EnableTrackingInNearRange = false;
                    }

                    kinectRegion.KinectSensor = args.NewSensor;

                }
                catch (InvalidOperationException)
                {
                    // KinectSensor might enter an invalid state while enabling/disabling streams or stream features. E.g.: sensor might be abruptly unplugged.
                }
            }
        }

        /// <summary> Shows/hides the window bezel, as appropriate. </summary>
        private void OnIsMouseMovingChanged(object sender, EventArgs e)
        {
            if (this.movementDetector.IsMoving)
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.Cursor = Cursors.Arrow;
            }
            else
            {
                this.WindowStyle = WindowStyle.None;

                // If the window is already full-screen, we must set it again else the window will appear under the Windows taskbar.
                if (this.WindowState == WindowState.Maximized)
                {

                    this.WindowState = WindowState.Normal;
                    this.WindowState = WindowState.Maximized;
                }

                this.Cursor = Cursors.None;
            }
        }
        #region ExperiencesModels --> Creation of the experiences list
        /*  #region Experiences as array v0.1
        /// <summary> Gets the observable collection of experiences selectable from the home screen </summary>
        public ExperienceOptionModel[] Experiences { get; private set; }

        /// <summary>
        /// Initialize the experience list with values
        /// Actually the values are just for testing
        /// Should read the experiences from other file afterwards
        /// </summary>
        /// <param name="n">Number of Experiences</param>
        private void InitializeExperiences(int n)
        {
            Experiences = new ExperienceOptionModel[n];

            for (int i = 0; i < n; i++)
            {
                Experiences[i] = new ExperienceOptionModel();

                Experiences[i].Name = "Experience: " + (i + 1);
                Experiences[i].ImageUri = new Uri(string.Format("pack://application:,,,/{0};component/{1}", Assembly.GetAssembly(typeof(MainWindow)).GetName().Name, "JustForTestingSources/03.png"));
                Experiences[i].Description = "This is a large description text just for testing how this is gonna work; Description of the experience #" + (i + 1);

            }
        }
        #endregion */
        #region Experiences as a resource arraylist v0.1.1
        /// <summary> Gets the observable collection of experiences selectable from the home screen </summary>
        public ObservableCollection<ExperienceModel> Experiences { get; private set; }
        private ObservableCollection<BitmapImage> images = new ObservableCollection<BitmapImage>();
        /// <summary>
        /// Initialize the experience list with values
        /// Actually the values are just for testing
        /// Should read the experiences from other file afterwards
        /// </summary>
        private void InitializeExperiences()
        {
            ArrayList ExperiencesList = (ArrayList)this.FindResource("ExperiencesList");
            Experiences = new ObservableCollection<ExperienceModel>();
            foreach (Object o in ExperiencesList)
            {
                Experiences.Add((ExperienceModel)o);
                images.Add(new BitmapImage(((ExperienceModel)o).ImageUri));
            }
        }
        /// <summary>
        /// Returns the experience of the unique given game
        /// </summary>
        /// <param name="n">Unique name of the experience</param>
        private ExperienceModel GetExperience(String name)
        {
            foreach (ExperienceModel experience in Experiences)
            {
                if (experience.Name.Equals(name))
                {
                    return experience;
                }
            }
            throw new InvalidOperationException(Properties.Resources.ExperienceNotFound);
        }

        private int ExperienceIndex(ExperienceModel experience)
        {
            return Experiences.IndexOf(experience);
        }


        #endregion
        #endregion

        #region Experience's buttons --> Initialize, OnHandPointerEnter, OnClick

        /// <summary> Clear the WrapPanel and Display the Experiences Buttons </summary>
        private void InitializeButtons()
        {
            // Clear out placeholder content
            experienceButtonsWrapPanel.Children.Clear();

            // Add in display context
            foreach (ExperienceModel experience in Experiences)
            {
                KinectTileButton newButton = new KinectTileButton { Content = experience.Name, Style = (Style)this.FindResource("MainMenuKinectTileButton") };
                KinectRegion.AddHandPointerEnterHandler(newButton, OnHandPointerEnter);
                newButton.MouseEnter += OnMouseEnter;
                newButton.Click += OnClick;
                experienceButtonsWrapPanel.Children.Add(newButton);
            }
        }
        /// <summary> Handle a button click from a experience button. </summary>
        void OnClick(object sender, RoutedEventArgs e)
        {
            var button = (KinectTileButton)e.OriginalSource;
            ExperienceModel experienceTile = GetExperience(button.Content as string);

            // Execute the Experience --> Yet on work
            var experience = ExperienceModel.GetNewTestingExperience(experienceTile.ExperienceClass, experienceTile.Description);

            this.ContentGrid.Children.Add(experience);
            e.Handled = true;
        }

        /// <summary> Handle a HandPointer enter in a experience button. </summary>
        private void OnHandPointerEnter(object sender, HandPointerEventArgs e)
        {
            KinectTileButton button = (KinectTileButton)sender;
            ExperienceModel experience = GetExperience(button.Content as string);
            ContentDescription.Text = experience.Description;
            ContentImage.Source = images[ExperienceIndex(experience)];
        }
        /// <summary> Handle a Mouse enter in a experience button. </summary>
        void OnMouseEnter(object sender, MouseEventArgs e)
        {
            KinectTileButton button = (KinectTileButton)sender;
            ExperienceModel experience = GetExperience(button.Content as string);
            ContentDescription.Text = experience.Description;
            ContentImage.Source = images[ExperienceIndex(experience)];
        }

        #endregion

        #region Functions and Variables for the scrolling functionality

        public static readonly DependencyProperty ScrollUpEnabledProperty = DependencyProperty.Register(
            "ScrollUpEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        public static readonly DependencyProperty ScrollDownEnabledProperty = DependencyProperty.Register(
            "ScrollDownEnabled", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));

        private const double ScrollErrorMargin = 0.001;

        private const int PixelScrollByAmount = 20;

        /// <summary> CLR Property Wrappers for ScrollUpEnabledProperty </summary>
        public bool ScrollUpEnabled
        {
            get
            {
                return (bool)GetValue(ScrollUpEnabledProperty);
            }

            set
            {
                this.SetValue(ScrollUpEnabledProperty, value);
            }
        }

        /// <summary> CLR Property Wrappers for ScrollDownEnabledProperty </summary>
        public bool ScrollDownEnabled
        {
            get
            {
                return (bool)GetValue(ScrollDownEnabledProperty);
            }

            set
            {
                this.SetValue(ScrollDownEnabledProperty, value);
            }
        }

        /// <summary> Handle paging right (next button). </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void ScrollUpButtonClick(object sender, RoutedEventArgs e)
        {
            experienceButtonsScrollViewer.ScrollToVerticalOffset(experienceButtonsScrollViewer.VerticalOffset - PixelScrollByAmount);
        }

        /// <summary> Handle paging left (previous button). </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        private void ScrollDownButtonClick(object sender, RoutedEventArgs e)
        {
            experienceButtonsScrollViewer.ScrollToVerticalOffset(experienceButtonsScrollViewer.VerticalOffset + PixelScrollByAmount);
        }

        /// <summary> Change button state depending on scroll viewer position </summary>
        private void UpdateScrollButtonState()
        {
            this.ScrollUpEnabled = experienceButtonsScrollViewer.VerticalOffset > ScrollErrorMargin;
            this.ScrollDownEnabled = experienceButtonsScrollViewer.VerticalOffset < experienceButtonsScrollViewer.ScrollableHeight - ScrollErrorMargin;
        }

        #endregion

        #region Language Manager

        ResourceDictionary ExperiencesDict;
        ResourceDictionary StringsDict;

        private void SetLenguageDictionaries()
        {
            // Create a new dictionary or remove the old one (Experiences)
            if (ExperiencesDict == null) ExperiencesDict = new ResourceDictionary();
            else this.Resources.MergedDictionaries.Remove(ExperiencesDict);

            // Create a new dictionary or remove the old one (Strings)
            if (StringsDict == null) StringsDict = new ResourceDictionary();
            else this.Resources.MergedDictionaries.Remove(StringsDict);

            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "es-ES":
                    ExperiencesDict.Source = new Uri("..\\Content\\ExperiencesList.es-ES.xaml", UriKind.Relative);
                    StringsDict.Source = new Uri("..\\Resources\\StringResources.es-ES.xaml", UriKind.Relative);
                    TitleLogo.Source = new BitmapImage(new Uri("..\\Resources\\Titulo.png", UriKind.Relative));
                    break;
                case "en-US":
                    ExperiencesDict.Source = new Uri("..\\Content\\ExperiencesList.en-US.xaml", UriKind.Relative);
                    StringsDict.Source = new Uri("..\\Resources\\StringResources.en-US.xaml", UriKind.Relative);
                    TitleLogo.Source = new BitmapImage(new Uri("..\\Resources\\Title.png", UriKind.Relative));
                    break;
                default:
                    ExperiencesDict.Source = new Uri("..\\Content\\ExperiencesList.en-US.xaml", UriKind.Relative);
                    StringsDict.Source = new Uri("..\\Resources\\StringResources.en-US.xaml", UriKind.Relative);
                    TitleLogo.Source = new BitmapImage(new Uri("..\\Resources\\Title.png", UriKind.Relative));
                    break;
            }
            this.Resources.MergedDictionaries.Add(ExperiencesDict);
            this.Resources.MergedDictionaries.Add(StringsDict);
        }

        private void OnEnglish_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.ToString() == "en-US") return;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            SetLenguageDictionaries();

            // Initialize the experiences
            InitializeExperiences();

            // Clear and Add the wrap panel display content
            InitializeButtons();
        }

        private void OnSpanish_Click(object sender, RoutedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentCulture.ToString() == "es-ES") return;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            SetLenguageDictionaries();

            // Initialize the experiences
            InitializeExperiences();

            // Clear and Add the wrap panel display content
            InitializeButtons();
        }

        #endregion

        #region Help Controller

        private const string NormalState = "Normal";
        private const string FadeInTransitionState = "FadeIn";
        private const string FadeOutTransitionState = "FadeOut";

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            if (HelpGrid.Visibility == Visibility.Hidden)
            {
                // Always go to normal state before a transition
                VisualStateManager.GoToElementState(HelpGrid, NormalState, false);
                VisualStateManager.GoToElementState(HelpGrid, FadeInTransitionState, false);
            }
            else
            {
                // Always go to normal state before a transition
                VisualStateManager.GoToElementState(HelpGrid, NormalState, false);
                VisualStateManager.GoToElementState(HelpGrid, FadeOutTransitionState, true);
            }
        }

        #endregion
    }
}
