using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    public GameObject ballController;

    private bool isIn;

    private float timer;
    private bool hasInteracted;
    private bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(!hasInteracted)
      {
        timer += Time.deltaTime;

        if(!hasPlayed && timer > 120)
        {
          GetComponents<AudioSource>()[0].Play();
          hasPlayed = true;
        }
      }

      if(isIn && Input.GetKey(KeyCode.F))
      {
        player.GetComponent<HomePlayerController>().canMove = false;
        camera.transform.position = new Vector3(-51.089f, 5.631f, 40.106f);
        camera.transform.localEulerAngles = new Vector3(0f, 180f, 0f);

        ballController.GetComponent<BallController>().canMove = true;

        hasInteracted = true;
      }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
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
