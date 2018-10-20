using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour {


    public float f_MaxSpeed = 3f;
    public float f_Speed = 50f;
    public float f_JumpPower = 350f;
    private float animationTimer = 0;
    private float animationTime = 0.3f;

    public int i_CurHealth;
    public int i_MaxHealth = 5;

    public bool b_Grounded;
    public bool b_CanDoubleJump;
    public bool facingRight = true;
    public bool wallSliding;
    public bool wallCheck;
    public bool b_Die = false;
    public bool damaged = false;

    private Rigidbody2D rb_RigidBody;

    private Animator anim_PlayerAnimator;

    public Transform wallCheckPoint;

    public LayerMask wallLayerMask;
	// Use this for initialization
	void Start () {
        rb_RigidBody = gameObject.GetComponent<Rigidbody2D>();

        anim_PlayerAnimator = gameObject.GetComponent<Animator>();

        i_CurHealth = i_MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {

        anim_PlayerAnimator.SetBool("damaged", damaged);
        anim_PlayerAnimator.SetBool("grounded", b_Grounded);
        anim_PlayerAnimator.SetBool("Die", b_Die);
        anim_PlayerAnimator.SetFloat("speed", Mathf.Abs(rb_RigidBody.velocity.x));
        if (damaged)
        {
            if(animationTimer>0)
            {
                animationTimer -= Time.deltaTime;
            }
            else
            {
                damaged = false;
            }
        }
       
		if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        if(Input.GetButtonDown("Jump") && !wallSliding )
        {
            if(b_Grounded)
            {
                rb_RigidBody.AddForce(Vector2.up * f_JumpPower);
                b_CanDoubleJump = true;
            }
            else
            {
                if(b_CanDoubleJump)
                {
                    b_CanDoubleJump = false;
                    rb_RigidBody.velocity = new Vector2(rb_RigidBody.velocity.x, 0);
                    rb_RigidBody.AddForce(Vector2.up * f_JumpPower / 1.50f);
                }
            }    
        }

        if(i_CurHealth > i_MaxHealth)
        {
            i_CurHealth = i_MaxHealth;
        }
        if(i_CurHealth <= 0)
        {
            Die();
        }

        if(!b_Grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);
            if(facingRight && Input.GetAxis("Horizontal")> 0.1f || !facingRight && Input.GetAxis("Horizontal")<0.1f)
            {
                if(wallCheck)
                {
                    HandleWallSliding();
                }
            }
        }
        if(wallCheck==false || b_Grounded)
        {
            wallSliding = false;
        }
    }

    void HandleWallSliding()
    {
        rb_RigidBody.velocity = new Vector2(rb_RigidBody.velocity.x ,- 0.7f);
        wallSliding = true;
        if(Input.GetButtonDown("Jump"))
        {
            if(facingRight)
            {
                rb_RigidBody.AddForce(new Vector2(-4, 2) * f_JumpPower);
            }
            else
            {
                rb_RigidBody.AddForce(new Vector2(4, 2) * f_JumpPower);
            }
        }
    }
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb_RigidBody.velocity;
        easeVelocity.y = rb_RigidBody.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float f_h = Input.GetAxis("Horizontal");

        // Fake friction / Easing the x speed of our player

        if(b_Grounded)
        {
            rb_RigidBody.velocity = easeVelocity;
        }

        // Moving the player
        if(b_Grounded)
        {
            rb_RigidBody.AddForce((Vector2.right * f_Speed) * f_h);
        }
        else
        {
            rb_RigidBody.AddForce((Vector2.right * f_Speed / 2) * f_h);
        }
    

        // Limiting the speed of the player
        if(rb_RigidBody.velocity.x > f_MaxSpeed)
        {
            rb_RigidBody.velocity = new Vector2(f_MaxSpeed, rb_RigidBody.velocity.y);
        }
        if (rb_RigidBody.velocity.x < -f_MaxSpeed)
        {
            rb_RigidBody.velocity = new Vector2(-f_MaxSpeed, rb_RigidBody.velocity.y);
        }
    }

    void Die()
    {

        //restart
        SceneManager.LoadScene("SampleScene");
        
        b_Die = true;
        
    }
    public void Damage(int damagesize)
    {
        i_CurHealth -= damagesize;
        anim_PlayerAnimator.Play("Player_damage", -1, 0f);
        damaged = true;
        animationTimer = animationTime;


    }

    public IEnumerator Knockback(float knockDur , float knockbackPwr , Vector3 knockbackDir)
    {
        float timer = 0;
        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            rb_RigidBody.velocity = new Vector2(rb_RigidBody.velocity.x, 0);
            rb_RigidBody.AddForce(new Vector3(knockbackDir.x * - 200, knockbackDir.y + knockbackPwr, transform.position.z));
        }
        yield return 0;
    }

 
}

