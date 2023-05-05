using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicUIText : MonoBehaviour
{
    public GameObject KeyCount;
    public GameObject LivesCount;
    public CheckKeys keys;
    public Player player;

    TextMeshProUGUI keyText;
    TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        keyText = KeyCount.GetComponent<TextMeshProUGUI>();
        livesText = LivesCount.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = "" + keys.keyCount();
        livesText.text = "" + player.GetLives();
    }
}
