﻿#pragma checksum "..\..\EditCustomer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C180F6E2C18F0508AC6753F8562482AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using OrdersRegistration.WPF;
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


namespace OrdersRegistration.WPF {
    
    
    /// <summary>
    /// EditCustomer
    /// </summary>
    public partial class EditCustomer : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxEditCustomer;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxEditCustomerName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditCustomer;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteCustomer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxEditCustomerMail;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxEditCustomerPhone;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelEditCustomerName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelEditCustomerMail;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EditCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelEditCustomerPhone;
        
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
            System.Uri resourceLocater = new System.Uri("/OrdersRegistration.WPF;component/editcustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditCustomer.xaml"
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
            this.comboBoxEditCustomer = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\EditCustomer.xaml"
            this.comboBoxEditCustomer.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboBoxEditCustomer_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBoxEditCustomerName = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\EditCustomer.xaml"
            this.textBoxEditCustomerName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBoxEditCustomerName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnEditCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\EditCustomer.xaml"
            this.btnEditCustomer.Click += new System.Windows.RoutedEventHandler(this.buttonEditCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeleteCustomer = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\EditCustomer.xaml"
            this.btnDeleteCustomer.Click += new System.Windows.RoutedEventHandler(this.buttonDeleteCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBoxEditCustomerMail = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\EditCustomer.xaml"
            this.textBoxEditCustomerMail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBoxEditCustomerMail_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBoxEditCustomerPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\EditCustomer.xaml"
            this.textBoxEditCustomerPhone.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBoxEditCustomerPhone_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.labelEditCustomerName = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.labelEditCustomerMail = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.labelEditCustomerPhone = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

