using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKeys : MonoBehaviour
{
    private KeyController[] keys;
    private bool hasAllKey = false;

    private void Start()
    {
        keys = GetComponentsInChildren<KeyController>();
    }

    // Update is called once per frame
    private void Update()
    {
        hasAllKey = true;
        foreach(var key in keys) {
            if (!(key.HasKey())) {
                hasAllKey = false;
                break;
            }
        }
        if (hasAllKey) {
            Debug.Log("Has All the Keys!!!!!!!!!!!!!!!!!!");
        }
    }

    public bool HasAllKeys() {
        return hasAllKey;
    }
}
