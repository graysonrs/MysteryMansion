using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    public float floatSpeed = 2f; // adjust the speed of the float
    public float rotateSpeed = 30f; // adjust the speed of the rotation
    public Transform waypoint; // assign the list of checkpoints to this variable in the inspector
    public GameObject player;
    public AudioSource keyPickUp;

    private bool hasKey = false;

    private void Start()
    {
        transform.position = waypoint.position;
        keyPickUp.playOnAwake = false;
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1f)
        {
            Debug.Log("Got the Key!!!!!!!");
            Destroy(gameObject);
            keyPickUp.Play(); //play the audio
            hasKey = true;
        }
    }

    private void FixedUpdate()
    {
        // Rotate the key object around the Y-axis
        transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.fixedDeltaTime);

        // Float the key object up and down along the Y-axis
        float newY = Mathf.Sin(Time.time * floatSpeed) * 0.2f; // adjust the amplitude of the float
        transform.position = new Vector3(transform.position.x, newY + 0.5f, transform.position.z); // adjust the initial height of the float
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
