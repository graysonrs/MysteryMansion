using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    public float floatSpeed = 0.5f; // adjust the speed of the float
    public float rotateSpeed = 30f; // adjust the speed of the rotation
    public Transform[] waypoints; // assign the list of checkpoints to this variable in the inspector
    public GameObject player;
    public AudioSource keyPickUp;

    private bool hasKey = false;
    private Transform currentWaypoint;
    private int currentWaypointIndex = -1;

    private void Start()
    {
        NewKeyLoc();
    }

    private void Update()
    {
        if (currentWaypoint != null && Vector3.Distance(player.transform.position, transform.position) < 1f)
        {
            Debug.Log("Got the Key!!!!!!!");
            Destroy(gameObject);
            hasKey = true;
        }
    }

    private void OnDestroy()
    {
        if (hasKey)
        {
            Debug.Log("Playing key pickup audio");
            keyPickUp.Play(); //play the audio
        }
    }
    private void FixedUpdate()
    {
        if (currentWaypoint != null)
        {
            // Rotate the key object around the Y-axis
            transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.fixedDeltaTime);

            // Float the key object up and down along the Y-axis
            float newY = Mathf.Sin(Time.time * floatSpeed) * 0.2f; // adjust the amplitude of the float
            transform.position = new Vector3(transform.position.x, newY + 0.5f, transform.position.z); // adjust the initial height of the float
        }
    }

    private void NewKeyLoc()
    {
        // Pick a random waypoint to spawn the key object
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        currentWaypoint = waypoints[currentWaypointIndex];
        Debug.Log("Key location set to: " + currentWaypointIndex);

        // Set the position of the key object to the current waypoint
        transform.position = currentWaypoint.position;
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
