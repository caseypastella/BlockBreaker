using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Config Params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject SparkleEffect;
    
    [SerializeField] Sprite[] hitSprites;
    //References
    level level;

    //State Variables
    [SerializeField] int timesHit;
    
    
    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.countBlocks();
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
        int maxHits = hitSprites.Length + 1; 
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
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
       else
        {
            Debug.LogError("Block Sprite is missing from array" + gameObject.name);

        }
    }

    private void DestroyBlock()
    {
        
            PlayBlockSounds();
            Destroy(gameObject);
            level.brokenBlocks();
            FindObjectOfType<gamestatus>().addPoints();
            onTriggerEffects();
        
    }

    private void PlayBlockSounds()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
    }

    private void onTriggerEffects()
    {
        GameObject sparkles = Instantiate(SparkleEffect, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
    
}
