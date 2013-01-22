using System;
using System.Collections.Generic;
using YAXLib;

namespace DevTools.Language
{
    /// <summary>
    /// 模块多语言
    /// </summary>
    public class Module
    {
        [YAXSerializeAs("name")]
        [YAXAttributeForClass()]
        public string Name { get; set; }
        
        [YAXDictionary(EachPairName="Item", KeyName="name", ValueName="value",
                       SerializeKeyAs=YAXNodeTypes.Attribute,
                       SerializeValueAs=YAXNodeTypes.Attribute)]
        [YAXSerializeAs("Items")]
        public Dictionary<string, string> Items { get; set; }
        
        public Module()
        {
            this.Items = new Dictionary<string, string>();
        }
    }
}
