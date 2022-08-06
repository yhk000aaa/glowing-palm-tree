using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventConfig : NSConfigObject
{
    public string name { get; private set; }
    public string type { get; private set; }
    public int value { get; private set; }
    public string objectClassName => ObjectClassNames.objectValue(this.type, "EmptyEventObject");
    
    private static Dictionary<string, string> ObjectClassNames = new Dictionary<string, string>()
    {
        {"useWalter", "EmptyEventObject"},
    };
    
    public override void initializeByParameters(Dictionary<string, object> parameters)
    {
        base.initializeByParameters(parameters);

        this.name = parameters.stringValue("name");
        this.type = parameters.stringValue("type");
        this.value = parameters.intValue("value");
    }
}
