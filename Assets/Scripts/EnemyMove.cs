using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* In the enemy move script we handle enemy movement
 * enemy attacks, collision detection destruction etc.
 */ 
public class EnemyMove : MonoBehaviour {

    private Vector3 dir;
    private float speed;
    private int x;

    // Use this for initialization
    void Start () {
        x = 1;
        StartCoroutine("MoveAndDestroy");                  // start a couroutine of destroy
    }//start
	
	// Update is called once per frame
	void Update () {
        Motion();
	}//update

    IEnumerator MoveAndDestroy() {
        while (true) {                     
            if(gameObject.tag == "UAV"){

                InvokeRepeating("Fire", 1f, .25f);                   // call the fire method every 1 second

                yield return new WaitForSeconds(3f);                // wait 3 seconds
                x *= -x;                                            // always give the opposite
                transform.Translate(new Vector3(x, 0, 0));          // move the opposite direction

                yield return new WaitForSeconds(6f);                // ensure objects are being destroyed eventually
                Destroy(this.gameObject);                           
            } else {

                yield return new WaitForSeconds(8f);                // wait 8 seconds
                Destroy(this.gameObject);                           // Destroy the object its off screen, free up memory
            }//if
        }//while
    }//movement

    // collision detection
    void OnTriggerEnter(Collider colBox) {

        GameObject explode = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
        explode.transform.position = transform.position;                        // spawn it at the enemies current position
        Destroy(gameObject);                                                    // the enemy hit the player destroy it
        Destroy(explode, 3);                                                    // destroy its particle effects also

        colBox.GetComponent<AudioSource>().Play();                              // play a sound so the player knows they have been hit
    }//on collision
       
    //movement 
    void Motion() {
        speed = Random.Range(5, 10);
        if(gameObject.tag == "UAV") {
            dir = new Vector3(x, 0, 0);                                         // set the direction 
            transform.Translate(dir * (speed * Time.deltaTime));                // set the speed of the direction
            
        } else {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));    // move the enemy towards the player.
        }//if / else
       
    }//motion

    void Fire() {
        //create an instance of a new laser
        GameObject laser = Instantiate(Resources.Load("enemyLaser", typeof(GameObject))) as GameObject;

        Rigidbody rigid = laser.GetComponent<Rigidbody>();                      // add a collision box to laser
        
        laser.transform.rotation = transform.rotation;                          // set the rotation of the laser
        laser.transform.position = transform.position + transform.forward * 2;  // set the position of the laser
        rigid.AddForce(transform.forward * 666f);                               // set the force of the laser moving forward
        laser.transform.LookAt(Camera.main.transform);                          // point at the player
        Destroy(laser, 3f);                                                     // Destroy the laser after a few seconds to free up memory
    }
}//class
