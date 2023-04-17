using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    [SerializeField] Player player;

    private float score;

    

    private int numberOfTreasures;

    private int treasuresLeft;

    public void Start(){
        player.OnMovement += Player_OnMovement;

        SetupScore();

        SetupMapArray();
        SetupNumberOfTreasures();
        SetupTreasuresLeft();

        PopulatMapGrid(this);
        PopulateGridTreasures(this);

        AssignNextTreasure();

        AssignPlayerStartingPosition();
    }

    public void Update() {
        if (Input.GetKeyDown("e")) {
            //Pickup treasure
            
            if (player.transform.position == currentTreasure.transform.position) {
                //pickup treasure
                Debug.Log("Treasure picked up!");

                //take out treasure from sand
                for (int i = 0; i < gridSize; i++) {
                    for (int j = 0; j < gridSize; j++) {
                        if (mapArray[i, j].transform.position == player.transform.position) {
                            mapArray[i,j].SetHasTreasure(false);
                        }
                    }
                }

                score++;
                treasuresLeft--;
                Debug.Log("Treasures left: " + treasuresLeft);

                AssignNextTreasure();
            }

        }
    }

    public void AssignNextTreasure() {
        if (treasuresLeft > 0) {

            bool newChestLocated = false;

            while (newChestLocated == false) {
                for (int i = 0; i < gridSize; i++) {
                    for (int j = 0; j < gridSize; j++) {
                        if (mapArray[i, j].GetHasTreasure() == true && RollDice(0.1f)) {
                            currentTreasure.transform.position = mapArray[i, j].transform.position;
                            newChestLocated = true;
                        }
                    }
                }
            }
            
        } else {
            Debug.Log("CONGRATS! YOU PICKED ALL THE CHESTS!");
            YouBad();
        }
    }

    public void SetupMapArray() {
        mapArray = new Tile[gridSize,gridSize];
    }

    public void PopulatMapGrid(MapGrid mapGrid) {
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

                    if (mapArray[i,j].tileType == Tile.Type.Sand && 
                        mapArray[i,j].GetHasTreasure() == false && 
                        RollDice(probabilityTreasureSpawn)) {

                        mapArray[i,j].SetHasTreasure(true);
                        treasuresLeftToSpawn--;
                    }
                }
            }
        }
    }

    public void SetupNumberOfTreasures() {
        this.numberOfTreasures = Mathf.RoundToInt(probabilityTreasureSpawn * (gridSize * gridSize));
        Debug.Log("Treasure is a total of "+ numberOfTreasures + " to pick up!");
    }

    public bool RollDice(float probability) {
        if (UnityEngine.Random.Range(0f, 1f) <= probability) {
            return true;
        }

        return false;
    }

    private void Player_OnMovement(object sender, Player.OnMovementEventArgs e) {
        //Debug.Log(e.newPosition);
        
        bool outOfBounds = true;

        for (int i = 0; i < gridSize; i++) {
            for(int j = 0; j < gridSize; j++) {
                if (mapArray[i,j].transform.position == player.transform.position) {
                    
                    outOfBounds = false;

                    if (mapArray[i,j].tileType == Tile.Type.Water) {
                        Debug.Log("YOU LOST! Next time don't be a noob and stop falling in the water!");
                        YouBad();
                    }
                }
            }
        }

        if (outOfBounds) {
            Debug.Log("YOU LOST! Next time don't be a noob and stop falling in the water!");
            YouBad();
        }
    }

    private void SetupScore() {
        this.score = 0;
    }

    private void SetupTreasuresLeft() {
        this.treasuresLeft = this.numberOfTreasures;
    }

    private void AssignPlayerStartingPosition() {
        bool isAssigned = false;

        while(isAssigned == false) {
            int randXindex = UnityEngine.Random.Range(0, gridSize-1);
            int randYindex = UnityEngine.Random.Range(0, gridSize-1);
            Tile tryTile = mapArray[randXindex, randYindex];
            
            if (tryTile.tileType == Tile.Type.Sand && tryTile.GetHasTreasure() == false) {
                player.transform.position = tryTile.transform.position;
                isAssigned = true;
            }
        }
    }

    private void YouBad() {
        Application.Quit();
        if (UnityEditor.EditorApplication.isPlaying) {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
