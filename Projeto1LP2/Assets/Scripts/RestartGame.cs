using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject mainConsole;
    [SerializeField] private GameObject windowCanvas;
    [SerializeField] private Program gameManager;
    [SerializeField] private TileFiller tileManager;

    public void Restart()
    {
        mainConsole.SetActive(true);
        windowCanvas.SetActive(false);
        gameManager.RestartGame();
        tileManager.RestartGame();
    }
}
