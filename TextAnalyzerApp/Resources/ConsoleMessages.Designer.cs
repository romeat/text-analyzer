﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TextAnalyzerApp.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ConsoleMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ConsoleMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TextAnalyzerApp.Resources.ConsoleMessages", typeof(ConsoleMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Elapsed time, ms: .
        /// </summary>
        internal static string ElapsedTime {
            get {
                return ResourceManager.GetString("ElapsedTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type path to your file:.
        /// </summary>
        internal static string EnterFilepath {
            get {
                return ResourceManager.GetString("EnterFilepath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to process file. Error: .
        /// </summary>
        internal static string FailedToProcessFile {
            get {
                return ResourceManager.GetString("FailedToProcessFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} most frequent triplets:.
        /// </summary>
        internal static string MostFrequentTriplets {
            get {
                return ResourceManager.GetString("MostFrequentTriplets", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File does not exist.
        /// </summary>
        internal static string NoSuchFile {
            get {
                return ResourceManager.GetString("NoSuchFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No triplets found in the file.
        /// </summary>
        internal static string NoTripletsFound {
            get {
                return ResourceManager.GetString("NoTripletsFound", resourceCulture);
            }
        }
    }
}
