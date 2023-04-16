using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField] GameObject defaultTile;
    [SerializeField] int gridSize;
    GameObject[] map;

    public void Start(){
        setupMapArray();
        populateGrid(this);
    }

    public void setupMapArray() {
        map = new GameObject[gridSize];
    }

    public void populateGrid(MapGrid mapGrid) {
        GameObject tile = defaultTile;
        Vector2 startingPosition = new Vector2(.5f, .5f);
        float tileLength = 1f;
        
        
        
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {

            
                
            GameObject newTile = Instantiate(tile);
            newTile.transform.position = new Vector2(startingPosition.x + i*tileLength, startingPosition.y + j*tileLength);

            }
        }

        GameObject newObject = Instantiate(tile);
        newObject.transform.position = startingPosition;

        GameObject newObject2 = Instantiate(tile);
        newObject2.transform.position = startingPosition*3;

        //Vector2 firstTilePosition = new Vector2(startingPositionX, startingPositionY);

    }
}
