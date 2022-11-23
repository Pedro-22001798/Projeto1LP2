using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Camera cam;
    private Vector3 dragOrigin;
    [SerializeField] private GameObject windowCanvas;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        PanCamera();
    }

    void PanCamera()
    {
        if(!windowCanvas.active)
        {
            if(Input.GetMouseButtonDown(0))
            {
                dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
            }

            if(Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

                cam.transform.position += difference;
            }
        }
    }
}
