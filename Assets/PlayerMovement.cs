using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gridSize = 1f;
    public GameManager GM;
    public FarmGrid farmScript;
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TeleportPlayer(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            TeleportPlayer(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            TeleportPlayer(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
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
        GM.turn++;
        GM.CheckForWinCondition();
    }
}

