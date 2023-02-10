using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{
    [SerializeField] Cutscenes cutscenes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if(cutscenes.completed)
        {
            SceneManager.LoadScene(2);
        }
    }
}
