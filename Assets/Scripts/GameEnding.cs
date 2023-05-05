using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f; //screen to fade out over a certain period of time. It should be a public variable, so you can adjust it from the Inspector. 
    public float displayImageDuration = 1f; //duration of the image to be displayed.
    public GameObject player; // fade should happen when the player’s character hits the Trigger.
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    public CheckKeys keys;

    bool m_IsPlayerAtExit; // You need a way of knowing when to start fading the Canvas Group in. Since the Canvas Group should either be fading or not, a bool variable is perfect for this. 

    float m_Timer; // timer, to ensure that the game doesn't end before the fade has finished.
    bool m_HasAudioPlayed;

    void OnTriggerEnter (Collider other) //special method for MonoBehaviours called OnTriggerEnter.
    {
        //ensure that the ending is only triggered when JohnLemon hits the Box Collider
        if (other.gameObject == player && keys.HasAllKeys())
        {
            m_IsPlayerAtExit = true;
        }
    }

    // Update is getting called every frame, and checking whether the player’s character is at the exit. 
    void Update ()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel (exitBackgroundImageCanvasGroup, true, exitAudio);
        }
        else if(player.GetComponent<Player>().isDead())
        {
            EndLevel (caughtBackgroundImageCanvasGroup, false, caughtAudio);
        }
    }

    void EndLevel (CanvasGroup imageCanvasGroup, bool finishedLevel, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed) // if the audio has not yet played, play it.
        {
            audioSource.Play(); //play the audio
            m_HasAudioPlayed = true; //set the bool to true, so that the audio doesn't play again.
        }

        m_Timer += Time.deltaTime; //increment the timer by the time that has passed since the last frame.
        imageCanvasGroup.alpha = m_Timer / fadeDuration; // The Alpha value should be 0 when the timer is 0 and 1 when the timer is up to the fadeDuration.

        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (finishedLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
