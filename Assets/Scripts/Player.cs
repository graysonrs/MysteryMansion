using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int lives;
    public Image[] hearts;

    private float timer = 0f;
    private float delay = 6f;
    private int numOfHearts;

    // Start is called before the first frame update
    void Start()
    {
        numOfHearts = lives;
        Debug.Log(numOfHearts);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public int GetLives()
    {
        return numOfHearts;
    }

    public void LoseLife()
    {
        Debug.Log("Lost Life");
        numOfHearts--;
    }

    public void ResetLives()
    {
       numOfHearts = lives;
    }

    public void CaughtPlayer()
    {
        if (timer < delay)
        {
            timer += Time.deltaTime;
            return;
        }

        Debug.Log("Lives: " + GetLives());
        // LoseLife();
        timer = 0f;
    }
}
