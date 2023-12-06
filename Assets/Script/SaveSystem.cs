using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    // Reference to the FarmGrid in the game
    public FarmGrid farmGrid;

    // Input fields for saving and loading game data
    public TMP_InputField saveField;
    public TMP_InputField loadField;

    // Data structure to hold saved game information
    [System.Serializable]
    public class SaveData
    {
        public List<GridCellData> gridCells;
    }

    // Data structure to store information about each grid cell
    [System.Serializable]
    public class GridCellData
    {
        public Vector3 position;
        public CellState cellState;
        public List<CellState> cellStateHistory;
        public List<CellState> redoCellStateHistory;
    }

    // Data structure representing the state of a grid cell
    [System.Serializable]
    public struct CellState
    {
        public bool water;
        public bool sun;
        public GridCell.PlantType plantType;
        public GridCell.GrowthLevel growthLevel;
    }

    // Initialization
    public void Start()
    {
        // Disable save and load fields initially
        saveField.interactable = false;
        loadField.interactable = false;
    }

    // SaveGame function: Saves the game state to a file
    public void SaveGame(string fileName)
    {
        // Construct the path for saving the file
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        // Create a data structure to hold the necessary information
        SaveData saveData = new SaveData();
        saveData.gridCells = new List<GridCellData>();

        // Save cell states and history for each grid cell
        foreach (var gridCell in farmGrid.FarmGridList)
        {
            // Create a data structure for the current grid cell
            GridCellData cellData = new GridCellData();
            cellData.position = gridCell.transform.position;

            // Save the current cell state
            cellData.cellState = new CellState
            {
                water = gridCell.cellState.water,
                sun = gridCell.cellState.sun,
                plantType = (GridCell.PlantType)gridCell.cellState.plantType,
                growthLevel = (GridCell.GrowthLevel)gridCell.cellState.growthLevel
            };

            // Save the cell state history
            cellData.cellStateHistory = new List<CellState>();
            foreach (var cellState in gridCell.cellStateHistory)
            {
                cellData.cellStateHistory.Add(new CellState
                {
                    water = cellState.water,
                    sun = cellState.sun,
                    plantType = (GridCell.PlantType)cellState.plantType,
                    growthLevel = (GridCell.GrowthLevel)cellState.growthLevel
                });
            }

            // Save the redo cell state history
            cellData.redoCellStateHistory = new List<CellState>();
            foreach (var cellState in gridCell.redoCellStateHistory)
            {
                cellData.redoCellStateHistory.Add(new CellState
                {
                    water = cellState.water,
                    sun = cellState.sun,
                    plantType = (GridCell.PlantType)cellState.plantType,
                    growthLevel = (GridCell.GrowthLevel)cellState.growthLevel
                });
            }

            // Add the grid cell data to the save data
            saveData.gridCells.Add(cellData);
        }

        // Convert data to JSON format
        string jsonData = JsonUtility.ToJson(saveData, true);

        // Save the JSON data to a file
        System.IO.File.WriteAllText(path, jsonData);

        // Log a message indicating that the game has been saved
        Debug.Log("Game saved to: " + path);
    }

    // LoadGame function: Loads the game state from a file
    public void LoadGame(string fileName)
    {
        // Construct the path for loading the file
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        // Check if the file exists
        if (System.IO.File.Exists(path))
        {
            // Read the JSON data from the file
            string jsonData = System.IO.File.ReadAllText(path);

            // Deserialize the JSON data into the SaveData object
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

            // Apply the loaded data to the current game state
            ApplyLoadedData(saveData);

            // Log a message indicating that the game has been loaded
            Debug.Log("Game loaded from: " + path);
        }
        else
        {
            // Log an error message if the file is not found
            Debug.LogError("File not found: " + path);
        }
    }

    // ApplyLoadedData function: Applies loaded data to the game state
    private void ApplyLoadedData(SaveData saveData)
    {
        // Iterate through each grid cell data and apply it to the corresponding grid cell
        foreach (var gridCellData in saveData.gridCells)
        {
            // Find the corresponding grid cell in FarmGridList based on position
            GridCell gridCell = farmGrid.FarmGridList.Find(cell => cell.transform.position == gridCellData.position);

            // Check if the grid cell is found
            if (gridCell != null)
            {
                // Apply the loaded cell state to the grid cell
                gridCell.cellState = new GridCell.CellState
                {
                    water = gridCellData.cellState.water,
                    sun = gridCellData.cellState.sun,
                    plantType = (GridCell.PlantType)gridCellData.cellState.plantType,
                    growthLevel = (GridCell.GrowthLevel)gridCellData.cellState.growthLevel
                };

                // Convert CellState lists to GridCell.CellState lists
                gridCell.cellStateHistory = new List<GridCell.CellState>();
                foreach (var cellState in gridCellData.cellStateHistory)
                {
                    gridCell.cellStateHistory.Add(new GridCell.CellState
                    {
                        water = cellState.water,
                        sun = cellState.sun,
                        plantType = (GridCell.PlantType)cellState.plantType,
                        growthLevel = (GridCell.GrowthLevel)cellState.growthLevel
                    });
                }

                gridCell.redoCellStateHistory = new List<GridCell.CellState>();
                foreach (var cellState in gridCellData.redoCellStateHistory)
                {
                    gridCell.redoCellStateHistory.Add(new GridCell.CellState
                    {
                        water = cellState.water,
                        sun = cellState.sun,
                        plantType = (GridCell.PlantType)cellState.plantType,
                        growthLevel = (GridCell.GrowthLevel)cellState.growthLevel
                    });
                }

                // Update the visual representation of the grid cell
                gridCell.UpdateCellVisuals();
            }
            else
            {
                // Log a warning if the grid cell is not found
                Debug.LogWarning("Grid cell not found at position: " + gridCellData.position);
            }
        }
    }

    // DisableSaveField function: Disables the save field in the UI
    public void DisableSaveField()
    {
        saveField.interactable = false;
    }

    // EnableSaveField function: Enables the save field in the UI
    public void EnableSaveField()
    {
        saveField.interactable = true;
    }

    // DisableLoadField function: Disables the load field in the UI
    public void DisableLoadField()
    {
        loadField.interactable = false;
    }

    // EnableLoadField function: Enables the load field in the UI
    public void EnableLoadField()
    {
        loadField.interactable = true;
    }
}
