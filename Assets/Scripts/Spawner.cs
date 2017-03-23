using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject [] enemy;
    public float spawnDelay = 3f;
    public Transform[] spawnPoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
	}
	
    void Spawn(){
        //if(health.current < 0f)
        //{
        //    //exit
        //    return;
        //}

        int spawnIndex = Random.Range(0, spawnPoint.Length);
        int enemyIndex = Random.Range(0, enemy.Length);

        Instantiate(enemy[enemyIndex], spawnPoint[spawnIndex].position, spawnPoint[spawnIndex].rotation);
    }
}
