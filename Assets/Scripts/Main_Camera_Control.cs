using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Control : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -moveSpeed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0, Space.World);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
        }
    }
}
