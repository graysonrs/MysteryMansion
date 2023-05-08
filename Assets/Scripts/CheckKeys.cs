using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeys : MonoBehaviour
{
    public GameObject exitDoor;
    private KeyController[] keys;
    private bool hasAllKey = false;
    private int keyLeft;
    private Transform firstKey;

    private void Start()
    {
        keys = GetComponentsInChildren<KeyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        hasAllKey = true;
        keyLeft = 0;
        KeyController[] reversedArray = new KeyController[keys.Length];
        Array.Copy(keys, reversedArray, keys.Length);
        Array.Reverse(reversedArray);
        foreach(var key in keys) {
            if (!(key.HasKey())) {
                hasAllKey = false;
                firstKey = key.GetLoc();
                keyLeft++;
            }
        }
        if (hasAllKey) {
            Debug.Log("Has All the Keys!!!!!!!!!!!!!!!!!!");
            Destroy(exitDoor);
        }
    }

    public bool HasAllKeys() {
        return hasAllKey;
    }

    public int keyCount() {
        return keyLeft;
    }

    public Transform GetDestination() {
        return firstKey;
    }
}
