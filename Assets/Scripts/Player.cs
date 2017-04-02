using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public Text scoreText;              // Display score during play
    public Text healthText;             // Display health during play
    public Text finalScore;             // Display players score at end of game
    public Text finalHiScore;           // Display high score at end of game
    public Text hiText;                 // Display high score druing play
    public GameObject deathScreen;      // Game over screen
    public float score;                 // Realtime score 
    private int highScore;              // High score 
    public int health;                  // health value 

	// Use this for initialization
	void Start () {
        
        deathScreen.SetActive(false);
        highScore = PlayerPrefs.GetInt("HighScore", 0);                      //get the high score from memory
        health = 100;
        score = 0;
	}//start    
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + (int) score;                   // update and display the players score
        healthText.text = "Health: " + health;                      // display health
        hiText.text = highScore + ": High";                         // display high score
        score += .01f;                                              // update the score
	}//update method

    private void OnTriggerEnter(Collider other)
    {
        //if an enemy bumps into us take some damage 
        if (other.gameObject.tag.Equals("Enemy")){
            health -= Random.Range(5, 12);
        }//if
        
        //if our health gets to 0 or lower
        if(health <= 0) {
            
            health = 0;
            //check to see if the high score has been beaten
            if(highScore < score) {
                PlayerPrefs.SetInt("HighScore", (int) score);                //set the high score
                PlayerPrefs.Save();                                          //save to memory
                
            }//inner if

            finalHiScore.text = "High score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
            finalScore.text = "Your Score: " + (int)score;
            Time.timeScale = 0f;                                            //sets the timescale to 0 stopping everything
            deathScreen.SetActive(true);                                    //load the game over screen
        }//if
    }//on trigger
 
}//class
