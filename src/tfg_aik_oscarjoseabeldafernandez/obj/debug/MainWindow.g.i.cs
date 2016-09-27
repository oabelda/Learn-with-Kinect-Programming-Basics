﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5B7AE3081869C685C17F76AB3AFC9A5C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Kinect.Toolkit;
using Microsoft.Kinect.Toolkit.Controls;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TFG_AIK_OscarJoseAbeldaFernandez.Controls;
using TFG_AIK_OscarJoseAbeldaFernandez.Styles;


namespace TFG_AIK_OscarJoseAbeldaFernandez {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TFG_AIK_OscarJoseAbeldaFernandez.MainWindow TFGMainWindow;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectRegion kinectRegion;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid KinectRegionGrid;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentGrid;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.KinectSensorChooserUI sensorChooserUI;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image TitleLogo;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer experienceButtonsScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel experienceButtonsWrapPanel;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ContentImage;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ContentDescription;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HelpGrid;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualStateGroup TransitionStates;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState Normal;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState FadeIn;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.VisualState FadeOut;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid OnExitGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TFG_AIK_OscarJoseAbeldaFernandez;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TFGMainWindow = ((TFG_AIK_OscarJoseAbeldaFernandez.MainWindow)(target));
            
            #line 17 "..\..\MainWindow.xaml"
            this.TFGMainWindow.Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.kinectRegion = ((Microsoft.Kinect.Toolkit.Controls.KinectRegion)(target));
            return;
            case 3:
            this.KinectRegionGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.ContentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.sensorChooserUI = ((Microsoft.Kinect.Toolkit.KinectSensorChooserUI)(target));
            return;
            case 6:
            
            #line 37 "..\..\MainWindow.xaml"
            ((Microsoft.Kinect.Toolkit.Controls.KinectCircleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Closing_Button);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TitleLogo = ((System.Windows.Controls.Image)(target));
            return;
            case 8:
            
            #line 40 "..\..\MainWindow.xaml"
            ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target)).Click += new System.Windows.RoutedEventHandler(this.OnEnglish_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 45 "..\..\MainWindow.xaml"
            ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target)).Click += new System.Windows.RoutedEventHandler(this.OnSpanish_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.experienceButtonsScrollViewer = ((Microsoft.Kinect.Toolkit.Controls.KinectScrollViewer)(target));
            return;
            case 11:
            this.experienceButtonsWrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 12:
            this.ContentImage = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.ContentDescription = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.HelpGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 15:
            this.TransitionStates = ((System.Windows.VisualStateGroup)(target));
            return;
            case 16:
            this.Normal = ((System.Windows.VisualState)(target));
            return;
            case 17:
            this.FadeIn = ((System.Windows.VisualState)(target));
            return;
            case 18:
            this.FadeOut = ((System.Windows.VisualState)(target));
            return;
            case 19:
            
            #line 155 "..\..\MainWindow.xaml"
            ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target)).Click += new System.Windows.RoutedEventHandler(this.HelpButton_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.OnExitGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 21:
            
            #line 172 "..\..\MainWindow.xaml"
            ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Closing_YesButton);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 173 "..\..\MainWindow.xaml"
            ((Microsoft.Kinect.Toolkit.Controls.KinectTileButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Closing_NoButton);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

