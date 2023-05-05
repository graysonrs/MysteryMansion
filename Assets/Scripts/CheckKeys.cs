using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeys : MonoBehaviour
{
    private KeyController[] keys;
    private bool hasAllKey = false;
    private int keyLeft;

    private void Start()
    {
        keys = GetComponentsInChildren<KeyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        hasAllKey = true;
        keyLeft = 0;
        foreach(var key in keys) {
            if (!(key.HasKey())) {
                hasAllKey = false;
                keyLeft++;
            }
        }
        if (hasAllKey) {
            Debug.Log("Has All the Keys!!!!!!!!!!!!!!!!!!");
        }
    }

    public bool HasAllKeys() {
        return hasAllKey;
    }

    public int keyCount() {
        return keyLeft;
    }
}
