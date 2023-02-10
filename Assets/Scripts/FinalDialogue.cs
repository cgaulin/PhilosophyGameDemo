using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public int index;
    public float textSpeed;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject backgroundBox;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float pitchMin;
    [SerializeField] float pitchMax;


    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(index == 6)
            {
                return;
            }
            else
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }

        }
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        // Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            audioSource.pitch = Random.Range(pitchMin, pitchMax);
            audioSource.Play();
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            backgroundBox.SetActive(false);
        }
    }
}
