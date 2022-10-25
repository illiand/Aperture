using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueSoundTrigger : MonoBehaviour
{
    private bool hasPlayed;
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
        if(other.gameObject.name == "Player" && !hasPlayed)
        {
          GetComponents<AudioSource>()[6].Play();
          hasPlayed = true;
        }
    }
}
