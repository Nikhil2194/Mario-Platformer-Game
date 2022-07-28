using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    public LayerMask Playerlayer;

    private bool moveLeft;

    private bool CanMove;
    private bool stunned;


    public Transform left_Collision, right_Collision, top_Collision, down_Collision;
    private Vector3 left_Collision_Pos, right_Collision_Pos;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        left_Collision_Pos = left_Collision.position;
        right_Collision_Pos= right_Collision.position;
    }
    void Start()
    {
        moveLeft = true;
        CanMove = true;
    }

   
    void Update()
    {
        if (CanMove)
        {
            if (moveLeft)
            {
                myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);

            }
            else
            {
                myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
            }
        }

        CheckCollision();
    }


    void CheckCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(left_Collision.position, Vector2.left, 0.1f,Playerlayer);
        RaycastHit2D rightHit = Physics2D.Raycast(right_Collision.position, Vector2.right, 0.1f, Playerlayer);

        Collider2D topHit = Physics2D.OverlapCircle(top_Collision.position, 0.2f, Playerlayer);

        if(topHit != null)
        {
            if (topHit.gameObject.tag == MyTags.PLAYER_TAG)
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    CanMove = false;
                    myBody.velocity = new Vector2(0, 0);
                    anim.Play("Stunned");
                    stunned = false;
              
                     // BEETLE TAG code
                   if (tag == MyTags.BEETLE_TAG)
                    {
                        anim.Play("Stunned");
                        StartCoroutine(Dead(0.5f));
                    }
                   
                }
            }

            if(leftHit)
            {
                if(leftHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
                {
                    if(!stunned)
                    {
                        //apply damage to player
                    }
                    else
                    {
                        if (tag != MyTags.BEETLE_TAG)
                        {
                            myBody.velocity = new Vector2(15f, myBody.velocity.y);
                            StartCoroutine(Dead(3f));
                        }
                    }

                }
            }
            if (rightHit)
            {
                if (rightHit.collider.gameObject.tag == MyTags.PLAYER_TAG)
                {
                    if (!stunned)
                    {
                        //apply damage to player
                    }
                    else
                    {
                        if (tag != MyTags.BEETLE_TAG)
                        {
                            myBody.velocity = new Vector2(-15f, myBody.velocity.y);
                            StartCoroutine(Dead(3f));
                        }
                    }

                }
            }
        }
        if (!Physics2D.Raycast(down_Collision.position, Vector2.down, 0.1f))
        {
            ChangeDirection();
        }
    }


    void ChangeDirection()
    {
        moveLeft = !moveLeft;
        Vector3 tempScale = transform.localScale;
        left_Collision.position = left_Collision_Pos;
        right_Collision.position = right_Collision_Pos;

        if(moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);

            left_Collision.position = right_Collision_Pos;
            right_Collision.position = left_Collision_Pos;
        }

        transform.localScale = tempScale;
    }


    IEnumerator Dead (float timer)
    {
        yield return new WaitForSeconds(timer);
        
            gameObject.SetActive (false);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(  collision.tag == MyTags.BULLET_TAG)
        {
            if (tag == MyTags.BEETLE_TAG)
            {
                anim.Play("Stunned");
                CanMove = false;
                myBody.velocity = new Vector2(0, 0);
                StartCoroutine(Dead(0.4f));
            }
            if (tag == MyTags.Snail_TAG)
            {
                if (!stunned)
                {
                    anim.Play("Stunned");
                    stunned = true;
                    CanMove = false;
                    myBody.velocity = new Vector2(0, 0);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

      
    }


}
