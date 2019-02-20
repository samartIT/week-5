﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 5.0f;
    public float sensitivityVer = 5.0f;
    public float minimumVer = -45.0f;
    public float maximumVer = 45.0f;
    private float _rotationX = 0;
    // Use this for initialization
    void Start()
    {
        
    }
    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        } else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer; // rotate around X-Axis
            _rotationX = Mathf.Clamp(_rotationX, minimumVer, maximumVer);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            // rotating around X-, Y- and Z- axes simultaneously
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer; //rotating around X-axis
            _rotationX = Mathf.Clamp(_rotationX, minimumVer, maximumVer);

            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        void Start ()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if(body != null)
            {
                body.freezeRotation = true;
            }
        }
    }
}

