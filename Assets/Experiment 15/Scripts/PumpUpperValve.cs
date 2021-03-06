﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public class PumpUpperValve : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private PumpHandle _pumpHandle;
    [SerializeField] private Vector3 _upperPosition;
    [SerializeField] private Vector3 _lowerPosition;

    private void OnEnable()
    {
        _pumpHandle.onHandDown += MoveUp;
        _pumpHandle.onHandUp += MoveDown;
    }

    private void OnDisable()
    {
        _pumpHandle.onHandDown -= MoveUp;
        _pumpHandle.onHandUp -= MoveDown;
    }

    private void MoveUp(float percent)
    {
        Vector3 direction = (_upperPosition - _lowerPosition).normalized;
        float distance = Vector3.Distance(_upperPosition, _lowerPosition);
        _transform.localPosition = _lowerPosition + direction * (distance * percent);
    }
    
    private void MoveDown(float percent)
    {
        _transform.localPosition = _lowerPosition;
    }
}
