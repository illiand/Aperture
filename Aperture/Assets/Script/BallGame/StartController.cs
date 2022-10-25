using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    public GameObject ballController;

    private bool isIn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(isIn && Input.GetKey(KeyCode.F))
      {
        player.GetComponent<PlayerController>().canMove = false;
        camera.transform.position = new Vector3(-13.22f, 0.79f, 32.47f);
        camera.transform.localEulerAngles = new Vector3(0f, 90f, 0f);

        ballController.GetComponent<BallController>().canMove = true;
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
