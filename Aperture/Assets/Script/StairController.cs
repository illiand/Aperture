using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    public GameObject stair;

    private ArrayList stairs = new ArrayList();
    private ArrayList pos = new ArrayList();
    private ArrayList targetPos = new ArrayList();
    private ArrayList rotation = new ArrayList();
    private ArrayList targetRotation = new ArrayList();
    private ArrayList time = new ArrayList();
    private ArrayList targetTime = new ArrayList();

    public bool animating;
    private float sysTime = 0;

    private float frequency = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
      for(int i = 1; i <= 150; i += 1)
      {
        GameObject stairCopy = Object.Instantiate(stair);

        stairCopy.transform.localEulerAngles = new Vector3(
          stair.transform.localEulerAngles.x,
          stair.transform.localEulerAngles.y,
          stair.transform.localEulerAngles.z
        );

        stairs.Add(stairCopy);
        pos.Add(new Vector3(stair.transform.position.x, stair.transform.position.y + (i - 1) * 0.08f, stair.transform.position.z));
        targetPos.Add(new Vector3(stair.transform.position.x, stair.transform.position.y + i * 0.08f, stair.transform.position.z));
        rotation.Add(new Vector3(stair.transform.localEulerAngles.x, stair.transform.localEulerAngles.y + (i - 1) * 10, stair.transform.localEulerAngles.z));
        targetRotation.Add(new Vector3(stair.transform.localEulerAngles.x, stair.transform.localEulerAngles.y + i * 10, stair.transform.localEulerAngles.z));
        time.Add(0.0f);
        targetTime.Add(frequency);
      }
      animating = true;

    }

    // Update is called once per frame
    void Update()
    {
      if (animating)
      {
        for(int i = 0; i < 150; i += 1)
        {
          if(sysTime < (i + 1) * frequency)
          {
            continue;
          }

          GameObject curStair = (GameObject)stairs[i];

          Vector3 posV = (Vector3) pos[i];
          Vector3 targetPosV = (Vector3) targetPos[i];
          Vector3 rotationV = (Vector3) rotation[i];
          Vector3 targetRotationV = (Vector3) targetRotation[i];
          float timeV = (float) time[i];
          float targetTimeV = (float) targetTime[i];

          if(timeV > targetTimeV)
          {
            continue;
          }

          curStair.transform.position = new Vector3(stair.transform.position.x, Mathf.Lerp(posV.y, targetPosV.y, timeV / targetTimeV), stair.transform.position.z);
          curStair.transform.localEulerAngles = new Vector3(stair.transform.localEulerAngles.x, Mathf.Lerp(rotationV.y, targetRotationV.y, timeV / targetTimeV), stair.transform.localEulerAngles.z);

          time[i] = (float) time[i] + Time.deltaTime;
        }

        if(pos.Count == 0)
        {
          animating = false;
        }

        sysTime += Time.deltaTime;
      }
    }
    // void Start()
    // {
    //   for(int i = 0; i <= 150; i += 1)
    //   {
    //     GameObject stairCopy = Object.Instantiate(stair);
    //
    //     stairCopy.transform.localEulerAngles = new Vector3(
    //       stair.transform.localEulerAngles.x,
    //       stair.transform.localEulerAngles.y + i * 10,
    //       stair.transform.localEulerAngles.z
    //     );
    //
    //     stairs.Add(stairCopy);
    //   }
    //
    //   animating = true;
    //
    // }
    // void Update()
    // {
    //   if (animating)
    //   {
    //     for(int i = 1; i < 150; i += 1)
    //     {
    //       if(time < i * 0.25f)
    //       {
    //         continue;
    //       }
    //
    //       GameObject curStair = (GameObject)stairs[i - 1];
    //
    //       curStair.transform.position = new Vector3(
    //         stair.transform.position.x,
    //         Mathf.Lerp(stair.transform.position.y, stair.transform.position.y + 0.08f * i, (time - i * 0.25f) / (i * 0.08f)),
    //         stair.transform.position.z
    //       );
    //
    //     }
    //
    //     if(time > 149 * 0.08f + 149 * 0.25f)
    //     {
    //       animating = false;
    //     }
    //
    //     time += Time.deltaTime;
    //   }
    // }
}
