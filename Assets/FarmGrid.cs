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

    public void UpdateAllCells()
    {
        foreach (var gridCell in FarmGridList)
        {
            if (gridCell.plantType != GridCell.PlantType.None && gridCell.growthLevel == GridCell.GrowthLevel.Grown) {
                gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.plantType, GridCell.GrowthLevel.Grown);
            }

            else if (gridCell.plantType != GridCell.PlantType.None && gridCell.growthLevel == GridCell.GrowthLevel.Seed) {
                if (gridCell.sun && gridCell.water) {
                    gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.plantType, GridCell.GrowthLevel.Grown);
                }

                else if (!gridCell.water) {
                    gridCell.ChangeCellContent(Random.Range(0f, 1f) > 0.5f, Random.Range(0f, 1f) > 0.5f, gridCell.plantType, GridCell.GrowthLevel.Seed);
                }

                else {
                    gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.plantType, GridCell.GrowthLevel.Seed);
                }
            }

            else {
                if (!gridCell.water) {
                    gridCell.ChangeCellContent(Random.Range(0f, 1f) > 0.5f, Random.Range(0f, 1f) > 0.5f, gridCell.plantType, GridCell.GrowthLevel.Seed);
                }

                else {
                    gridCell.ChangeCellContent(true, Random.Range(0f, 1f) > 0.5f, gridCell.plantType, GridCell.GrowthLevel.Seed);
                }
            }
        }
    }
}
