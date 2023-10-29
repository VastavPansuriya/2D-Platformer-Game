using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator doorAnimation;

    private void Start()
    {
        doorAnimation = GetComponent<Animator>();
        doorAnimation.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            doorAnimation.enabled = true;
        }       
    }
}
