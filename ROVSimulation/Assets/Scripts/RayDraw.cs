using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayDraw : MonoBehaviour
{
    [SerializeField] private bool debug;
    [SerializeField] private float time;
    [SerializeField] private float distance;

    private void Update()
    {
        if(enabled)
        {
            Debug.DrawRay(transform.position, transform.forward * distance, new Color(255, 0, 0, 10), time);
        }
    }
}


