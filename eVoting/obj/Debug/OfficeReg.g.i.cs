﻿#pragma checksum "..\..\OfficeReg.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B553C9AB401D0E282DCC0CB527945AB35E121021"
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
    /// OfficeReg
    /// </summary>
    public partial class OfficeReg : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border office_reg_border;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label office_reg_label;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button office_reg_button;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox office_name;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox office_description;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox org_list;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid officeDataGrid;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button office_reg_button_edit;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label selected_item_label;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\OfficeReg.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button office_reg_button_delete;
        
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
            System.Uri resourceLocater = new System.Uri("/eVoting;component/officereg.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OfficeReg.xaml"
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
            this.office_reg_border = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.office_reg_label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.office_reg_button = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\OfficeReg.xaml"
            this.office_reg_button.Click += new System.Windows.RoutedEventHandler(this.office_reg_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.office_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.office_description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.org_list = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.officeDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 40 "..\..\OfficeReg.xaml"
            this.officeDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OfficeDataGridSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.office_reg_button_edit = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\OfficeReg.xaml"
            this.office_reg_button_edit.Click += new System.Windows.RoutedEventHandler(this.edit_button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.selected_item_label = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.office_reg_button_delete = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\OfficeReg.xaml"
            this.office_reg_button_delete.Click += new System.Windows.RoutedEventHandler(this.delete_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

