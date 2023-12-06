using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    public FarmGrid farmGrid;

    public TMP_InputField saveField;
    public TMP_InputField loadField;

    [System.Serializable]
    public class SaveData
    {
        public List<GridCellData> gridCells;
    }

    [System.Serializable]
    public class GridCellData
    {
        public Vector3 position;
        public CellState cellState;
        public List<CellState> cellStateHistory;
        public List<CellState> redoCellStateHistory;
    }

    [System.Serializable]
    public struct CellState
    {
        public bool water;
        public bool sun;
        public GridCell.PlantType plantType;
        public GridCell.GrowthLevel growthLevel;
    }

    public void Start()
    {
        saveField.interactable = false;
        loadField.interactable = false;
    }

    public void SaveGame(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        // Create a data structure to hold the necessary information
        SaveData saveData = new SaveData();
        saveData.gridCells = new List<GridCellData>();

        // Save cell states and history for each grid cell
        foreach (var gridCell in farmGrid.FarmGridList)
        {
            GridCellData cellData = new GridCellData();
            cellData.position = gridCell.transform.position;
            cellData.cellState = new CellState
            {
                water = gridCell.cellState.water,
                sun = gridCell.cellState.sun,
                plantType = (GridCell.PlantType)gridCell.cellState.plantType,
                growthLevel = (GridCell.GrowthLevel)gridCell.cellState.growthLevel
            };

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

            saveData.gridCells.Add(cellData);
        }

        // Convert data to JSON format
        string jsonData = JsonUtility.ToJson(saveData, true);

        // Save the JSON data to a file
        System.IO.File.WriteAllText(path, jsonData);

        Debug.Log("Game saved to: " + path);
    }

    public void LoadGame(string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName + ".json";

        if (System.IO.File.Exists(path))
        {
            // Read the JSON data from the file
            string jsonData = System.IO.File.ReadAllText(path);

            // Deserialize the JSON data into the SaveData object
            SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);

            // Apply the loaded data to the current game state
            ApplyLoadedData(saveData);

            Debug.Log("Game loaded from: " + path);
        }
        else
        {
            Debug.LogError("File not found: " + path);
        }
    }

    private void ApplyLoadedData(SaveData saveData)
    {
        // Iterate through each grid cell data and apply it to the corresponding grid cell
        foreach (var gridCellData in saveData.gridCells)
        {
            // Find the corresponding grid cell in FarmGridList based on position
            GridCell gridCell = farmGrid.FarmGridList.Find(cell => cell.transform.position == gridCellData.position);

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
                    Debug.LogWarning("Grid cell not found at position: " + gridCellData.position);
                }
        }
    }
    
    public void DisableSaveField()
    {
        saveField.interactable = false;
    }

    public void EnableSaveField()
    {
        saveField.interactable = true;
    }

    public void DisableLoadField()
    {
        loadField.interactable = false;
    }

    public void EnableLoadField()
    {
        loadField.interactable = true;
    }
}
