﻿#pragma checksum "..\..\Synchronize.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "93FA4669F83E778EEC5B816D5F9E05100E1F7DF2FEA6C099042AB2F8E9D14231"
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
    /// Synchronize
    /// </summary>
    public partial class Synchronize : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button year_button;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button office_button;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button party_button;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button contestant_button;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button voters_button;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button organization_button;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sync_votes_button;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Synchronize.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label sync_count;
        
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
            System.Uri resourceLocater = new System.Uri("/eVoting;component/synchronize.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Synchronize.xaml"
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
            this.year_button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Synchronize.xaml"
            this.year_button.Click += new System.Windows.RoutedEventHandler(this.Year_button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.office_button = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Synchronize.xaml"
            this.office_button.Click += new System.Windows.RoutedEventHandler(this.Office_button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.party_button = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Synchronize.xaml"
            this.party_button.Click += new System.Windows.RoutedEventHandler(this.Party_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.contestant_button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Synchronize.xaml"
            this.contestant_button.Click += new System.Windows.RoutedEventHandler(this.Contestant_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.voters_button = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Synchronize.xaml"
            this.voters_button.Click += new System.Windows.RoutedEventHandler(this.Voters_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.organization_button = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Synchronize.xaml"
            this.organization_button.Click += new System.Windows.RoutedEventHandler(this.Organization_button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.sync_votes_button = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Synchronize.xaml"
            this.sync_votes_button.Click += new System.Windows.RoutedEventHandler(this.Sync_votes_button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.sync_count = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
