using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private float movementSpeed = 1;

    public event EventHandler<OnMovementEventArgs> OnMovement;
    public class OnMovementEventArgs : EventArgs {
        public Vector2 newPosition;
    }

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
            SendNewLocation(newPosition);
        } 
        else if (Input.GetKeyDown("s")) {
            newPosition = new Vector2(positionX, positionY - movementSpeed);
            this.transform.localPosition = newPosition;
            SendNewLocation(newPosition);
        } 
        else if (Input.GetKeyDown("a")) {
            newPosition = new Vector2(positionX - movementSpeed, positionY);
            this.transform.localPosition = newPosition;
            SendNewLocation(newPosition);
        } 
        else if (Input.GetKeyDown("d")) {
            newPosition = new Vector2(positionX + movementSpeed, positionY);
            this.transform.localPosition = newPosition;
            SendNewLocation(newPosition);
        }
    }

    public void SendNewLocation(Vector2 newPosition) {
        OnMovement?.Invoke(this, new OnMovementEventArgs {newPosition = newPosition});
    }
}
