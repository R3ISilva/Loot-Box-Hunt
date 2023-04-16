using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum Type {
        Sand,
        Water,
    }

    private bool hasTreasure;

    public Tile() {
        this.hasTreasure = false;
    }

    public bool GetHasTreasure() {
        return this.hasTreasure;
    }

    public void SetHasTreasure(bool hasTreasure) {
        this.hasTreasure = hasTreasure;
    }
}
