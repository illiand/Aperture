using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject ball;
    public Camera camera;

    public bool canMove;

    private float factor = 573.887f;

    // Start is called before the first frame update
    void Start()
    {
      canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
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
              Vector3 force = new Vector3((mousePos.x - screenPos.x) / 7.68f * factor, 1 * factor, 0);
              ball.GetComponent<Rigidbody>().AddForce(force);

              Debug.Log(force);
              Debug.Log((mousePos.x - screenPos.x));
          }
        }
      }
    }
}
