using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public FarmGrid farmGrid; // Reference to your FarmGrid script
    public Button winRes;
    public bool MovementDisabled = false;

    //public int turn = 0;
    public void Start()
    {
        winRes.gameObject.SetActive(false);
    }
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
            DisableMovement();
            Debug.Log("winRes button state: " + winRes.enabled);
            winRes.gameObject.SetActive(true);
            Debug.Log("winRes button state after enabling: " + winRes.enabled);
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

    public void RedoFunction()
    {
        foreach (var gridCell in farmGrid.FarmGridList) {
            gridCell.RedoCell();
        }
    }

    public void DisableMovement()
    {
        MovementDisabled = true;
    }

    public void EnableMovement()
    {
        MovementDisabled = false;
    }
    
    public void RestartScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}

