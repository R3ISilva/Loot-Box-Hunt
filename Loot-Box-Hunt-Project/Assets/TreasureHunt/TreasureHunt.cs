using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunt : MonoBehaviour
{
    GameObject characterObject;

    private void Start()
    {
        Vector2 characterPosition = transform.position;
        characterObject = GameObject.Find("CharacterPreFab");

    }
    void Update()
    {
        if (characterObject != null)
        {
            Vector2 characterPosition = characterObject.transform.position;
        }
    }
}
