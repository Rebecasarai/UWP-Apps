﻿#pragma checksum "C:\Users\icastillo\Downloads\Solarizr Con Vista About\Solarizr\Solarizr\Views\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "322D7568B3E630FDC4763DF1E2CF5820"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solarizr.Views
{
    partial class Login : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.barrasuperior = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 2:
                {
                    this.txtUsuario = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3:
                {
                    this.txtPassword = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.checbox = (global::Windows.UI.Xaml.Controls.CheckBox)(target);
                }
                break;
            case 5:
                {
                    this.buttonlogin = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 25 "..\..\..\Views\Login.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.buttonlogin).Click += this.login_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.textSol = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

