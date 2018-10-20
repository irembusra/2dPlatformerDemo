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
            StartCoroutine(player.Knockback(0.04f, 150, player.transform.position));
        }
    }
}
