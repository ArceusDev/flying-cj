using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Animator animator;
    Collider2D currentCollider;
    [SerializeField] Collider2D floorCollider;
    [SerializeField] GameObject fire;
    [SerializeField] private float upwardForce;
    [SerializeField] private float horizontalForce;
    Coroutine upwardMovement;
    Coroutine leftMovement;
    Coroutine rightMovement;

    bool isJumping;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentCollider= GetComponent<Collider2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        isJumping = Physics2D.IsTouching(currentCollider, floorCollider);

        animator.SetBool("isJumping", !isJumping);
        
        fire.SetActive(!isJumping);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            upwardMovement = StartCoroutine(UpwardMovement());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(upwardMovement);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rightMovement = StartCoroutine(RightMovement());
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            StopCoroutine(rightMovement);
            rigidbody.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            leftMovement = StartCoroutine(LeftMovement());
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            StopCoroutine(leftMovement);
            rigidbody.velocity = Vector3.zero;
        }
    }

    IEnumerator UpwardMovement()
    {
        while (true)
        {
            rigidbody.AddForce(new Vector2(0, upwardForce), ForceMode2D.Impulse);
            /*animator.SetBool("isJumping", true);*/
            yield return new WaitForSeconds(0.1f);
        }     
    }
    IEnumerator RightMovement()
    {
        while (true)
        {
            rigidbody.AddForce(new Vector2(horizontalForce, 0), ForceMode2D.Force);
            yield return new WaitForSeconds(0.0001f); 
        }
    }
    IEnumerator LeftMovement()
    {
        while (true)
        {
            rigidbody.AddForce(new Vector2(-horizontalForce, 0), ForceMode2D.Force);
            yield return new WaitForSeconds(0.0001f); 
        }
    }
    private void FixedUpdate()
    {
        
    }
}
