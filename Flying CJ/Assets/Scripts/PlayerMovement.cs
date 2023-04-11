using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float upwardForce;
    [SerializeField] private float horizontalForce;
    Coroutine upwardMovement;
    Coroutine leftMovement;
    Coroutine rightMovement;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            leftMovement = StartCoroutine(LeftMovement());
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            StopCoroutine(leftMovement);
        }
    }

    IEnumerator UpwardMovement()
    {
        while (true)
        {
            rigidbody.AddForce(new Vector2(0, upwardForce), ForceMode2D.Impulse);
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
