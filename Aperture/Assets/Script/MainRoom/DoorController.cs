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

      startPos = transform.position;
      endPos = new Vector3(transform.position.x - 0.8624f, transform.position.y, transform.position.z - 0.93f);
      startRotation = transform.eulerAngles;
      endRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);;

      Debug.Log(transform.localPosition);
      Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update()
    {
      if(inOpen)
      {
        if(count < 180)
        {
          door.transform.position = Vector3.Lerp(startPos, endPos, count / 180f);
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
      if(other.gameObject.name == "Player")
      {
        openDoor();
      }
    }

    void OnTriggerExit(Collider other)
    {

    }

    public void openDoor()
    {
      count = 0;
      inOpen = true;

      GetComponent<AudioSource>().Play();
    }
}
