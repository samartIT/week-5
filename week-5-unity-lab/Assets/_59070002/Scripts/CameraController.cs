using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    Camera cameraTopView;
    public Camera cameraFPSView;
    void Start()
    {
        cameraTopView = Camera.main;
        cameraTopView.enabled = true;
        cameraFPSView.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            cameraTopView.enabled = !cameraTopView.enabled;
            cameraFPSView.enabled = !cameraFPSView.enabled;
        }
    }
}
