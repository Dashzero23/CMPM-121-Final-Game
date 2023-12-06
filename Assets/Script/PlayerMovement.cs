using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gridSize = 1f;
    public GameManager GM;
    public SaveSystem saveSys;
    public FarmGrid farmScript;
    void Update()
    {
        if(!GM.MovementDisabled) {
            HandleInput();
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            saveSys.SaveGame("AutoSave");        
            TeleportPlayer(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            saveSys.SaveGame("AutoSave"); 
            TeleportPlayer(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            saveSys.SaveGame("AutoSave"); 
            TeleportPlayer(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            saveSys.SaveGame("AutoSave"); 
            TeleportPlayer(Vector3.right);
        }
    }

    void TeleportPlayer(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction * gridSize;

        // Clamp the new position within the farm grid bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -2, 2);
        newPosition.y = Mathf.Clamp(newPosition.y, -2, 2);

        transform.position = newPosition;

        farmScript.UpdateAllCells();
        //GM.turn++;
        GM.CheckForWinCondition();
    }
}

