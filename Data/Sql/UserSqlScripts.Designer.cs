﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockPickem.Data.Sql {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class UserSqlScripts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UserSqlScripts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("StockPickem.Data.Sql.UserSqlScripts", typeof(UserSqlScripts).Assembly);
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
        ///   Looks up a localized string similar to CREATE TABLE Question (
        ///	Id bigint PRIMARY KEY,
        ///	Version int NOT NULL,
        ///	Created_At date NOT NULL,
        ///	Updated_On date NOT NULL,
        ///	IsActive boolean NOT NULL,
        ///	IsLocked boolean NOT NULL,
        ///
        ///	Text text,
        ///	Title text,
        ///	User_Id int,
        ///	Votes_Id int,
        ///	Answers_Id int
        ///);
        ///CREATE TABLE Answer (
        ///	Text text,
        ///	IsAnswer int,
        ///	User_Id int,
        ///	Comment_Id int,
        ///	Id bigint,
        ///	Version int,
        ///	Created_At date,
        ///	Updated_On date
        ///);
        ///CREATE TABLE _User (
        ///	Id bigint PRIMARY KEY,
        ///	Version int NOT NULL,
        ///	Created_At date N [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Create_Tables {
            get {
                return ResourceManager.GetString("Create_Tables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DROP TABLE IF EXISTS Question;
        ///DROP TABLE IF EXISTS Answer;
        ///DROP TABLE IF EXISTS _User;
        ///DROP TABLE IF EXISTS Comment;
        ///DROP TABLE IF EXISTS Vote;
        ///DROP TABLE IF EXISTS Tag;
        ///.
        /// </summary>
        internal static string Drop_Tables {
            get {
                return ResourceManager.GetString("Drop_Tables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///INSERT INTO
        ///	_user (
        ///		id,
        ///		version,
        ///		created_at,
        ///		updated_on,
        ///		isactive,
        ///		islocked,
        ///
        ///		usergroup_id,
        ///		password,
        ///		username
        ///	)
        ///	VALUES (
        ///		@id,
        ///		@version,
        ///		@created_at,
        ///		@updated_on,
        ///		@isactive,
        ///		@islocked,
        ///
        ///		@usergroup_id,
        ///		@password,
        ///		@username
        ///	);.
        /// </summary>
        internal static string Insert_User {
            get {
                return ResourceManager.GetString("Insert_User", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from _user;.
        /// </summary>
        internal static string Read_All_Users {
            get {
                return ResourceManager.GetString("Read_All_Users", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select * from _user where Id = @Id;.
        /// </summary>
        internal static string Read_User {
            get {
                return ResourceManager.GetString("Read_User", resourceCulture);
            }
        }
    }
}