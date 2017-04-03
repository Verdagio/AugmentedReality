using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* In the spawner class we handle spawning enemy gameobjects
 * The enemies will be spawned at random spawn points
 * They will also spawn random enemy types.
 */
public class Spawner : MonoBehaviour {


    public GameObject[] enemy;
    public Transform[] spawnPoint;

    // Use this for initialization
    void Start () {
        float delay = 2f;
        InvokeRepeating("Spawn", delay, 1);       //Call the spawn method every few seconds 

    }//void start
	
    void Spawn(){

            //get a random index for the enemy & spawn position
            int spawnIndex = Random.Range(0, spawnPoint.Length);
            int enemyIndex = Random.Range(0, enemy.Length);

            //instantiate a new random enenmy @ a random spawnpoint.
            Instantiate(enemy[enemyIndex], spawnPoint[spawnIndex].position, spawnPoint[spawnIndex].rotation);

    }//spawn
}//class
