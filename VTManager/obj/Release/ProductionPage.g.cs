﻿#pragma checksum "..\..\ProductionPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CD31BA21C36892706F0A7BA78816A19DFEFCB1F0D854E435B3829FE080F1A288"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using System.Windows.Forms.Integration;
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
using VTManager;


namespace VTManager {
    
    
    /// <summary>
    /// ProductionPage
    /// </summary>
    public partial class ProductionPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\ProductionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label item1;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ProductionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label item2;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ProductionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame item_frame;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ProductionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid footer_buttons_grid;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\ProductionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label home;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\ProductionPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label refresh;
        
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
            System.Uri resourceLocater = new System.Uri("/VTManager;component/productionpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProductionPage.xaml"
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
            this.item1 = ((System.Windows.Controls.Label)(target));
            
            #line 32 "..\..\ProductionPage.xaml"
            this.item1.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.item1_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.item2 = ((System.Windows.Controls.Label)(target));
            
            #line 33 "..\..\ProductionPage.xaml"
            this.item2.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.item2_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.item_frame = ((System.Windows.Controls.Frame)(target));
            return;
            case 4:
            this.footer_buttons_grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.home = ((System.Windows.Controls.Label)(target));
            
            #line 64 "..\..\ProductionPage.xaml"
            this.home.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.home_MouseDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.refresh = ((System.Windows.Controls.Label)(target));
            
            #line 78 "..\..\ProductionPage.xaml"
            this.refresh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.refresh_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

