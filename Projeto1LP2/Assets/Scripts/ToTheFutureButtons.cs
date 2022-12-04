using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTheFutureButtons : MonoBehaviour
{
    [SerializeField] private GameObject toTheFutureWindow;

    void Start()
    {
        toTheFutureWindow.SetActive(false);
    }

    public void OpenWindowToTheFuture()
    {
        toTheFutureWindow.SetActive(true);
    }

    public void CloseWindowToTheFuture()
    {
        toTheFutureWindow.SetActive(false);
    }
}
