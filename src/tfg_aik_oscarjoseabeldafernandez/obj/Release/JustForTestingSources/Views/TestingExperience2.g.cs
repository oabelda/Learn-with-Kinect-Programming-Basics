﻿#pragma checksum "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3E25D16A4993E363BDF4CE5B6922ACA2"
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


namespace TFG_AIK_OscarJoseAbeldaFernandez.JustForTestingSources.Views {
    
    
    /// <summary>
    /// TestingExperience2
    /// </summary>
    public partial class TestingExperience2 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard OnLoadedStoryboard_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock messageTextBlock;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu PromptMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/TFG_AIK_OscarJoseAbeldaFernandez;component/justfortestingsources/views/testingex" +
                    "perience2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 25 "..\..\..\..\JustForTestingSources\Views\TestingExperience2.xaml"
            ((System.Windows.Media.Animation.Storyboard)(target)).Completed += new System.EventHandler(this.OnUnloadedStoryboardCompleted);
            
            #line default
            #line hidden
            return;
            case 2:
            this.OnLoadedStoryboard_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.messageTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.PromptMenu = ((TFG_AIK_OscarJoseAbeldaFernandez.Controls.PromptMenu)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

