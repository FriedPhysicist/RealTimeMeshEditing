using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer : MonoBehaviour
{
    public GameObject Sprite;
    public bool on_off=false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mesh_.current_pos;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            on_off = true; 
        } 
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            on_off = false;
        }

        while (on_off)
        {
            GameObject some = Instantiate(Sprite, transform.position, Quaternion.identity);
            break;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("spray") && !on_off)
        { 
            Destroy(other.gameObject,0);
        }
    }
}
