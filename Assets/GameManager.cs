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
            if (gridCell.plantType == GridCell.PlantType.Carrot && gridCell.growthLevel == GridCell.GrowthLevel.Grown)
            {
                grownCarrotCount++;
            }
        }

        if (grownCarrotCount >= 3)
        {
            Debug.Log("You win!");
            // Implement your win logic here
        }
        else
        {
            Debug.Log("Not enough grown carrots yet.");
        }
    }
}
