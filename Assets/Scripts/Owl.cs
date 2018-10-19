using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owl : MonoBehaviour {
   private int rat_health = 40 ;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rat_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(int dmg)
    {
        rat_health -= dmg;
    }
}
