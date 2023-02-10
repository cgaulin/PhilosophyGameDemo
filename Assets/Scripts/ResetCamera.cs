using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    private void Awake()
    {
        transform.position = Vector3.zero;
    }
}
