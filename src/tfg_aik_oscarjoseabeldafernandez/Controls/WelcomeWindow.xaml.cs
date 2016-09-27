using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;
using TFG_AIK_OscarJoseAbeldaFernandez.Experiences;

namespace TFG_AIK_OscarJoseAbeldaFernandez.Controls
{
    /// <summary>
    /// Interaction logic for WelcomeWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : UserControl
    {
        /// <summary>
        /// Name of the non-transitioning visual state.
        /// </summary>
        private const string NormalState = "Normal";

        /// <summary>
        /// Name of the fade in transition.
        /// </summary>
        private const string FadeInTransitionState = "FadeIn";

        /// <summary>
        /// Name of the fade out transition.
        /// </summary>
        private const string FadeOutTransitionState = "FadeOut";

        private ExperienceInterface parentContent;

        public ExperienceInterface ParentContent { get { return parentContent; } set { parentContent = value; } }

        public WelcomeWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the full screen view of the image
        /// </summary>
        private void LevelEasy_Click(object sender, RoutedEventArgs e)
        {
            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(OverlayGrid, NormalState, false);
            VisualStateManager.GoToElementState(OverlayGrid, FadeOutTransitionState, true);

            parentContent.Retry(0);
        }

        public void Show()
        {
            parentContent.Pause();

            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(OverlayGrid, NormalState, false);
            VisualStateManager.GoToElementState(OverlayGrid, FadeInTransitionState, false);
        }

        /// <summary>
        /// Close the full screen view of the image
        /// </summary>
        private void LevelMedium_Click(object sender, RoutedEventArgs e)
        {
            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(OverlayGrid, NormalState, false);
            VisualStateManager.GoToElementState(OverlayGrid, FadeOutTransitionState, true);

            parentContent.Retry(1);
        }

        /// <summary>
        /// Close the full screen view of the image
        /// </summary>
        private void LevelHard_Click(object sender, RoutedEventArgs e)
        {
            // Always go to normal state before a transition
            VisualStateManager.GoToElementState(OverlayGrid, NormalState, false);
            VisualStateManager.GoToElementState(OverlayGrid, FadeOutTransitionState, true);

            parentContent.Retry(2);
        }
    }
}
