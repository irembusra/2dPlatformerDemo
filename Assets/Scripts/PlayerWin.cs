using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.GetComponent<PlayerMotor>() != null) {
			other.gameObject.GetComponent<Animator>().SetBool("win", true);
			other.gameObject.GetComponent<PlayerMotor>().enabled = false;
		}
	}
}
