using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveWorld : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject blackOut;
    private int index;
    private FinalDialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GetComponent<FinalDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        index = dialogue.index;
        StartCoroutine(FinalLeave());
    }

    private IEnumerator FinalLeave()
    {
        if (index == 6)
        {
            yield return new WaitForSeconds(1f);
            background.SetActive(true);
            yield return new WaitForSeconds(5f);
            blackOut.SetActive(true);
            SceneManager.LoadScene(4);
        }
    }
}
