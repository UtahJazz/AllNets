﻿#pragma checksum "C:\Users\Utah_Jazz\Desktop\AllNets\AllNets\TwitterLogIn.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E5C2A7C358B57C1B5EC3814E97CBC739"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace AllNets {
    
    
    public partial class TwitterLogIn : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid Container;
        
        internal System.Windows.VisualStateGroup SettingsStateGroup;
        
        internal System.Windows.VisualState SettingsClosedState;
        
        internal System.Windows.VisualState SettingsOpenState;
        
        internal System.Windows.Controls.Grid SettingsPane;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/AllNets;component/TwitterLogIn.xaml", System.UriKind.Relative));
            this.Container = ((System.Windows.Controls.Grid)(this.FindName("Container")));
            this.SettingsStateGroup = ((System.Windows.VisualStateGroup)(this.FindName("SettingsStateGroup")));
            this.SettingsClosedState = ((System.Windows.VisualState)(this.FindName("SettingsClosedState")));
            this.SettingsOpenState = ((System.Windows.VisualState)(this.FindName("SettingsOpenState")));
            this.SettingsPane = ((System.Windows.Controls.Grid)(this.FindName("SettingsPane")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
        }
    }
}

