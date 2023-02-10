using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnicornHelper : MonoBehaviour
{
    [SerializeField] GameObject playerHead;
    [SerializeField] GameObject unicornHead;
    [SerializeField] GameObject unicorn;
    private int index;
    private NextDialogue dialogue;
    private bool exit = false;
    private bool exitUnicorn = false;
    public SpriteRenderer sprite;

    private void Start()
    {
        dialogue = GetComponent<NextDialogue>();
    }

    private void Update()
    {
        index = dialogue.index;
        ToggleHeads();
        if (index == 71)
        {
            exit = true;
        }
        if (exit)
        {
            StartCoroutine(FinishFade());
        }
        if (exitUnicorn)
        {
            unicorn.SetActive(false);
        }
    }

    private void ToggleHeads()
    {
        if (index == 0)
        {
            UnicornSpeaks();
        }
        else if (index == 1)
        {
            PlayerSpeaks();
        }
        else if (index == 5)
        {
            UnicornSpeaks();
        }
        else if (index == 9)
        {
            PlayerSpeaks();
        }
        else if (index == 12)
        {
            UnicornSpeaks();
        }
        else if (index == 13)
        {
            PlayerSpeaks();
        }
        else if (index == 21)
        {
            UnicornSpeaks();
        }
        else if (index == 49)
        {
            PlayerSpeaks();
        }
        else if (index == 61)
        {
            UnicornSpeaks();
        }
        else if (index == 68)
        {
            PlayerSpeaks();
        }
        else if (index == 69)
        {
            UnicornSpeaks();
        }
        else if (index == 70)
        {
            PlayerSpeaks();
        }
        else if (index == 71)
        {
            UnicornSpeaks();
        }
    }

    private void UnicornSpeaks()
    {
        playerHead.SetActive(false);
        unicornHead.SetActive(true);
    }

    private void PlayerSpeaks()
    {
        playerHead.SetActive(true);
        unicornHead.SetActive(false);
    }

    IEnumerator Fade()
    {
        Color c = sprite.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.2f)
        {
            c.a = alpha;
            sprite.color = c;
            yield return null;
        }
    }

    private IEnumerator FinishFade()
    {
        StartCoroutine(Fade());
        yield return new WaitForSeconds(0.75f);
        exitUnicorn = true;
    }
}
