using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHallwaySoundTrigger : MonoBehaviour
{
    private bool lastPlayered;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
          if(!lastPlayered)
          {
            lastPlayered = true;
            GetComponents<AudioSource>()[0].Play();
          }
        }
    }
}
