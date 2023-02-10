using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject backgroundBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FinalDialogue());
    }

    private IEnumerator FinalDialogue()
    {
        yield return new WaitForSeconds(3f);
        dialogueBox.SetActive(true);
        backgroundBox.SetActive(true);
    }
}
