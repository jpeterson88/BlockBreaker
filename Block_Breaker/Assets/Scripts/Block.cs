using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    //Only serialized for debug purposes
    [SerializeField] int timesHit;
    Level level;

    private readonly string breakableText = "Breakable";

    private void Start()
    {
        level = FindObjectOfType<Level>();

        if (tag == breakableText)
        {
            level.CountBlocks();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == breakableText)
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;

        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore();
    }
}
