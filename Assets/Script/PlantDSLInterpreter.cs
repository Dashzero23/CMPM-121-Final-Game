// PlantDSLInterpreter.cs
using UnityEngine;
using System;

public class PlantDSLInterpreter : MonoBehaviour
{
    public InternalPlantTypeCompiler InterpretDSL(Action<dynamic> program)
    {
        var internalPlantTypeCompiler = new InternalPlantTypeCompiler();
        var dsl = new
        {
            name = new Action<string>(name => internalPlantTypeCompiler.SetProperty("name", name)),
            type = new Action<string>(type => internalPlantTypeCompiler.SetProperty("type", type)),
            image = new Action<string>(image => internalPlantTypeCompiler.SetProperty("image", image)),
            SetProperty = new Action<string, object>((property, value) => internalPlantTypeCompiler.SetProperty(property, value))
        };
        program(dsl);

        return internalPlantTypeCompiler;
    }
}
