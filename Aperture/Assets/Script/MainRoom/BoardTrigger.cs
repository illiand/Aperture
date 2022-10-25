using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTrigger : MonoBehaviour
{
    private float timer;
    private bool isIn;

    private bool hasPlayed1;
    private bool hasPlayed2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(isIn)
      {
        timer += Time.deltaTime;

        if(timer > 60 && hasPlayed2)
        {
          GetComponents<AudioSource>()[1].Play();
          hasPlayed2 = true;
        }
      }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player" && !hasPlayed1)
        {
          GetComponents<AudioSource>()[0].Play();
          hasPlayed1 = true;

          isIn = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
          isIn = false;
        }
    }
}
