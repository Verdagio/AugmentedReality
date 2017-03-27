using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float health;
    private int score;
    

	// Use this for initialization
	void Start () {
        health = 100f;
        score = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   public void setHealth(float h)
    {
        this.health = h;
    }

    public float getHealth()
    {
        return health;
    }

    public void setScore(int s)
    {
        this.score += s;
    }

    public int getScore()
    {
        return score;
    }
}
