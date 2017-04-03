using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* In the camera script we deal with the following
 * Taking the information stream from the device's camera
 * & displaying this onto a plane.
 * We also handle the logic relating to the device's gyroscope
 * We also handle the pause menu logic 
 */ 
public class CameraScript : MonoBehaviour {

    // variables will be shown and editable in inspector
    public GameObject cameraPlane;
    public GameObject cameraParent = null;
    public Button pauseButton;
    public GameObject pauseMenu;

    // audio stuff
    public GameObject [] objs;
    public Text sfxText;
    public Text mText;

    //hidden
    private WebCamTexture camTexture;

    // Use this for initialization
    void Start() {
        
        // allows to look around in a natural way
        cameraParent = new GameObject("cameraParent");
        cameraParent.transform.position = this.transform.position;      // set the parents position to the camera
        this.transform.parent = cameraParent.transform;
        cameraParent.transform.Rotate(Vector3.right, 90);

        //if the device has a gyroscope in it use this will 
        Input.gyro.enabled = true;

        //create a new web cam texture and assign the camera plane its texture
        //This takes the information from the camera and attaches that to the plabe
        camTexture = new WebCamTexture();
        cameraPlane.GetComponent<MeshRenderer>().material.mainTexture = camTexture;
        camTexture.Play();

        //Event listener for the pause button   
        pauseButton.onClick.AddListener(OnPause);

    }//start

    public void OnPause(){                                              // allow the user to pause their game
        pauseMenu.SetActive(true);                                      // opens the pause screen
        Time.timeScale = 0f;                                            //sets the timescale to 0 pausing everything
    }//pause

    public void Resume(){                                               // allows the user to resume their game
        pauseMenu.SetActive(false);                                     // closes the pause screen
        Time.timeScale = 1f;                                            // set the timescale to 1 unpausing everything
    }//resume

    public void Quit(){                                                 // allows the user to return to the main menu
        SceneManager.LoadScene(0);                                      // load a game scene (menu)
        Time.timeScale = 1f;                                            // set the timescale to 1 unpausing everything
        camTexture.Stop();                                              // stops the camera
    }//quit

    public void Mute() {

        AudioSource tmp = Camera.main.GetComponent<AudioSource>();
        if (tmp.mute) {
            tmp.mute = false;
            mText.text = "ON";
        } else {
            tmp.mute = true;
            mText.text = "OFF";
        }// if else if
    }// mute

    public void MuteSfx() {

        for(int i = 0; i < objs.Length; i++) {
            AudioSource tmp = objs[i].GetComponent<AudioSource>();
            if (tmp.mute) {
                tmp.mute = false;
                sfxText.text = "ON";
            } else {
                tmp.mute = true;
                sfxText.text = "OFF";
            }// mute / un mute lasers
        }//for
    }//sfx

    // Update is called once per frame
    void Update () {
    
        //use quaternion to store information for view rotation by receiving data from the gyro
        Quaternion rotationalFix = new Quaternion(Input.gyro.attitude.x,        // left right
                                                Input.gyro.attitude.y,          // up down
                                                -Input.gyro.attitude.z,         // forward back
                                                -Input.gyro.attitude.w);        // rotational space in 360 degrees

        //set the local rotation of the camera to the Quaternion value
        this.transform.localRotation = rotationalFix;
        
        
        
    }


}
