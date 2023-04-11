using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgorundHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float scrollSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * Time.deltaTime * scrollSpeed;
        if (transform.position.x < -10)
        {
            transform.position = new Vector2(10.0f, 0);
        }
    }
}
