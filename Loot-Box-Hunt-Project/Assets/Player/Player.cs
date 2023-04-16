using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private float movementSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        float positionX = this.transform.localPosition.x;
        float positionY = this.transform.localPosition.y;
        Vector2 newPosition;
        

        if (Input.GetKeyDown("w"))
        {
            newPosition = new Vector2(positionX, positionY + movementSpeed);
            this.transform.localPosition = newPosition;
        } 
        else if (Input.GetKeyDown("s")) {
            newPosition = new Vector2(positionX, positionY - movementSpeed);
            this.transform.localPosition = newPosition;
        } 
        else if (Input.GetKeyDown("a")) {
            newPosition = new Vector2(positionX - movementSpeed, positionY);
            this.transform.localPosition = newPosition;
        } 
        else if (Input.GetKeyDown("d")) {
            newPosition = new Vector2(positionX + movementSpeed, positionY);
            this.transform.localPosition = newPosition;
        }
    }
}
