using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int numOfHearts;
    public float invulnerabilityDuration;
    public float flickerInterval = 0.2f;

    private bool isInvulnerable = false;
    private float timer = 0f;
    private bool dead;
    public AudioSource caughtAudio;

    void Update()
    {
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
                float remainder = timer % flickerInterval;
                bool show = remainder < flickerInterval / 2;
                SetAlphaRecursively(gameObject, show ? 1f : 0f);
            }
            // Otherwise, make the player vulnerable again
            else
            {
                SetAlphaRecursively(gameObject, 1f);
                isInvulnerable = false;
                timer = 0f;
            }
        }
    }

    private void SetAlphaRecursively(GameObject obj, float alpha)
    {
        Renderer[] renderers = obj.GetComponents<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                Color color = materials[i].color;
                color.a = alpha;
                materials[i].color = color;
            }
        }

        SkinnedMeshRenderer[] skinnedRenderers = obj.GetComponents<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skinnedRenderer in skinnedRenderers)
        {
            Material[] materials = skinnedRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                Color color = materials[i].color;
                color.a = alpha;
                materials[i].color = color;
            }
        }

        for (int i = 0; i < obj.transform.childCount; i++)
        {
            SetAlphaRecursively(obj.transform.GetChild(i).gameObject, alpha);
        }
    }

    public int GetLives()
    {
        return numOfHearts;
    }

    public void CaughtPlayer()
    {
        if (!isInvulnerable)
        {
            caughtAudio.Play();
            isInvulnerable = true;
            numOfHearts--;
            Debug.Log($"Lost life: {numOfHearts} // {gameObject.name}");
            if (numOfHearts <= 0)
            {
                dead = true;
            }
        }
    }

    public bool isDead()
    {
        return dead;
    }
}
