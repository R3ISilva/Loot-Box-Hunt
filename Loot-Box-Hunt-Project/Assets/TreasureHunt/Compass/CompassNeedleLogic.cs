using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassNeedleLogic : MonoBehaviour
{
    [SerializeField] Player characterObject;
    [SerializeField] TreasureHunt treasureObject;
    void Update()
    {
        if (characterObject != null)
        {
            Vector2 treasurePosition = treasureObject.transform.position;

            Vector2 characterPosition = characterObject.transform.position;

            Vector2 direction = characterPosition - treasurePosition;

            // Calculate the angle between the two vectors
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;

            Quaternion rotation;
            if (treasurePosition == characterPosition) {
                rotation = Quaternion.AngleAxis(UnityEngine.Random.Range(0f, 360f), Vector3.forward);
            } else {
                // Set the rotation of the needle
                rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            transform.rotation = rotation;
        }

        
    }
}
