using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed = 0.25f;

    void FixedUpdate(){

        Vector3 pos = transform.position;
        pos.x += speed * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
