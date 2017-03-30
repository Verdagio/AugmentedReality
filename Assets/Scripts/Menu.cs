using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public string startLevel;

    public void NewGame()
    {
        Application.LoadLevel(startLevel);
    }


    public void Quit()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }
}
