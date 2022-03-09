using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ConfinerZone : MonoBehaviour
{
    [SerializeField] private new CinemachineVirtualCamera camera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camera.gameObject.SetActive(true);
            Debug.Log("He entrado a la zona");
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            camera.gameObject.SetActive(false);
            Debug.Log("He salido de la zona");
        }
    }
    
}