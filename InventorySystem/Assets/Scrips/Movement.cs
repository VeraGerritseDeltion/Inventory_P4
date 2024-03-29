﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movSpeed;
    public float mouseSen;
    public float horizontal;
    public float vertical;
    public float vert;
    public float movVert;
    public float movHor;
    public float upDownRange;
    //public Camera cam;
    public Rigidbody player;

    private void Start()
    {
    }
    void Update()
    {
        MovementChar();
    }

    public void MovementChar()
    {   
        horizontal = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        vertical = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;
        movVert = Input.GetAxis("Vertical") * movSpeed * Time.deltaTime;
        movHor = Input.GetAxis("Horizontal") * movSpeed * Time.deltaTime;
        transform.Translate(new Vector3(movHor, 0, movVert) );
        transform.Rotate(0, horizontal, 0);
        vert -= vertical;
        vert = Mathf.Clamp(vert, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(vert, 0, 0);
    }
}
