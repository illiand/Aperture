using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstDoorTrigger : MonoBehaviour
{
    public Canvas canvas;
    public Button buttonNo;
    public Button buttonYes;
    public GameObject inputField;

    private bool isIn = false;

    public GameObject player;

    public GameObject door;

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

          if(inputField.GetComponent<TMP_InputField>().text == "TODO")
          {
            door.GetComponent<DoorController>().openDoor();
            Destroy(this);
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
