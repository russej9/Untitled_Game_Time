﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour{

    Transform blockGenerator;
    Vector3 moveSpeed;

    public void SpawnCloud(Transform _blockGenerator)
    {
        moveSpeed.x = Random.Range(-0.3f, 0f);
        blockGenerator = _blockGenerator;
    }

    private void FixedUpdate()
    {
        transform.position += moveSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Cleaner")
        {
            Vector3 pos = transform.position;
            pos.x = blockGenerator.position.x;
            pos.y = Random.Range(1.8f, 2.4f);
            moveSpeed.x = Random.Range(-0.3f, 0f);

            transform.position = pos;
        }
    }
}
