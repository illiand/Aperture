using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockController : MonoBehaviour
{
    public GameObject clockPinH;
    public GameObject clockPinM;
    public GameObject clockPinS;

    private float time;

    private float speed;
    // Start is called before the first frame update
    void Start()
    {
      time = Random.Range(0, 86400);
      speed = Random.Range(0.1f, 8.8f);
    }

    // Update is called once per frame
    void Update()
    {
      clockPinH.transform.localEulerAngles = new Vector3(0, 0, (time / 60f / 60f) % 12 / 12f * 360f);
      clockPinM.transform.localEulerAngles = new Vector3(0, 0, (time / 60f) % 60f / 60f * 360f);
      clockPinS.transform.localEulerAngles = new Vector3(0, 0, time % 60f / 60f * 360f);

      time += Time.deltaTime * speed;
    }
}
