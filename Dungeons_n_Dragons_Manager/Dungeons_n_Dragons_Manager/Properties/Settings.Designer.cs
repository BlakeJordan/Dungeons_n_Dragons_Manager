﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dungeons_n_Dragons_Manager.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double MainWindow_Top {
            get {
                return ((double)(this["MainWindow_Top"]));
            }
            set {
                this["MainWindow_Top"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public double MainWindow_Left {
            get {
                return ((double)(this["MainWindow_Left"]));
            }
            set {
                this["MainWindow_Left"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("600")]
        public double MainWindow_Height {
            get {
                return ((double)(this["MainWindow_Height"]));
            }
            set {
                this["MainWindow_Height"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("960")]
        public double MainWindow_Width {
            get {
                return ((double)(this["MainWindow_Width"]));
            }
            set {
                this["MainWindow_Width"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MainWindow_Maximized {
            get {
                return ((bool)(this["MainWindow_Maximized"]));
            }
            set {
                this["MainWindow_Maximized"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<Dungeons_n_Dragons_Manager.Models.Monster> CustomMonstersList {
            get {
                return ((global::System.Collections.Generic.List<Dungeons_n_Dragons_Manager.Models.Monster>)(this["CustomMonstersList"]));
            }
            set {
                this["CustomMonstersList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<Dungeons_n_Dragons_Manager.Models.Monster> DefaultMonstersList {
            get {
                return ((global::System.Collections.Generic.List<Dungeons_n_Dragons_Manager.Models.Monster>)(this["DefaultMonstersList"]));
            }
            set {
                this["DefaultMonstersList"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Generic.List<Dungeons_n_Dragons_Manager.Models.Character> CustomCharactersList {
            get {
                return ((global::System.Collections.Generic.List<Dungeons_n_Dragons_Manager.Models.Character>)(this["CustomCharactersList"]));
            }
            set {
                this["CustomCharactersList"] = value;
            }
        }
    }
}
