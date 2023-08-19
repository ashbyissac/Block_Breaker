using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params
    [SerializeField] float minXOffset = 1f;
    [SerializeField] float maxXOffset = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // cached ref
    GameSession gameSession;
    Ball ball;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minXOffset, maxXOffset);  
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
