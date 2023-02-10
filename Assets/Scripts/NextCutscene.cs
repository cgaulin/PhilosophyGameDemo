using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextCutscene : MonoBehaviour
{
    [SerializeField] GameObject surprisedDialogue;
    [SerializeField] GameObject backgroundBox;
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        surprisedDialogue.SetActive(true);
        backgroundBox.SetActive(true);
        player.GetComponent<Player>().speed = 0f;
    }
}
