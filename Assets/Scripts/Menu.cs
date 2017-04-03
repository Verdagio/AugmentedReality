using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* In the Menu class we deal with loading into the game scene
 * We also deal with quitting the game
 */ 
public class Menu : MonoBehaviour {

    // start a new game
    public void NewGame() {
        SceneManager.LoadScene(1);
    }// play game

    // Open the Options menu
    public void Options() {
        SceneManager.LoadScene(2);
    }// options

    // Close the application
    public void Quit() {
        Debug.Log("Exiting game");
        Application.Quit();
    }// Quit
}
