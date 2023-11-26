using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FarmGrid farmGrid; // Reference to your FarmGrid script

    public int turn = 0;
    public void CheckForWinCondition()
    {
        int grownCarrotCount = 0;

        foreach (var gridCell in farmGrid.FarmGridList)
        {
            if (gridCell.cellState.plantType == GridCell.PlantType.Carrot && gridCell.cellState.growthLevel == GridCell.GrowthLevel.Grown)
            {
                grownCarrotCount++;
            }
        }

        if (grownCarrotCount >= 10)
        {
            Debug.Log("You win!");
            // Implement win logic here
        }
        else
        {
            Debug.Log("Not enough grown carrots yet.");
        }
    }

    public void UndoFunction()
    {
        foreach (var gridCell in farmGrid.FarmGridList) {
            gridCell.UndoCell();
        }
    }
}
