using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ball;
    public Camera camera;

    public bool canMove;

    private float factor = 573.887f * 0.082f * 0.02f;

    // Start is called before the first frame update
    void Start()
    {
      canMove = false;
      ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
      ball.GetComponent<Rigidbody>().AddForce(Physics.gravity * 0.082f * 0.1f);

      if(Input.GetMouseButtonDown(0))
      {
        Vector3 screenPos = camera.WorldToScreenPoint(ball.transform.position);
        Vector3 mousePos = Input.mousePosition;

        Ray ray = camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
          if (hit.collider != null && hit.collider.gameObject.name == "Ball")
          {
              // if(mousePos.x - screenPos.x < 0)
              // {
              //   ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, factor, -factor));
              // }
              // else
              // {
              //   ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, factor, factor));
              // }

              Vector3 force = new Vector3(0, factor * Mathf.Abs((mousePos.y - screenPos.y)), (mousePos.x - screenPos.x) / 10f * factor);
              ball.GetComponent<Rigidbody>().AddForce(force);

              Debug.Log((mousePos.y + " : " + screenPos.y));
          }
        }
      }
    }
}
