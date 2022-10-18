using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StairSymbolTrigger : MonoBehaviour
{
  public Canvas canvas;
  public Button buttonNo;
  public Button buttonYes;
  public GameObject inputField;

  private bool isIn = false;

  public GameObject player;

  public GameObject stair;
  public GameObject stairCollider;

  // Start is called before the first frame update
  void Start()
  {
    canvas.gameObject.SetActive(false);

    buttonNo.onClick.AddListener(
      delegate
      {
        canvas.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().canMove = true;
      }
    );

    buttonYes.onClick.AddListener(
      delegate
      {
        canvas.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().canMove = true;

        if(inputField.GetComponent<TMP_InputField>().text == "3987")
        {
          stair.GetComponent<StairController>().animating = true;
          stairCollider.gameObject.SetActive(true);

          Destroy(gameObject);
        }
      }
    );
  }

  // Update is called once per frame
  void Update()
  {
    if (isIn && Input.GetKey(KeyCode.F))
    {
      canvas.gameObject.SetActive(true);

      player.GetComponent<PlayerController>().canMove = false;
    }
  }

  void OnTriggerEnter(Collider other)
  {
      if(other.gameObject.name == "Player")
      {
        isIn = true;
      }
  }

  void OnTriggerExit(Collider other)
  {
      if(other.gameObject.name == "Player")
      {
        isIn = false;
      }
  }
}
