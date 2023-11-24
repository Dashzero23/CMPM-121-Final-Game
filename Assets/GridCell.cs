using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridCell : MonoBehaviour
{
    public enum PlantType
    {
        None,
        Grass,
        Carrot
    }

    public enum GrowthLevel
    {
        Seed,
        Grown
    }

    public SpriteRenderer spriteRenderer;
    public Transform CurPosition;
    public bool water = false;
    public bool sun = false;
    public PlantType plantType;
    public GrowthLevel growthLevel;

void Start()
{
    spriteRenderer = GetComponent<SpriteRenderer>();
    if (spriteRenderer == null)
    {
        Debug.LogError("SpriteRenderer component not found on GridCell prefab.");
        return;
    }

    InitializeCell();
}


    public void InitializeCell()
    {
        // Set initial values
        water = Random.Range(0f, 1f) > 0.5f;
        sun = Random.Range(0f, 1f) > 0.5f;
        plantType = (PlantType)Random.Range(0, System.Enum.GetValues(typeof(PlantType)).Length);
        growthLevel = GrowthLevel.Seed; // Set initial growth level to seed

        // Update visual representation based on the initial values
        UpdateCellVisuals();
    }

    public void UpdateCellVisuals()
    {
        // Adjust the color or sprite based on the current content
        if (plantType == PlantType.Grass)
        {
            if (growthLevel == GrowthLevel.Seed)
            {
                spriteRenderer.color = new Color(0f, 1f, 0f, 0.5f); // Light green for seed
            }
            else
            {
                spriteRenderer.color = Color.green; // Full green for grown
            }
        }
        else if (plantType == PlantType.Carrot)
        {
            if (growthLevel == GrowthLevel.Seed)
            {
                spriteRenderer.color = new Color(1f, 0.647f, 0f, 0.5f); // Light orange for seed
            }
            else
            {
                spriteRenderer.color = new Color(1f, 0.647f, 0f); // Full orange for grown
            }
        }
        else if (water && sun)
        {
            spriteRenderer.color = new Color(0.545f, 0.271f, 0.075f); // Brown color
        }
        else if (water)
        {
            spriteRenderer.color = Color.blue;
        }
        else if (sun)
        {
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void ChangeCellContent(bool newWater, bool newSun, PlantType newPlantType, GrowthLevel newGrowthLevel)
    {
        water = newWater;
        sun = newSun;
        plantType = newPlantType;
        growthLevel = newGrowthLevel;

        UpdateCellVisuals();
    }

    public Vector2Int GetCellPosition()
    {
        // Assuming the cell position is in world space, convert it to grid coordinates
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);

        return new Vector2Int(x, y);
    }
}
