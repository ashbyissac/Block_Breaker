using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 5f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 75;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled = false;

    void Awake()
    {
        int gameStatusCount = GameObject.FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();    
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void UpdateCurrentScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(this.gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
    }
}
