using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Camera cam;
    private Vector3 dragOrigin;
    [SerializeField] private GameObject windowCanvas;
    float speed = 4f;
    // int[] limitX;
    // int[] limitY;
    //float camSize;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        MoveCamera();
        //camSize = cam.orthographicSize;
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

    void MoveCamera()
    {
        // if(transform.position.x >= 5.4)
        // {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
            }
        // }
        // else
        // {
        //     if(transform.position.x < 5.4)
        //         transform.position = new Vector3(5.4f, transform.position.y, transform.position.z);
        // }
        // if(transform.position.y <= -2.0)
        // {
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
            }            
        // }
        // else
        // {
        //     if(transform.position.y > -2.0)
        //         transform.position = new Vector3(transform.position.x, -2.0f, transform.position.z);
        // }

    }
}
