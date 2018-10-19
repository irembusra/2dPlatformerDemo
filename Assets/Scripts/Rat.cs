using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;


    private float animationTimer = 0;
    private float animationTime = 0.3f;
    public bool damaged = false;

    public Transform wallCheck;
    public float wallCheckRadious;
    public LayerMask whatIsWall;


    private bool hittingWall;
    private bool notAtEdge;
    private Animator anim_PlayerAnimator;

    public Transform edgeCheck;

    private Rigidbody2D rb;

    public int rat_health;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>() ;
        anim_PlayerAnimator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        anim_PlayerAnimator.SetBool("rat_die", damaged);
        if (damaged)
        {
            if (animationTimer > 0)
            {
                animationTimer -= Time.deltaTime;
            }
            else
            {
                damaged = false;
            }
        }
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadious, whatIsWall);
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadious, whatIsWall);

        if (hittingWall || !notAtEdge)
        { moveRight = !moveRight; }

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
           rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
           rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if(rat_health <= 0)
        {

            Destroy(gameObject);
        }
    
    }
   
    public void Damage(int dmg)
    {
        rat_health -= dmg;
        damaged = true;
        animationTime = animationTimer;

    }

}

