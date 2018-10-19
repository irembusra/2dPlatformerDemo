using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerMotor player;
	// Use this for initialization
	void Start () {

        player = gameObject.GetComponentInParent<PlayerMotor>();
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        player.b_Grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.b_Grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.b_Grounded = false;
    }
    

}
