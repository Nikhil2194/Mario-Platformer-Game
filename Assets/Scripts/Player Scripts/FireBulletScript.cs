using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletScript : MonoBehaviour
{
    private float speed = 10f;
    private Animator anim;
    private bool canMove;


    private void Awake()
    {
        anim = GetComponent<Animator>();
     
    }
    void Start()
    {
        canMove = true;
        StartCoroutine(DisableBullet(5f));
    }

 
    void Update()
    {
        Move();
    }

   
    private void Move()
    {if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
            gameObject.SetActive(false);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == MyTags.BEETLE_TAG || collision.gameObject.tag == MyTags.Snail_TAG || collision.gameObject.tag == MyTags.SPIDER_TAG)
        {
            anim.Play("Explode");
            canMove = false;
            StartCoroutine(DisableBullet(0.1f));
        }
    }
}
