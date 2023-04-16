using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassLogic : MonoBehaviour
{
    GameObject characterObject;

    // Start is called before the first frame update
    void Start()
    {
       characterObject = GameObject.Find("CharacterPreFab");
    }

    // Update is called once per frame
    void Update()
    {
        if (characterObject != null)
        {
            Vector2 characterPostition = characterObject.transform.position;
            transform.position = characterPostition + new Vector2(-1, 1);
        }
    }
}
