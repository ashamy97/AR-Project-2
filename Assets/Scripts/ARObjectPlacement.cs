using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARObjectPlacement : MonoBehaviour
{

    public ARSessionOrigin ar_session_origin;

    public List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    public GameObject cube;

    GameObject instantiatedCube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1) Detect user touch i.e. when the user taps on the screen
        //2) Project a raycast
        //3) Instantiate a virtual cube at the point where raycast meets the detected plane

        if (Input.GetMouseButton(0)) //detect user touch
        {
            bool collision = ar_session_origin.GetComponent<ARRaycastManager>().Raycast(Input.mousePosition, raycastHits, 
                UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon); //raycast with one touch

            if (collision) //if raycast hits the detected plane
            {

                if (instantiatedCube == null)
                {
                    instantiatedCube = Instantiate(cube); //creates a virtual cube 

                    foreach(var plane in ar_session_origin.GetComponent<ARPlaneManager>().trackables)
                    {
                        plane.gameObject.SetActive(false);
                    }

                    ar_session_origin.GetComponent<ARPlaneManager>().enabled = false;
                }

                instantiatedCube.transform.position = raycastHits[0].pose.position; //move that same cube to where there is a screen tap

            }
        }
    }
}
