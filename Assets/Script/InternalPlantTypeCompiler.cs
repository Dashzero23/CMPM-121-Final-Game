// InternalPlantTypeCompiler.cs
using System.Collections.Generic;

public class InternalPlantTypeCompiler
{
    private InternalPlantType internalPlantType = new InternalPlantType();

    public void SetProperty(string propertyName, object value)
    {
        internalPlantType.properties[propertyName] = value;
    }

    public InternalPlantType Compile()
    {
        return internalPlantType;
    }
}
