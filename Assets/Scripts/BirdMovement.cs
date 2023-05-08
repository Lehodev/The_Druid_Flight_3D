using UnityEngine;
using System.Collections;
using System;

public class BirdMovement : MonoBehaviour
{

    public float jumpStrength = 200f;

    private Rigidbody birdRb;
    private bool isDead = false;
    private int score = 0;

    void Start()
    {
        birdRb = GetComponent<Rigidbody>();
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
            GameControlling.instance.BirdDied();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ScoreZone"))
        {
            score++;
            GameControlling.instance.UpdateScore(score);
        }
    }
}