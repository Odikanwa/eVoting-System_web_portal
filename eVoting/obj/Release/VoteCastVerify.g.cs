﻿#pragma checksum "..\..\VoteCastVerify.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "587A86F823D9643AF2DFC492AE5795C2027ED87AEDD7574ED67A55B3825325C7"
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
    /// VoteCastVerify
    /// </summary>
    public partial class VoteCastVerify : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\VoteCastVerify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border verify_reg_border;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\VoteCastVerify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label verify_reg_label;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\VoteCastVerify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button verify_button;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\VoteCastVerify.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox org_code;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\VoteCastVerify.xaml"
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
            System.Uri resourceLocater = new System.Uri("/eVoting;component/votecastverify.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VoteCastVerify.xaml"
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
            this.verify_reg_border = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.verify_reg_label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.verify_button = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\VoteCastVerify.xaml"
            this.verify_button.Click += new System.Windows.RoutedEventHandler(this.Verify_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.org_code = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.log_out = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\VoteCastVerify.xaml"
            this.log_out.Click += new System.Windows.RoutedEventHandler(this.Log_out_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

