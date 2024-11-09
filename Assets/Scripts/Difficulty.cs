using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = FindObjectOfType<GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartGame();
    }
}
