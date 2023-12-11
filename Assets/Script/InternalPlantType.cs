// InternalPlantType.cs
using System.Collections.Generic;

[System.Serializable]
public class InternalPlantType
{
    public string name;
    public string type;
    public string image;
    public bool waterNeeded;
    public bool sunNeeded;
    public Dictionary<string, object> properties = new Dictionary<string, object>();
}
