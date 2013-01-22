using System;
using System.Collections.Generic;
using YAXLib;

namespace DevTools.Language
{
    /// <summary>
    /// 语言对象
    /// </summary>
    public class Language
    {
        [YAXSerializeAs("name")]
        [YAXAttributeForClass()]
        public string Name { get; set; }
        
        [YAXSerializeAs("display")]
        [YAXAttributeForClass()]
        public string Display { get; set; }
        
        [YAXSerializeAs("Modules")]
        [YAXCollection(YAXCollectionSerializationTypes.Recursive,
                       EachElementName="Module")]
        public List<Module> Modules { get; set; }
        
        public Language()
        {
            this.Modules = new List<Module>();
        }
    }
}
