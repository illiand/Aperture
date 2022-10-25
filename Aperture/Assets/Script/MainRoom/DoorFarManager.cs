using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFarManager : MonoBehaviour
{
    public GameObject player;

    private Vector3 pos;
    private Vector3 targetPos;

    private float curTime = 999;
    private float time = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(curTime == 999) return;

      if(curTime < time)
      {
        player.transform.position = Vector3.Lerp(pos, targetPos, curTime / time);

        curTime += Time.deltaTime;
      }
      else
      {
        Destroy(gameObject);
      }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
          curTime = 0;

          pos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
          targetPos = new Vector3(player.transform.position.x + 12f, player.transform.position.y, player.transform.position.z);

          GetComponents<AudioSource>()[0].Play();
        }
    }

    // void OnTriggerExit(Collider other)
    // {
    //     if(other.gameObject.name == "Player")
    //     {
    //       isIn = false;
    //     }
    // }
}
