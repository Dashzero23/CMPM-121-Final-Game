using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public FarmGrid farmGrid;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Reap() called");
            Reap();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Sow() called");
            Sow();
        }
    }

    void Reap()
    {
        // Get the player's current position
        Vector3 playerPosition = transform.position;

        // Find the corresponding cell in the farm grid
        GridCell currentCell = farmGrid.GetCellAtPlayerPosition(playerPosition);
        // Check if the plant is fully grown before collecting
        if (currentCell.cellState.growthLevel == GridCell.GrowthLevel.Grown)
        {
            // Do something with the collected cell, e.g., print its type
            Debug.Log($"Collected {currentCell.cellState.plantType} at {playerPosition}");
            currentCell.ChangeCellContent(currentCell.cellState.water, currentCell.cellState.sun, GridCell.PlantType.None, GridCell.GrowthLevel.Seed);

            // Update the visuals of the target cell
            currentCell.UpdateCellVisuals();
        }
        else
        {
            Debug.Log("Plant is not fully grown. Cannot collect.");
        }
    }

    void Sow()
    {
        // Assume you want to plant a light orange tile at the player's current position
        Vector3 playerPosition = transform.position;

        // Find the corresponding cell in the farm grid
        GridCell targetCell = farmGrid.GetCellAtPlayerPosition(playerPosition);
        // Set the target cell to a light orange tile if the cell is empty
        if (targetCell.cellState.plantType == GridCell.PlantType.None)
        {
            targetCell.ChangeCellContent(targetCell.cellState.water, targetCell.cellState.sun, GridCell.PlantType.Carrot, GridCell.GrowthLevel.Seed);

            // Update the visuals of the target cell
            targetCell.UpdateCellVisuals();

        }
        else
        {
            Debug.Log("Cannot sow on a non-empty cell.");
        }
    }
}
