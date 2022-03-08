﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevTools.Plugin.DBTool.Oracle.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DevTools.Plugin.DBTool.Oracle.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   重写当前线程的 CurrentUICulture 属性，对
        ///   使用此强类型资源类的所有资源查找执行重写。
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
        ///   查找类似 SELECT
        ///    NAME
        ///FROM
        ///    V$DATABASE
        ///ORDER BY
        ///    NAME 的本地化字符串。
        /// </summary>
        internal static string SQL_GetDatabaseName {
            get {
                return ResourceManager.GetString("SQL_GetDatabaseName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///    ATCOL.COLUMN_ID     AS &quot;ID&quot;
        ///    , ATCOL.COLUMN_NAME AS &quot;Name&quot;
        ///    , ATCOL.DATA_TYPE   AS &quot;SystemType&quot;
        ///    , ATCOL.DATA_LENGTH AS &quot;Length&quot;
        ///FROM
        ///    ALL_TAB_COLUMNS ATCOL
        ///WHERE
        ///    ATCOL.TABLE_NAME = :TABLE_NAME
        ///ORDER BY
        ///    ATCOL.COLUMN_ID 的本地化字符串。
        /// </summary>
        internal static string SQL_GetTableColumns {
            get {
                return ResourceManager.GetString("SQL_GetTableColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///    ROWNUM              AS &quot;IndexId&quot;
        ///    , AIDX.INDEX_NAME   AS &quot;IndexName&quot;
        ///    , AICOL.COLUMN_NAME AS &quot;ColumnName&quot;
        ///    , CASE AICOL.DESCEND
        ///      WHEN &apos;Y&apos; THEN &apos;DESC&apos;
        ///      WHEN &apos;N&apos; THEN &apos;ASC&apos;
        ///      ELSE &apos;ASC&apos; END    AS &quot;Sort&quot;
        ///    , CASE 
        ///      WHEN ACON.CONSTRAINT_TYPE = &apos;P&apos; AND AIDX.UNIQUENESS = &apos;UNIQUE&apos; THEN &apos;PK&apos;
        ///      ELSE &apos;&apos; END       AS &quot;PrimaryKey&quot;
        ///    , CASE AIDX.STATUS
        ///      WHEN &apos;UNUSABLE&apos; THEN &apos;TRUE&apos;
        ///      WHEN &apos;VALID&apos; THEN &apos;FALSE&apos;
        ///      ELSE &apos;FALSE&apos; END  AS &quot;Disabled&quot;
        ///FROM [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string SQL_GetTableIndex {
            get {
                return ResourceManager.GetString("SQL_GetTableIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 SELECT
        ///    TABLE_NAME
        ///FROM
        ///    ALL_TABLES
        ///WHERE
        ///    TABLESPACE_NAME IS NOT NULL
        ///    AND TABLESPACE_NAME &lt;&gt; &apos;SYSTEM&apos;
        ///    AND TABLESPACE_NAME &lt;&gt; &apos;SYSAUX&apos;
        ///ORDER BY
        ///    TABLE_NAME 的本地化字符串。
        /// </summary>
        internal static string SQL_GetTableName {
            get {
                return ResourceManager.GetString("SQL_GetTableName", resourceCulture);
            }
        }
    }
}
