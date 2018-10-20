using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat_Damage : MonoBehaviour {

    
    private PlayerMotor player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
            //StartCoroutine(player.Knockback(0.02f, 150, player.transform.position));
            var playerController = col.GetComponent<PlayerMotor>();
            playerController.knockbackCount = playerController.knockbackLength;
            if (transform.position.x - col.transform.position.x > 0)
                playerController.knockFromRight = true;
            else
                playerController.knockFromRight = false;
        }
    }
}
