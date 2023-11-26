using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    public GameObject gridCellPrefab;
    public int gridSize = 5;
    public float originalLocation = -2.5f;
    public float cellSize = 1.0f;
    public List<GridCell> FarmGridList = new List<GridCell>();

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (float x = originalLocation; x < originalLocation + gridSize; x++)
        {
            for (float y = originalLocation; y < originalLocation + gridSize; y++)
            {
                Vector3 cellPosition = new Vector3(x * cellSize, y * cellSize, 0);
                GameObject cellObject = Instantiate(gridCellPrefab, cellPosition, Quaternion.identity, transform);

                // Attach the GridCell script to the instantiated cell
                GridCell gridCellComponent = cellObject.GetComponent<GridCell>(); // Change variable name to avoid conflict
                if (gridCellComponent != null)
                {
                    FarmGridList.Add(gridCellComponent); // Add the grid cell to the list
                    // Use InitializeCell instead of ChangeCellContent during initialization
                    gridCellComponent.InitializeCell();
                }
            }
        }
    }
public GridCell GetCellAtPlayerPosition(Vector3 playerPosition)
{
    // Convert player position to grid coordinates
    int playerX = Mathf.RoundToInt(playerPosition.x / cellSize);
    int playerY = Mathf.RoundToInt(playerPosition.y / cellSize);

    // Iterate through the grid cells and find the one matching the player's position
    foreach (var gridCell in FarmGridList)
    {
        Vector2Int cellPosition = gridCell.GetCellPosition();
        
        if (cellPosition.x == playerX && cellPosition.y == playerY)
        {
            return gridCell; // Found the cell the player is standing on
        }
    }

    return null; // Player is not on any cell (outside the grid, for example)
}

    public void UpdateAllCells()
    {
        foreach (var gridCell in FarmGridList)
        {
            if (gridCell.cellState.plantType != GridCell.PlantType.None && gridCell.cellState.growthLevel == GridCell.GrowthLevel.Grown) {
                gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.cellState.plantType, GridCell.GrowthLevel.Grown);
            }

            else if (gridCell.cellState.plantType != GridCell.PlantType.None && gridCell.cellState.growthLevel == GridCell.GrowthLevel.Seed) {
                if (gridCell.cellState.sun && gridCell.cellState.water) {
                    gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.cellState.plantType, GridCell.GrowthLevel.Grown);
                }

                else if (!gridCell.cellState.water) {
                    gridCell.ChangeCellContent(Random.Range(0f, 1f) > 0.5f, Random.Range(0f, 1f) > 0.5f, gridCell.cellState.plantType, GridCell.GrowthLevel.Seed);
                }

                else {
                    gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.cellState.plantType, GridCell.GrowthLevel.Seed);
                }
            }

            else {
                if (!gridCell.cellState.water) {
                    gridCell.ChangeCellContent(Random.Range(0f, 1f) > 0.5f, Random.Range(0f, 1f) > 0.5f, gridCell.cellState.plantType, GridCell.GrowthLevel.Seed);
                }

                else {
                    gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.cellState.plantType, GridCell.GrowthLevel.Seed);
                }
            }
        }
    }
}
