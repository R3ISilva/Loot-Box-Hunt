using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLogic : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    private Rigidbody2D rb; // The character's Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        // Get the character's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input axes for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set the character's velocity based on the input axes and move speed
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        rb.velocity = movement * moveSpeed;
    }
}
