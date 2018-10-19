using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] s_Hearth;

    public Image img_HearthImage;

    private PlayerMotor player;
	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        img_HearthImage.sprite = s_Hearth[player.i_CurHealth];
       
	}
}
