using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConfig : NSConfigObject
{
    public string name { get; private set; }
    public string type { get; private set; }
    
    public int value  { get; private set; }

    public string objectClassName => ObjectClassNames.objectValue(this.type, "SailRoomObject");
    
    private static Dictionary<string, string> ObjectClassNames = new Dictionary<string, string>()
    {
        {"sail", "SailRoomObject"},
        {"island1", "IslandRoomObject1"},
        {"island2","IslandRoomObject2"},
    };

    public override void initializeByParameters(Dictionary<string, object> parameters)
    {
        base.initializeByParameters(parameters);
        this.name = parameters.stringValue("name");
        this.type = parameters.stringValue("type");
        this.value = parameters.intValue("value");
    }
}
