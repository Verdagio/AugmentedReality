using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* In the player class we handle everything relating to the player
 * We track and display ammo, health, score & high scores
 * If the players health reaches zero we display the death screen
 * We handle the event for the fire button, & reloading.
 */
public class Player : MonoBehaviour {

    // UI vars
    public Text scoreText;              // Display score during play
    public Text healthText;             // Display health during play
    public Text finalScore;             // Display players score at end of game
    public Text finalHiScore;           // Display high score at end of game
    public Text hiText;                 // Display high score druing play
    public GameObject deathScreen;      // Game over screen
    // control vars
    public float score;                 // Realtime score 
    private int highScore;              // High score 
    public int health;                  // health value 
    // attack vars
    public Button fireButton;           // Attack button
    public Text ammoText;               // Displays current ammo
    public Text btnText;                // interchange between fire / reload
    private int ammo;                   // control variable

    // Use this for initialization
    void Start () {
                           
        deathScreen.SetActive(false);                                           // Make the death screen inactive
        highScore = PlayerPrefs.GetInt("HighScore", 0);                         // get the high score from memory
        health = 100;
        score = 0;
        ammo = 50;
        btnText.text = "Fire";
        fireButton.onClick.AddListener(FireWeapon);                             // add an event listener                        
    }//start    
	
	// Update is called once per frame
	void Update () {

        if(health > 0 && Time.timeScale == 1){                                  // make sure the player is alive and the game is not paused
            score += .01f;                                                      // update the score
        }// if the player is alive

        scoreText.text = "Score: " + (int)score;                                // update and display the players score
        healthText.text = "Health: " + health;                                  // display health
        hiText.text = highScore + ": High";                                     // display high score
        ammoText.text = ammo.ToString();                                        // display the ammo
        
    }//update method

    private void OnTriggerEnter(Collider other) {
        //if an enemy bumps into us take some damage 
        if (other.gameObject.tag.Equals("Enemy")){
            health -= Random.Range(5, 12);
        }//if
        
        //if our health gets to 0 or lower
        if(health <= 0) {
            
            health = 0;
            //check to see if the high score has been beaten
            if(highScore < score) {
                PlayerPrefs.SetInt("HighScore", (int) score);                   // set the new high score
                PlayerPrefs.Save();                                             // save to local storage
            }//inner if

            finalHiScore.text = "High score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
            finalScore.text = "Your Score: " + (int)score;                      // Display the final score for the player
            Time.timeScale = 0f;                                                // sets the timescale to 0 stopping everything
            deathScreen.SetActive(true);                                        // load the game over screen
        }//if
    }//on trigger

    void FireWeapon() {
        
        if(ammo > 0) {         
            //create an instance of a new laser
            GameObject laser = Instantiate(Resources.Load("laser", typeof(GameObject))) as GameObject;
            laser.GetComponent<AudioSource>().Play();                           // play a sound when fired

            Rigidbody rigid = laser.GetComponent<Rigidbody>();                  // add a collision box to laser
            laser.transform.rotation = Camera.main.transform.rotation;          // set the rotation of the laser
            laser.transform.position = Camera.main.transform.position;          // set the position of the laser
            rigid.AddForce(Camera.main.transform.forward * 666f);               // set the force of the laser moving forward

            Destroy(laser, 1.5f);                                               // Destroy the laser after a few seconds to free up memory
            ammo--;                                                             // Decrement the ammo counter
        } else {
            btnText.text = "Reloading";                                         // change the text so the user knows whats happening
            fireButton.GetComponent<AudioSource>().Play();                      // play the reload sound
            fireButton.interactable = false;                                    // while reloading we disable the fire button
            InvokeRepeating("Reload",3f, 0f);                                   // call this method after 3 seconds    
        }// if else if
        
     
    }//button pressed

    // Reloads the players weapon
    void Reload(){
        
        if(ammo <= 0) {
            ammo = 50;                                                          // reset the ammo
            fireButton.interactable = true;                                     // re - enable the fire button
            btnText.text = "Fire";                                              // change the text back to fire
        }    // only do this if ammo is 0
        
    }//reload
}//class
