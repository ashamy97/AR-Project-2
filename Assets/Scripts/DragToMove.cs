using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;
    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase== TouchPhase.Moved) //if the touch moved but still on the screen
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.z + touch.deltaPosition.y * speedModifier); //since the phone screen only has x and y. y coordinate of the car is up that's why it's not included
            }
        }
    }
}
