// Updated by XamlIntelliSenseFileGenerator 12.05.2021 3:28:58
#pragma checksum "..\..\..\ProcessingPages\Processing_Resources.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B48FA0582D983BB799A055362BD6498B058E0C560A1F2A98013C9346ED920F63"
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


namespace VTManager.ProcssingPages
{


    /// <summary>
    /// Processing_Resources
    /// </summary>
    public partial class Processing_Resources : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 27 "..\..\..\ProcessingPages\Processing_Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label page_header;

#line default
#line hidden


#line 28 "..\..\..\ProcessingPages\Processing_Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid chart_items;

#line default
#line hidden


#line 34 "..\..\..\ProcessingPages\Processing_Resources.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid chart_items2;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VTManager;component/processingpages/processing_resources.xaml", System.UriKind.Relative);

#line 1 "..\..\..\ProcessingPages\Processing_Resources.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler)
        {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 9 "..\..\..\ProcessingPages\Processing_Resources.xaml"
                    ((VTManager.ProcssingPages.Processing_Resources)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.page_header = ((System.Windows.Controls.Label)(target));
                    return;
                case 3:
                    this.chart_items = ((System.Windows.Controls.Grid)(target));
                    return;
                case 4:
                    this.res1 = ((VTManager.VTManagerChart)(target));
                    return;
                case 5:
                    this.res2 = ((VTManager.VTManagerChart)(target));
                    return;
                case 6:
                    this.chart_items2 = ((System.Windows.Controls.Grid)(target));
                    return;
                case 7:
                    this.res3 = ((VTManager.VTManagerChart)(target));
                    return;
                case 8:
                    this.res4 = ((VTManager.VTManagerChart)(target));
                    return;
                case 9:
                    this.res5 = ((VTManager.VTManagerChart)(target));
                    return;
                case 10:
                    this.res6 = ((VTManager.VTManagerChart)(target));
                    return;
                case 11:
                    this.res7 = ((VTManager.VTManagerChart)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal VTManager.Interactive.VTManagerChart res1;
        internal VTManager.Interactive.VTManagerChart res2;
        internal VTManager.Interactive.VTManagerChart res3;
        internal VTManager.Interactive.VTManagerChart res4;
        internal VTManager.Interactive.VTManagerChart res5;
        internal VTManager.Interactive.VTManagerChart res6;
        internal VTManager.Interactive.VTManagerChart res7;
    }
}

