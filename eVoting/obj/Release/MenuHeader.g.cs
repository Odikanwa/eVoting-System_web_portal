﻿#pragma checksum "..\..\MenuHeader.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "671620A28AE677BEC2A7283DE49236A6BD132A5D2D217E320038857CDE913D48"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using eVoting;


namespace eVoting {
    
    
    /// <summary>
    /// MenuHeader
    /// </summary>
    public partial class MenuHeader : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\MenuHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\MenuHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu top_menu;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\MenuHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button current_user;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\MenuHeader.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button log_out;
        
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
            System.Uri resourceLocater = new System.Uri("/eVoting;component/menuheader.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MenuHeader.xaml"
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
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.top_menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            
            #line 25 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Home_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 28 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Year_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 31 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Organizations_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 32 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Offices_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 34 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Contestants_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 37 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Parties_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 41 "..\..\MenuHeader.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Voters_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.current_user = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\MenuHeader.xaml"
            this.current_user.Click += new System.Windows.RoutedEventHandler(this.Log_out_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.log_out = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\MenuHeader.xaml"
            this.log_out.Click += new System.Windows.RoutedEventHandler(this.Log_out_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

