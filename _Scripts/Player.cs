using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public BoolVariable playerAlive;

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;

    bool didFlap = false; //to check if player clicked mouse
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f; //firefly will always be moving

    public AudioSource playerAudioSource;
    public AudioClip playerFlap;
    public AudioClip playerCrash;
    public AudioClip playerLight;

    // Use this for initialization
    void Awake(){
        
        playerAlive.value = true;
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetMouseButtonDown(0)) //left mouse or single touch on smart device
        {
            didFlap = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (playerAlive.value)
        {
            MovePlayer();
        }
        
    }

    private void MovePlayer()
    {
        velocity.x = forwardSpeed;
        velocity += gravity; //velocity = velocity + gravity

        if (didFlap) //check if player flapped their wings
        {
            playerAudioSource.PlayOneShot(playerFlap);
            didFlap = false; //reset the flap

            if(velocity.y < 0)
            {
                velocity.y = 0;
            }

            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime; //deltaTime checks time since last physics check

        float angle = 0;
        if(velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -45, -velocity.y / maxSpeed); //this will make firefly tip nose as it is falling
            
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag != "Sky")
        {
            playerAudioSource.PlayOneShot(playerCrash);

            Debug.Log("Game Over");
            playerAlive.value = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Light")
        {
            playerAudioSource.PlayOneShot(playerLight);
        }
    }
}
