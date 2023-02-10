using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDestination : MonoBehaviour
{
    [SerializeField] GameObject fadeBackground;

    private void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(TravelToWorld());
    }

    private IEnumerator TravelToWorld()
    {
        fadeBackground.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(3);
    }
}
