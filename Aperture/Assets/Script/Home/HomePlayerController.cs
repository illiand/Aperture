using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public bool canMove;

    private float timer;

    private bool sound1Played;

    public bool roomIsOut;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();

      canMove = true;
      roomIsOut = false;

      GetComponents<AudioSource>()[2].Play();
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;

      if(!canMove)
      {
        return;
      }

      float speed = 2.0f;
      float[] movingSpeed = new float[]{0, 0, 0, 0};

      if (Input.GetKey(KeyCode.W))
      {
        movingSpeed[0] = speed;
        //transform.Translate(0, 0, speed * Time.deltaTime);
      }

      if (Input.GetKey(KeyCode.S))
      {
        movingSpeed[1] = -speed;
      }

      if (Input.GetKey(KeyCode.D))
      {
        movingSpeed[2] = speed;
      }

      if (Input.GetKey(KeyCode.A))
      {
        movingSpeed[3] = -speed;
      }

      rb.velocity = transform.forward * movingSpeed[0];
      rb.velocity += transform.forward * movingSpeed[1];
      rb.velocity += transform.right * movingSpeed[2];
      rb.velocity += transform.right * movingSpeed[3];

      if(rb.velocity.x != 0 || rb.velocity.y != 0 || rb.velocity.z != 0)
      {
        if(!GetComponent<AudioSource>().isPlaying)
        {
          GetComponent<AudioSource>().Play();
        }
      }
      else
      {
        GetComponent<AudioSource>().Stop();
      }
    }
}
