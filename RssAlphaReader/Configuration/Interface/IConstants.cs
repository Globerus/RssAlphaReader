using System;
using System.Collections.Generic;

namespace RssAlphaReader.Configuration.Interface
{
    public interface IConstants
    {
        Dictionary<string, Type> AttributeToType { get; set; }
        Dictionary<string, string> AttributeToProperty { get; set; }
        Dictionary<string, string> AttributeValueToProperty { get; set; }
        Dictionary<string, Type> ElementToType { get; set; }
        Dictionary<string, string> ElementToProperty { get; set; }
        Dictionary<string, string> ElementValueToProperty { get; set; }
    }
}
