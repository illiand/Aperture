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

    // Start is called before the first frame update
    void Start()
    {
      canvas.gameObject.SetActive(false);
      buttonNo.onClick.AddListener(
        delegate
        {

        }
      );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
