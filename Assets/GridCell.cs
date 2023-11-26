using System;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

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

// SoA
    public struct CellState
    {
        public bool water;
        public bool sun;
        public PlantType plantType;
        public GrowthLevel growthLevel;
    }

    public SpriteRenderer spriteRenderer;
    public Transform CurPosition;

    // Define the structure to store cell state
    public CellState cellState;

    // Add a list to store cell state history
    public List<CellState> cellStateHistory = new List<CellState>();
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
        cellState.water = Random.Range(0f, 1f) > 0.5f;
        cellState.sun = Random.Range(0f, 1f) > 0.5f;
        cellState.plantType = (PlantType)Random.Range(0, System.Enum.GetValues(typeof(PlantType)).Length);
        cellState.growthLevel = GrowthLevel.Seed; // Set initial growth level to seed

        // Update visual representation based on the initial values
        UpdateCellVisuals();
    }

    public void UpdateCellVisuals()
    {
        // Adjust the color or sprite based on the current content
        if (cellState.plantType == PlantType.Grass)
        {
            if (cellState.growthLevel == GrowthLevel.Seed)
            {
                spriteRenderer.color = new Color(0f, 1f, 0f, 0.5f); // Light green for seed
            }
            else
            {
                spriteRenderer.color = Color.green; // Full green for grown
            }
        }
        else if (cellState.plantType == PlantType.Carrot)
        {
            if (cellState.growthLevel == GrowthLevel.Seed)
            {
                spriteRenderer.color = new Color(1f, 0.647f, 0f, 0.5f); // Light orange for seed
            }
            else
            {
                spriteRenderer.color = new Color(1f, 0.647f, 0f); // Full orange for grown
            }
        }
        else if (cellState.water && cellState.sun)
        {
            spriteRenderer.color = new Color(0.545f, 0.271f, 0.075f); // Brown color
        }
        else if (cellState.water)
        {
            spriteRenderer.color = Color.blue;
        }
        else if (cellState.sun)
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
        cellState.water = newWater;
        cellState.sun = newSun;
        cellState.plantType = newPlantType;
        cellState.growthLevel = newGrowthLevel;

        SaveCellState();
        UpdateCellVisuals();
    }

    public Vector2Int GetCellPosition()
    {
        // Assuming the cell position is in world space, convert it to grid coordinates
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);

        return new Vector2Int(x, y);
    }

        void SaveCellState()
    {
        cellStateHistory.Add(cellState);
    }

    public void UndoCell()
    {
        if (cellStateHistory.Count > 1)
        {
            // Remove the last state (current state) and apply the previous state
            cellStateHistory.RemoveAt(cellStateHistory.Count - 1);
            cellState = cellStateHistory[cellStateHistory.Count - 1];
            UpdateCellVisuals();
        }
    }
}
