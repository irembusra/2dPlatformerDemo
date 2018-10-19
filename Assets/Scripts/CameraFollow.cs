using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
 
    public float f_SmoothTimeY;
    public float f_SmoothTimeX;

    public bool b_bounds;

    public Vector2 velocity;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, f_SmoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, f_SmoothTimeX);
        transform.position = new Vector3(posX, posY, transform.position.z);

        if(b_bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }
    public void SetMinCanPosition()
    {
        minCameraPos = gameObject.transform.position;
    }
    public void SetMaxCanPosition()
    {
        maxCameraPos = gameObject.transform.position;
    }
}
