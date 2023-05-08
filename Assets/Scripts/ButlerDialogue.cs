using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class ButlerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;  // The canvas that displays the dialogue
    public GameObject cluePanel;  // The canvas that displays the dialogue
    public GameObject interactionPanel;
    public GameObject player;

    private NavMeshAgent agent;
    private bool isPlayerNearby = false;  // Whether the player is nearby the NPC
    private bool playerTalked = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        interactionPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    void Update()
    {
        // Check if the player is nearby and presses the interaction key
        if (isPlayerNearby && !dialoguePanel.activeSelf) {
            interactionPanel.SetActive(true);
        }
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.F))
        {
            playerTalked = true;
            interactionPanel.SetActive(false);
            // Show the dialogue canvas
            dialoguePanel.SetActive(true);
        }
        // if (!isPlayerNearby && !playerTalked) {
        //     cluePanel.SetActive(false);
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the NPC's trigger zone
        if (other.gameObject == player)
        {
            // Set isPlayerNearby to true
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the NPC's trigger zone
        if (other.gameObject == player)
        {
            // Set isPlayerNearby to false
            isPlayerNearby = false;

            // Hide the dialogue canvas
            interactionPanel.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }
}
