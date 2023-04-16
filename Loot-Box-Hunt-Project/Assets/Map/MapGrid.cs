using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGrid : MonoBehaviour
{
    [SerializeField] Tile defaultTile;

    [SerializeField] Tile waterTile;
    [SerializeField] Tile sandTile;
    [SerializeField] int gridSize;
    [SerializeField] float probabilityWaterSpawn;
    [SerializeField] float probabilityTreasureSpawn;
    Tile[,] mapArray;

    [SerializeField] TreasureHunt currentTreasure;

    

    private int numberOfTreasures;

    public void Start(){
        SetupMapArray();
        SetupNumberOfTreasures();

        PopulateGridDefault(this);
        PopulateGridTreasures(this);

        AssignNextTreasure();
    }

    public void AssignNextTreasure() {
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                if (mapArray[i, j].GetHasTreasure() == true && RollDice(0.1f)) {
                    currentTreasure.transform.position = mapArray[i, j].transform.position;
                    //TODO continue coding here @Djuke
                }
            }
        }
    }

    public void SetupMapArray() {
        mapArray = new Tile[gridSize,gridSize];
    }

    public void PopulateGridDefault(MapGrid mapGrid) {
        Tile tile = defaultTile;
        Vector2 startingPosition = new Vector2(.5f, .5f);
        float tileLength = 1f;
        
        for (int i = 0; i < gridSize; i++) {
            for (int j = 0; j < gridSize; j++) {
                Tile newTile;
                if (RollDice(probabilityWaterSpawn)) {
                    newTile = Instantiate(waterTile);
                } else {
                    newTile = Instantiate(sandTile);
                }
                newTile.transform.localPosition = new Vector2(i*tileLength, j*tileLength);
                mapArray[i,j] = newTile;
            }
        }
    }

    public void PopulateGridTreasures(MapGrid mapGrid) {
        int treasuresLeftToSpawn = numberOfTreasures;

        while (treasuresLeftToSpawn >= 0) {
            
            for (int i = 0; i < gridSize; i++) {
                for(int j = 0; j < gridSize; j++) {

                    if (mapArray[i,j].GetHasTreasure() == false && RollDice(probabilityTreasureSpawn)) {
                        mapArray[i,j].SetHasTreasure(true);
                        treasuresLeftToSpawn--;
                    }
                }
            }
        }
    }

    public void SetupNumberOfTreasures() {
        this.numberOfTreasures = Mathf.RoundToInt(probabilityTreasureSpawn * (gridSize * gridSize));
    }

    public bool RollDice(float probability) {
        if (Random.Range(0f, 1f) <= probability) {
            return true;
        }

        return false;
    }
}
