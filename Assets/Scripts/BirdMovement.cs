using UnityEngine;
using System.Collections;
using System;

public class BirdMovement : MonoBehaviour
{

    public float jumpStrength = 200f;

    private Rigidbody birdRb;
    private bool isDead = false;
    private int point = 0;

    void Start()
    {
        birdRb = GetComponent<Rigidbody>();
        birdRb.velocity = Vector3.zero;
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        birdRb.velocity = Vector3.zero;
        birdRb.AddForce(new Vector3(0, jumpStrength, 0));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            GameControlling.controller.BirdDied();
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            point++;
            GameControlling.controller.UpdatePoint(point);
        }
    }
}