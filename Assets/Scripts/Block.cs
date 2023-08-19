using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] spriteHits;

    // cached ref
    Level level;
    GameSession gameSession;

    // state
    [SerializeField] int timesHit = 0;

    void Start()
    {
        CountBreakableBlocks();
        gameSession = GameObject.FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = GameObject.FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = spriteHits.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlocks();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (spriteHits[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = spriteHits[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite is missing from " + gameObject.name);
        }
        
    }

    private void DestroyBlocks()
    {
        gameSession.UpdateCurrentScore();
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        Destroy(gameObject);
        TriggerBlockSparklesVFX();
        level.DestroyBreakableBlocks();
    }

    private void TriggerBlockSparklesVFX()
    {
        GameObject blockSparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(blockSparkles, 2f);
    }
}
