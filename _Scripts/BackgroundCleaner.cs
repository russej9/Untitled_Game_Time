using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCleaner : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            float widthObject = ((BoxCollider2D)collision).size.x; //must make sure to indicate 2D box collider
            Vector3 position = collision.transform.position;
            position.x += widthObject * 1.99f; //need 1.99 to avoid weird pixelation
            collision.transform.position = position;
        }
    }
}
