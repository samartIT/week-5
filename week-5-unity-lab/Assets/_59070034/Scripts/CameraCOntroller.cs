using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCOntroller : MonoBehaviour
{
    Camera cameraTopView;
    public Camera cameraFPSView;

    // Start is called before the first frame update
    void Start()
    {
        cameraTopView = Camera.main;
        cameraTopView.enabled = true;
        cameraFPSView.enabled = true;
        
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
