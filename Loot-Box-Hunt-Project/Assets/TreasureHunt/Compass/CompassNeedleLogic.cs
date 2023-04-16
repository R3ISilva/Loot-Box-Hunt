using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassNeedleLogic : MonoBehaviour
{
    GameObject characterObject;
    GameObject treasureObject;

    private void Start()
    {
        characterObject = GameObject.Find("CharacterPreFab");
        treasureObject = GameObject.Find("TreasurePreFab");

    }

    void Update()
    {
        if (characterObject != null)
        {
            Vector2 treasurePosition = treasureObject.transform.position;

            Vector2 characterPosition = characterObject.transform.position;

            Vector2 direction = characterPosition - treasurePosition;

            // Calculate the angle between the two vectors
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

            // Set the rotation of the needle
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        
    }
}
