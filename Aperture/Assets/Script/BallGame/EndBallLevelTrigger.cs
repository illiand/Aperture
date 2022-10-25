using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndBallLevelTrigger : MonoBehaviour
{
    public Canvas canvas;
    public GameObject ballController;
    public GameObject player;

    public Button returnButton;

    // Start is called before the first frame update
    void Start()
    {
      returnButton.onClick.AddListener(
        delegate
        {
          canvas.gameObject.SetActive(false);
          player.GetComponent<HomePlayerController>().canMove = true;
        }
      );
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
          canvas.gameObject.SetActive(true);
          ballController.GetComponent<BallController>().canMove = false;

          GetComponents<AudioSource>()[0].Play();
        }
    }
}
