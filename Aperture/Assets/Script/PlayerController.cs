using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      float speed = 2.0f;
      float[] movingSpeed = new float[]{0, 0, 0, 0};

      if (Input.GetKey(KeyCode.W))
      {
        movingSpeed[0] = speed;
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
    }
}
