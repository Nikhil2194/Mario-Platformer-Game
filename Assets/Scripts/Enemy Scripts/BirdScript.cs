using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;

    private Vector3 moveDirection = Vector3.left;
    private Vector3 originalPosition;
    private Vector3 movePosition;


    public GameObject birdEgg;
    public LayerMask playerLayer;
    private bool attacked ;

    private bool canMove;


    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim  = GetComponent<Animator>();
    }
    void Start()
    {
        originalPosition = transform.position;
        originalPosition.x = originalPosition.x = 6f;  //travel to 6 units


        movePosition = transform.position;
        movePosition.x = movePosition.x - 6f;  // travel to -6 units


        canMove = true;
        
    }

   
    void Update()
    {
        MoveTheBird();
        DropTheEgg();
    }


    void MoveTheBird()
    {
        if (canMove)
        {
            transform.Translate(moveDirection * Time.smoothDeltaTime * 2.5f);

            if(transform.position.x >= originalPosition.x)
            {
                moveDirection = Vector3.left;
                ChangeDirection(0.5f);
            }
            else if(transform.position.x <= movePosition.x)
            {
                moveDirection = Vector3.right;
                ChangeDirection(-0.5f);
            }
        }
    }

    void ChangeDirection (float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    void DropTheEgg()
    {
        if (!attacked)
        {
            if(Physics2D.Raycast (transform.position, Vector2.down, Mathf.Infinity, playerLayer))
            {
                Instantiate(birdEgg, new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z), Quaternion.identity);
                attacked =  true;
                anim.Play("BirdFly");
            }
        }
    }

    IEnumerator BirdDead()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == MyTags.BULLET_TAG)
        {
            anim.Play("BirdDead");

            GetComponent<BoxCollider2D>().isTrigger = true;   // after dead the bird body will fall down
            myBody.bodyType = RigidbodyType2D.Dynamic;  // its set to kinematic so making it dynamic so that it will fall

            canMove = false;

            StartCoroutine(BirdDead());
        }
    }
}
