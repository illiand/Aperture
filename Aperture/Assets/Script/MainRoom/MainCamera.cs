using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject character;

    private float x = 0;
    private float y = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
      if(!character.GetComponent<PlayerController>().canMove) return;

      float curDegree = transform.localEulerAngles.x;

      transform.position = character.transform.position;
      transform.localEulerAngles = character.transform.localEulerAngles;
      x -= Input.GetAxis("Mouse Y") * 1.25f;
      x = Mathf.Clamp(x, -30, 40);
      y += Input.GetAxis("Mouse X") * 1.25f;

      transform.localEulerAngles = new Vector3(x, y, 0);
      character.transform.localEulerAngles = new Vector3(0, y, 0);
      transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 1f, character.transform.position.z);
    }
}
