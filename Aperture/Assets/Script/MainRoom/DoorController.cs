using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 startRotation;
    private Vector3 endRotation;
    private int count = 999999;

    public bool inOpen;
    public Collider closedCollider;

    // Start is called before the first frame update
    void Start()
    {
      inOpen = false;

      startRotation = transform.eulerAngles;
      endRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 160, transform.eulerAngles.z);;
    }

    // Update is called once per frame
    void Update()
    {
      if(inOpen)
      {
        if(count < 180)
        {
          door.transform.eulerAngles = Vector3.Lerp(startRotation, endRotation, count / 180f);

          count += 1;

          if(count == 180)
          {
            inOpen = false;
            closedCollider.enabled = false;
          }
        }
      }

    }

    void OnTriggerEnter(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {

    }

    public void openDoor()
    {
      count = 0;
      inOpen = true;
    }
}
