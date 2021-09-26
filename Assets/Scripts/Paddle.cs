using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public float Left;
    public float Right;
    public string axis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis(axis) * speed * Time.deltaTime;
        float nextPos = transform.position.x + movement;
        if (nextPos < Left) { movement = 0; }
        if (nextPos > Right) { movement = 0;}
        transform.Translate(movement, 0, 0);
    }
}