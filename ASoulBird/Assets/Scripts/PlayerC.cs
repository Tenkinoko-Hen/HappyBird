using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class PlayerC : MonoBehaviour
{
    public static PlayerC instance;
    public float flySpeed;
    public delegate void DeathNotify();

    public event DeathNotify OnDeath;
    public UnityAction<int> OnGP;

    private Rigidbody2D birdRig;
    private Animator animator;
    private bool birdDie = false;
    private Vector3 initpos;

    // Start is called before the first frame update
    private void Awake()
    {
        birdRig = this.transform.GetComponent<Rigidbody2D>();
        animator = this.transform.GetComponent<Animator>();
        instance = this;
        this.Idel();
        initpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (birdDie)
        {
            return;
        }
       
            BirdMove();
        
        
     
    }
    
    private void BirdMove()
    {
        /*
         *	// 手指刚触摸到屏幕时必触发1次
         *	Input.GetTouch(0).phase == TouchPhase.Began;
         *	// 手指在屏幕滑动时触发多次
         *	 Input.GetTouch(0).phase == TouchPhase.Moved;
         *	// 手指长按屏幕触发多次
         *	 Input.GetTouch(0).phase == TouchPhase.Stationary;
         *	 // 手指从屏幕移开时必触发一次
         *	 Input.GetTouch(0).phase == TouchPhase.Ended;
         *	 // 取消追踪如用户将超过5根手指或者脸贴在屏幕触发
         *	  Input.GetTouch(0).phase == TouchPhase.Canceled;
         */
       
       
        if (Input.GetMouseButtonDown(0))
        {
            birdRig.velocity = Vector2.zero;
            birdRig.AddForce(new Vector2(0, flySpeed),ForceMode2D.Force);

        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                birdRig.velocity = Vector2.zero;
                birdRig.AddForce(new Vector2(0, flySpeed), ForceMode2D.Force);
            }
        }

       
    }
    

    public void Idel()
    {
        this.birdRig.simulated = false;
        animator.SetTrigger("stand");
    }

    public void fly()
    {
        this.birdDie = false;
        this.birdRig.simulated = true;

        animator.SetTrigger("Fly");
    }

    private void die()
    {
        birdDie = true;
        animator.SetTrigger("Die");
        if (this.OnDeath != null)
        {
            this.OnDeath();
        }
       
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==8)
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            die();
        }

      
    }
    
   

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("我的"+collision.gameObject.layer);

        if (collision.gameObject.layer == 10)
        {
     
            if (this.OnGP != null)
            {
                this.OnGP(1);
            }
        }

    }

    

    

    public void p_init()
    {
        transform .position= initpos;
        this.Idel();
    }

    
}
