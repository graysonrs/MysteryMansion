using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int numOfHearts;
    public float invulnerabilityDuration;

    private bool isInvulnerable = false;
    private float timer = 0f;
    // private int numOfHearts;
    private bool dead;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // numOfHearts = lives;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Debug.Log($"In Update: {numOfHearts} // {gameObject.name}");
        if (numOfHearts <= 0)
        {
            dead = true;
        }
        if (isInvulnerable)
        {
            // Calculate the duration since the player became invulnerable
            timer += Time.deltaTime;
            // If the duration is less than the invulnerability duration, make the player sprite flicker
            if (timer < invulnerabilityDuration)
            {
                // Set the sprite renderer's enabled property based on the current time
                float remainder = timer % 0.2f;
                if (remainder < 0.1f)
                {
                    spriteRenderer.enabled = true;
                }
                else
                {
                    spriteRenderer.enabled = false;
                }
            }
            // Otherwise, make the player vulnerable again
            else
            {
                spriteRenderer.enabled = true;
                isInvulnerable = false;
                timer = 0f;
            }
        }
    }

    public int GetLives()
    {
        return numOfHearts;
    }

    public void LoseLife()
    {
        if (!isInvulnerable) {
            numOfHearts--;
            Debug.Log($"Lost life: {numOfHearts} // {gameObject.name}");
            if (numOfHearts <= 0)
            {
                dead = true;
            }
        }
    }

    public void CaughtPlayer()
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            Debug.Log("Lives: " + GetLives());
            // LoseLife();
        }
    }

    public bool isDead()
    {
        return dead;
    }
}
