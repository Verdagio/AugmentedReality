using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private Player player;
    
    // Use this for initialization
    void Start () {

        player = gameObject.GetComponent<Player>();
        StartCoroutine("Movement");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * (4f * Time.deltaTime));     //move the enemy towards the player.
	}
    IEnumerator Movement() {
        while (true) {                                               
            yield return new WaitForSeconds(6f);                //wait 6 seconds
            Destroy(this.gameObject);                           //Destroy the object its off screen, free up memory
        }
    }

    void OnTriggerEnter(Collider colBox) {

        GameObject explode = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
        explode.transform.position = transform.position;        //spawn it at the enemies current position
        Destroy(this.gameObject);                               //the enemy hit the player destroy it
        Destroy(explode, 3);                                    //destroy its particle effects also

        colBox.GetComponent<AudioSource>().Play();              //play a sound so the player knows they have been hit

        player.setHealth(player.getHealth() - 5f);              //set the players health.

    }//on collision
}
