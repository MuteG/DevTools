﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34209
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevTools.Plugin.DBTool.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DevTools.Plugin.DBTool.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
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
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap ActionAdd {
            get {
                object obj = ResourceManager.GetObject("ActionAdd", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap ActionRemove {
            get {
                object obj = ResourceManager.GetObject("ActionRemove", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap database {
            get {
                object obj = ResourceManager.GetObject("database", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        /// </summary>
        internal static System.Drawing.Bitmap refresh {
            get {
                object obj = ResourceManager.GetObject("refresh", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   SELECT [NAME]
        ///FROM Master..SysDatabases 
        ///WHERE [NAME] NOT IN (&apos;master&apos;, &apos;model&apos;, &apos;msdb&apos;, &apos;tempdb&apos;)
        ///ORDER BY NAME に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SQL_GetDatabaseName {
            get {
                return ResourceManager.GetString("SQL_GetDatabaseName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   SELECT [name] AS PROCEDURE_NAME
        ///FROM sys.procedures
        ///WHERE type=&apos;P&apos;
        ///    AND is_ms_shipped = 0
        ///    AND name not like &apos;sp_%&apos;
        ///ORDER BY [name] に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SQL_GetStoreProcedureName {
            get {
                return ResourceManager.GetString("SQL_GetStoreProcedureName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   -- 0：表名
        ///SELECT
        ///    ID           = col.colorder, 
        ///    [Name]       = col.name,
        ///    [SystemType] = types.name, 
        ///    [Length]     = CAST(CASE WHEN types.name IN (N&apos;nchar&apos;, N&apos;nvarchar&apos;) AND col.length &lt;&gt; -1 THEN col.length/2 
        ///                             ELSE col.length END
        ///                        AS int)
        ///FROM
        ///    syscolumns col 
        ///    LEFT JOIN systypes types
        ///        ON col.xtype = types.xusertype 
        ///    INNER JOIN sysobjects obj
        ///        ON col.id     = obj.id
        ///        AND obj.xtype = &apos;U&apos;
        ///        AND [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SQL_GetTableColumns {
            get {
                return ResourceManager.GetString("SQL_GetTableColumns", resourceCulture);
            }
        }
        
        /// <summary>
        ///   -- 0：表名
        ///SELECT
        ///    IndexId     = idx.indid,
        ///    IndexName   = idx.Name,
        ///    ColumnName  = col.Name,
        ///    Sort        = CASE INDEXKEY_PROPERTY(idx.id, idx.indid, idxk.keyno, &apos;IsDescending&apos;)
        ///                  WHEN 1 THEN &apos;DESC&apos;
        ///                  WHEN 0 THEN &apos;ASC&apos;
        ///                  ELSE &apos;&apos; END,
        ///    PrimaryKey  = CASE objPK.xtype
        ///                  WHEN &apos;PK&apos; THEN &apos;PK&apos;
        ///                  ELSE &apos;&apos;END,
        ///    [Disabled]  = &apos;&apos; --只有SQL Server 2005之后才支持“禁用索引”功能，为了兼容性，此处设置为“不禁用”
        ///FROM
        ///    sysindexes idx
        ///    INN [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SQL_GetTableIndex {
            get {
                return ResourceManager.GetString("SQL_GetTableIndex", resourceCulture);
            }
        }
        
        /// <summary>
        ///   SELECT [name] AS TABLE_NAME
        ///FROM dbo.sysobjects
        ///WHERE OBJECTPROPERTY(id, N&apos;IsTable&apos;) = 1
        ///    AND xtype=&apos;U&apos;
        ///    AND [name] NOT IN (&apos;dtproperties&apos;, &apos;sysdiagrams&apos;)
        ///ORDER BY [name] に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string SQL_GetTableName {
            get {
                return ResourceManager.GetString("SQL_GetTableName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   /// &lt;summary&gt;
        ////// {0}
        ////// &lt;/summary&gt;
        ///public sealed class {0}
        ///{{
        ///{1}
        ///{2}
        ///}} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_CSharpClassBody {
            get {
                return ResourceManager.GetString("Template_CSharpClassBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///       /// &lt;summary&gt;
        ///    /// 返回哈希代码
        ///    /// &lt;/summary&gt;
        ///    /// &lt;returns&gt;返回哈希代码&lt;/returns&gt;
        ///    public override int GetHashCode()
        ///    {{
        ///        return base.GetHashCode();
        ///    }}
        ///
        ///    /// &lt;summary&gt;
        ///    /// 比较两个对象是否相等
        ///    /// &lt;/summary&gt;
        ///    /// &lt;param name=&quot;obj&quot;&gt;要进行比较的对象&lt;/param&gt;
        ///    /// &lt;returns&gt;如果两个对象的主键相等，则返回true；否则返回false&lt;/returns&gt;
        ///    public override bool Equals(object obj)
        ///    {{
        ///        {0} another = obj as {0};
        ///        return {1};
        ///    }} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_CSharpClassEquals {
            get {
                return ResourceManager.GetString("Template_CSharpClassEquals", resourceCulture);
            }
        }
        
        /// <summary>
        ///               another.{0} == this.{0} &amp;&amp; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_CSharpClassEqualsProperties {
            get {
                return ResourceManager.GetString("Template_CSharpClassEqualsProperties", resourceCulture);
            }
        }
        
        /// <summary>
        ///       private {0} {1};
        ///    /// &lt;summary&gt;
        ///    /// 获取或设置{2}
        ///    /// &lt;/summary&gt;
        ///    public {0} {2}
        ///    {{
        ///        set {{ {1} = value; }}
        ///        get {{ return {1}; }}
        ///    }} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_CSharpProperty {
            get {
                return ResourceManager.GetString("Template_CSharpProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   
        ////// &lt;summary&gt;
        ////// 
        ////// &lt;/summary&gt;
        ////// &lt;param name=&quot;{0}&quot;&gt;&lt;/param&gt;
        ///public void {1}({2} {0})
        ///{{
        ///    SqlParameter[] param =
        ///	{{
        ///	    {3}
        ///    }};
        ///    sqlHelper.ExecuteNonQuery(&quot;这里替换成数据库连接字符串&quot;, &quot;{1}&quot;, param);
        ///}} に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_CSharpStoreProcedure_Body {
            get {
                return ResourceManager.GetString("Template_CSharpStoreProcedure_Body", resourceCulture);
            }
        }
        
        /// <summary>
        ///       new SqlParameter(&quot;@{0}&quot;, {1}.{0}), に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_CSharpStoreProcedure_Parameter {
            get {
                return ResourceManager.GetString("Template_CSharpStoreProcedure_Parameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///    に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_StoreProcedureBody {
            get {
                return ResourceManager.GetString("Template_StoreProcedureBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N&apos;[dbo].[{0}]&apos;) AND type in (N&apos;P&apos;, N&apos;PC&apos;))
        ///DROP PROCEDURE [dbo].[{0}]
        ///GO
        ///SET ANSI_NULLS ON
        ///GO
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ////* ********************************************************************
        ///** 文件 : PRO_{0}.SQL
        ///** 名称 : {0}
        ///** 说明 : {1}
        ///** 作者 : {5}
        ///** 日期 : {6}
        ///** 返回 : {2}
        ///**
        ///** Input                说明
        ///** -------------------- ----------------------------------------------
        ///{3}
        ///**
        ///** Output               说明
        ///** --------------- [残りの文字列は切り詰められました]&quot;; に類似しているローカライズされた文字列を検索します。
        /// </summary>
        internal static string Template_StoreProcedureHeader {
            get {
                return ResourceManager.GetString("Template_StoreProcedureHeader", resourceCulture);
            }
        }
    }
}
