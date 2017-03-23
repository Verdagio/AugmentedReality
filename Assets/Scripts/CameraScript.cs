using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


    public GameObject cameraPlane;
    public GameObject cameraParent = null;

    // Use this for initialization
    void Start () {

        ////check to see if using a mobile platform
        if (Application.isMobilePlatform)
        {
            // allows to look around in a natural way
            cameraParent = new GameObject("cameraParent");
            cameraParent.transform.position = this.transform.position; // set the parents position to the camera
            this.transform.parent = cameraParent.transform;
            cameraParent.transform.Rotate(Vector3.right, 90);
        }//if

        //if the device has a gyroscope in it use this will 
        Input.gyro.enabled = true;


        //create a new web cam texture and assign the camera plane its texture
        //This takes the information from the camera and attaches that to the plabe
        WebCamTexture camTexture = new WebCamTexture();
        cameraPlane.GetComponent<MeshRenderer>().material.mainTexture = camTexture;
        camTexture.Play();

	}
	
	// Update is called once per frame
	void Update () {
        //if using a mobile device use the gyro
        if (Application.isMobilePlatform) {
            //use quaternion to store information for view rotation by receiving data from the gyro
            Quaternion rotationalFix = new Quaternion(Input.gyro.attitude.x, // left right
                                                Input.gyro.attitude.y, //up down
                                                -Input.gyro.attitude.z, // forward back
                                                -Input.gyro.attitude.w); // rotational space in 360 degrees

            //set the local rotation of the camera to the Quaternion value
            this.transform.localRotation = rotationalFix;

        }//if using a mobile device

    }
}
