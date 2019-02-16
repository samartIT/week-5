﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 5.0f;
    public float sensitivityVar = 5.0f;
    public float minimumVer = -45.0f;
    public float maximumVer = 45.0f;
    private float _rotationX = 0;

    // Start is called before the first frame update
    void Start(){
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) {
            body.freezeRotation = true;
        }                
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX){
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);     
        } else if (axes == RotationAxes.MouseY){
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVar;
            _rotationX = Mathf.Clamp(_rotationX, minimumVer, maximumVer);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

        } else {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVar;
            _rotationX = Mathf.Clamp(_rotationX, minimumVer, maximumVer);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        
    }
}
