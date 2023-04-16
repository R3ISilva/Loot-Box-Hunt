using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField] GameObject defaultTile;

    [SerializeField] Tile waterTile;
    [SerializeField] Tile sandTile;
    [SerializeField] int gridSize;
    GameObject[,] mapArray;

    public void Start(){
        setupMapArray();
        populateGrid(this);

        Debug.Log(mapArray);
    }

    public void setupMapArray() {
        mapArray = new GameObject[gridSize,gridSize];
    }

    public void populateGrid(MapGrid mapGrid) {
        GameObject tile = defaultTile;
        Vector2 startingPosition = new Vector2(.5f, .5f);
        float tileLength = 1f;
        
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {

            
            
            GameObject newTile = Instantiate(tile);
            newTile.transform.localPosition = new Vector2(i*tileLength, j*tileLength);
            mapArray[i,j] = newTile;
            }
        }
    }
}
