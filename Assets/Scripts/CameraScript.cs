using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {


    public GameObject cameraPlane;
    public GameObject cameraParent = null;
    public Button fireButton;
    public Button pauseButton;
    public string mainMenu;
    public GameObject pauseMenu;
    private WebCamTexture camTexture;

    // Use this for initialization
    void Start() {
        

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
        camTexture = new WebCamTexture();
        cameraPlane.GetComponent<MeshRenderer>().material.mainTexture = camTexture;
        camTexture.Play();

        //Event listener for buttons
        fireButton.onClick.AddListener(OnPressed);
        pauseButton.onClick.AddListener(OnPause);

    }//start

    void OnPressed() {

        //create an instance of a new laser
        GameObject laser = Instantiate(Resources.Load("laser", typeof(GameObject))) as GameObject;

        //play a sound when fired
        GetComponent<AudioSource>().Play();

        Rigidbody rigid = laser.GetComponent<Rigidbody>();              //add a collision box to laser
        laser.transform.rotation = Camera.main.transform.rotation;      //set the rotation of the laser
        laser.transform.position = Camera.main.transform.position;      //set the position of the laser
        rigid.AddForce(Camera.main.transform.forward * 666f);           //set the force of the laser moving forward

        //Destroy the laser after a few seconds to free up memory.a
        Destroy(laser, 1.5f);


        
    }//button pressed

    public void OnPause(){                                              // allow the user to pause their game
        pauseMenu.SetActive(true);                                      // opens the pause screen
        Time.timeScale = 0f;                                            //sets the timescale to 0 pausing everything
    }

    public void Resume(){                                               // allows the user to resume their game
        pauseMenu.SetActive(false);                                     // closes the pause screen
        Time.timeScale = 1f;                                            // set the timescale to 1 unpausing everything
    }

    public void Quit(){                                                 // allows the user to return to the main menu
        Application.LoadLevel(mainMenu);                                // load a game scene
        Time.timeScale = 1f;                                            // set the timescale to 1 unpausing everything
        camTexture.Stop();                                              // stops the camera
    }

    // Update is called once per frame
    void Update () {
        //if using a mobile device use the gyro
        if (Application.isMobilePlatform) {
            //use quaternion to store information for view rotation by receiving data from the gyro
            Quaternion rotationalFix = new Quaternion(Input.gyro.attitude.x,    // left right
                                                Input.gyro.attitude.y,          //up down
                                                -Input.gyro.attitude.z,         // forward back
                                                -Input.gyro.attitude.w);        // rotational space in 360 degrees

            //set the local rotation of the camera to the Quaternion value
            this.transform.localRotation = rotationalFix;

        }//if using a mobile device

    }
}
