using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

    

    private PlayerMotor player;
    private CoinManager coinManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        coinManager=GameObject.FindGameObjectWithTag("Player").GetComponent<CoinManager>();

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            coinManager.totalGold++;
         
            Destroy(gameObject);
        }
    }
}
