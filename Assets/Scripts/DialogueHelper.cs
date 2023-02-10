using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHelper : MonoBehaviour
{
    [SerializeField] GameObject head;
    private int index;
    private Dialogue dialogue;

    private void Start()
    {
        dialogue = GetComponent<Dialogue>();
    }

    private void Update()
    {
        index = dialogue.index;
    }

    public void ToggleHead()
    {
        if (index == 2)
        {
            head.SetActive(false);
        }
        else if (index == 3)
        {
            head.SetActive(true);
        }
        else if (index == 6)
        {
            head.SetActive(false);
        }
        else if (index == 19)
        {
            head.SetActive(true);
        }
    }
}
