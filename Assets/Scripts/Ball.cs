//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocityOffset = 2f;
    [SerializeField] float yVelocityOffset = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float bounceRandomFactor = 0.2f;

    // cached ref
    Vector2 paddleToBallVector;
    AudioSource audioSource;
    Rigidbody2D rb;

    // State
    [SerializeField] bool hasStarted = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LauchBall();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddle1Pos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddle1Pos + paddleToBallVector;
    }

    private void LauchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(xVelocityOffset, yVelocityOffset);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomRange = Random.Range(-bounceRandomFactor, bounceRandomFactor);
        Vector2 bounceVelocity = new Vector2(randomRange, randomRange);
        if (hasStarted)
        {
            int index = Random.Range(0, ballSounds.Length);
            AudioClip audioClip = ballSounds[index];
            audioSource.PlayOneShot(audioClip);
            rb.velocity += bounceVelocity;
        }
    }
}
