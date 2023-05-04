using UnityEngine;
using System.Collections;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueCanvas;  // The canvas that displays the dialogue
    public KeyCode interactKey = KeyCode.F;  // The key to press to interact with the NPC

    private bool isPlayerNearby = false;  // Whether the player is nearby the NPC

    void Update()
    {
        // Check if the player is nearby and presses the interaction key
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            // Show the dialogue canvas
            dialogueCanvas.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the NPC's trigger zone
        if (other.CompareTag("Player"))
        {
            // Set isPlayerNearby to true
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the NPC's trigger zone
        if (other.CompareTag("Player"))
        {
            // Set isPlayerNearby to false
            isPlayerNearby = false;

            // Hide the dialogue canvas
            dialogueCanvas.SetActive(false);
        }
    }
}
