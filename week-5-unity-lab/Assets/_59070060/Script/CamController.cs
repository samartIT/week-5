using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    Camera cameraTopView;
    public Camera cameraFPSView;
    void Start()
    {
        cameraTopView = Camera.main;
        cameraTopView.enabled = true;
        cameraFPSView.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraTopView.enabled = !cameraTopView.enabled;
            cameraFPSView.enabled = !cameraFPSView.enabled;
        }
    }
}
