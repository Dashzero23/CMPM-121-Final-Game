using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    public GameObject gridCellPrefab;
    public int gridSize = 4;
    public float originalLocation = -1.5f;
    public float cellSize = 1.0f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (float x = originalLocation; x < originalLocation+gridSize; x++)
        {
            for (float y = originalLocation; y < originalLocation+gridSize; y++)
            {
                Vector3 cellPosition = new Vector3(x * cellSize, y * cellSize, 0);
                GameObject cellObject = Instantiate(gridCellPrefab, cellPosition, Quaternion.identity, transform);

                // Attach the GridCell script to the instantiated cell
                GridCell gridCell = cellObject.GetComponent<GridCell>();
                if (gridCell != null)
                {
                    // Use InitializeCell instead of ChangeCellContent during initialization
                    gridCell.InitializeCell();
                }
            }
        }
    }
}
