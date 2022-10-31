using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactSudo : MonoBehaviour
{
    [Header("Sudoku Interaction Part")]
    public GameObject SudokuBoard;
    public GameObject SudokuBoard2;


    void Awake()
    {
        SudokuBoard.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SudokuBoard.SetActive(true);
                SudokuBoard2.SetActive(false);
            }
        }
    }
}
