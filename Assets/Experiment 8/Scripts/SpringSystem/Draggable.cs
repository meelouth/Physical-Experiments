﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Draggable : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZPos;

    [SerializeField] private Transform dragabbleTransform;

    private Camera mainCamera;

    private Vector3 position;

    private void Start()
    {
        mainCamera = Camera.main;

        SetTarget();
    }

    private void SetTarget()
    {
        if (!dragabbleTransform)
            dragabbleTransform = transform;
    }

    private void OnMouseDown()
    {
        position = dragabbleTransform.position;

        mouseZPos = mainCamera.WorldToScreenPoint(position).z;

        mouseOffset = position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mouseZPos;

        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        dragabbleTransform.position = GetMouseWorldPos() + mouseOffset;
    }

    public float GetDistanceFromClick()
    {
        return position.x - GetMouseWorldPos().x;
    }
}