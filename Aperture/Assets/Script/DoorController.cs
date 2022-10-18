using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject up1;
    public GameObject up2;

    public GameObject down1;
    public GameObject down2;

    public Collider door;

    private Vector3 startPos1;
    private Vector3 endPos1;
    private Vector3 startPos2;
    private Vector3 endPos2;
    private int count = 999999;

    // Start is called before the first frame update
    void Start()
    {
      startPos1 = up1.transform.position;
      startPos2 = down1.transform.position;

      endPos1 = new Vector3(up1.transform.position.x, up1.transform.position.y + 1.35f, up1.transform.position.z);
      endPos2 = new Vector3(down1.transform.position.x, down1.transform.position.y - 1.35f, down1.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
      if(count < 180)
      {
        up1.transform.position = Vector3.Lerp(startPos1, endPos1, count / 180.0f);
        up2.transform.position = Vector3.Lerp(startPos1, endPos1, count / 180.0f);
        down1.transform.position = Vector3.Lerp(startPos2, endPos2, count / 180.0f);
        down2.transform.position = Vector3.Lerp(startPos2, endPos2, count / 180.0f);

        count += 1;

        if(count == 180)
        {
          Destroy(door);
        }
      }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
          count = 0;
        }
    }
}
