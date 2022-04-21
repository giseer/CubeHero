using System.Collections;
using System.Collections.Generic;
using System;
using Cinemachine;
using UnityEngine;

public class ConfinerZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraConfiner;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraConfiner.gameObject.SetActive(true);
            Debug.Log("He entrado a la zona");
        }
        Debug.Log("No es player");
    }
     
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            cameraConfiner.gameObject.SetActive(false);
        }
    }

}