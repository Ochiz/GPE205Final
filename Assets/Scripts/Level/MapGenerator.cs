using System.Collections;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    public PawnSpawnPoint[] pawnSpawns;
    public int TotalAiToSpawn;
    public float totalPowerups = 0;
    public float maxPowerups;
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    private Room[,] grid;
    public int mapSeed;
    public bool isMapOfTheDay;
    
    //How seeds work if map is random it will take the current
    //date and time to make a seed. If map is map of the day it
    //will take just the date and make the seed. if it is a custom
    //map then the developers can put their own seed in the inspector.

    public void Start()
    {
        
    }
    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0, gridPrefabs.Length)];
    }
    public void GenerateMap()
    {
        if (isMapOfTheDay)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
            UnityEngine.Random.InitState(mapSeed);
        }
        else
        {
            mapSeed = DateToInt(DateTime.Now);
            UnityEngine.Random.InitState(mapSeed);
        }   
        grid = new Room[cols, rows];
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            for (int currentCol = 0; currentCol < cols; currentCol++)
            { 
                float xPosition = currentCol * roomWidth;
                float zPosition = currentRow * roomHeight;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);
                GameObject tempRoomObj = Instantiate(RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;

                tempRoomObj.transform.parent = this.transform;
                tempRoomObj.name = "Room" + currentCol + "," + currentRow;
                Room tempRoom = tempRoomObj.GetComponent<Room>();
                grid[currentCol, currentRow] = tempRoom;

                if (currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows - 1)
                {
                    tempRoom.doorSouth.SetActive(false);
                }
                else
                {
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                }
                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    tempRoom.doorWest.SetActive(false);
                    tempRoom.doorEast.SetActive(false);
                }
                //how doors are opened. The code checks
                //by means of collumns and rows if the
                //current room is at the edge of the map.
                //if it is then certain doors are opened
                //and closed in that room. otherwise all
                //doors are opened.
            }
        }
    }
    public void DestroyMap()
    {
        if (grid != null)
        {
            foreach (Room tile in grid)
            {
                Destroy(tile.gameObject);
            }
        }
    }
    public int DateToInt(DateTime dateToUse)
    {
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
}
