﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Serko.Core.Domain.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Serko.Core.Domain.Resources.Messages", typeof(Messages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The authentication is null..
        /// </summary>
        public static string ERROR_AUTHENTICATION_ISNULL {
            get {
                return ResourceManager.GetString("ERROR_AUTHENTICATION_ISNULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error bad request..
        /// </summary>
        public static string ERROR_BAD_REQUEST {
            get {
                return ResourceManager.GetString("ERROR_BAD_REQUEST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to We had a problem during the process of saving the data..
        /// </summary>
        public static string ERROR_COMMIT {
            get {
                return ResourceManager.GetString("ERROR_COMMIT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} can&apos;t be null..
        /// </summary>
        public static string ERROR_FIELD_ISNULL {
            get {
                return ResourceManager.GetString("ERROR_FIELD_ISNULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} is invalid..
        /// </summary>
        public static string ERROR_INVALID_AUTHENTICATION {
            get {
                return ResourceManager.GetString("ERROR_INVALID_AUTHENTICATION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} not found..
        /// </summary>
        public static string ERROR_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERROR_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} added successfully..
        /// </summary>
        public static string SUCCESS_ADD {
            get {
                return ResourceManager.GetString("SUCCESS_ADD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} was successfully created..
        /// </summary>
        public static string SUCCESS_CREATED {
            get {
                return ResourceManager.GetString("SUCCESS_CREATED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} deleted successfully..
        /// </summary>
        public static string SUCCESS_DELETE {
            get {
                return ResourceManager.GetString("SUCCESS_DELETE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No records were found for this search..
        /// </summary>
        public static string SUCCESS_NO_RECORDS {
            get {
                return ResourceManager.GetString("SUCCESS_NO_RECORDS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The {0} updated successfully..
        /// </summary>
        public static string SUCCESS_UPDATE {
            get {
                return ResourceManager.GetString("SUCCESS_UPDATE", resourceCulture);
            }
        }
    }
}