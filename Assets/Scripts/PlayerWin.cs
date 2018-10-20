using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWin : MonoBehaviour {

public Text winText;
 void Start() {
winText.text="";	
}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.GetComponent<PlayerMotor>() != null) {
			other.gameObject.GetComponent<Animator>().SetBool("win", true);
			other.gameObject.GetComponent<PlayerMotor>().enabled = false;
			winText.text="You Win";
		}
	}
}
