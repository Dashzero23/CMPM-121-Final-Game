// PlantDefinitionExample.cs
using UnityEngine;

public class PlantDefinitionExample : MonoBehaviour
{
    void Start()
    {
        var plantDSLInterpreter = new PlantDSLInterpreter();

        // Define the first plant (carrot seed)
        var carrotSeed = plantDSLInterpreter.InterpretDSL(dsl =>
        {
            dsl.name("carrot");
            dsl.type("seed");
            dsl.image("Assets/Sprites/carrot_seed_sprite.png");
            dsl.SetProperty("waterNeeded", true);
            dsl.SetProperty("sunNeeded", true);
        });

        // Define the second plant (carrot grown)
        var carrotGrown = plantDSLInterpreter.InterpretDSL(dsl =>
        {
            dsl.name("carrot");
            dsl.type("grown");
            dsl.image("Assets/Sprites/carrot_grown_sprite.png");
            dsl.SetProperty("waterNeeded", false);
            dsl.SetProperty("sunNeeded", true);
        });

        // Define the third plant (grass seed)
        var grassSeed = plantDSLInterpreter.InterpretDSL(dsl =>
        {
            dsl.name("grass");
            dsl.type("seed");
            dsl.image("Assets/Sprites/grass_seed_sprite.png");
            dsl.SetProperty("waterNeeded", true);
            dsl.SetProperty("sunNeeded", false);
        });

        // Define the fourth plant (grass grown)
        var grassGrown = plantDSLInterpreter.InterpretDSL(dsl =>
        {
            dsl.name("grass");
            dsl.type("grown");
            dsl.image("Assets/Sprites/grass_grown_sprite.png");
            dsl.SetProperty("waterNeeded", false);
            dsl.SetProperty("sunNeeded", false);
        });

        // Access and log the properties of each plant
        LogPlantProperties("Carrot Seed", carrotSeed);
        LogPlantProperties("Carrot Grown", carrotGrown);
        LogPlantProperties("Grass Seed", grassSeed);
        LogPlantProperties("Grass Grown", grassGrown);
    }

    void LogPlantProperties(string plantLabel, InternalPlantTypeCompiler internalPlantTypeCompiler)
    {
        string plantName = internalPlantTypeCompiler.Compile().properties["name"].ToString();
        string plantType = internalPlantTypeCompiler.Compile().properties["type"].ToString();
        bool waterNeeded = (bool)internalPlantTypeCompiler.Compile().properties["waterNeeded"];
        bool sunNeeded = (bool)internalPlantTypeCompiler.Compile().properties["sunNeeded"];

        // Debug log the name, type, waterNeeded, and sunNeeded
        Debug.Log($"{plantLabel} - Plant Name: {plantName}, Type: {plantType}, Water Needed: {waterNeeded}, Sun Needed: {sunNeeded}");
    }
}
