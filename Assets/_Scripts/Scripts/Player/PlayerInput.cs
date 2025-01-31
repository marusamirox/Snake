﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    private bool _isDragging;
    private Vector3 _dragStartPosition;
    private Vector3 _movementDirection;

    private bool _resetActive;

    private const float InputSensMultiplier = 2;
    
    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
            _movementDirection = Vector3.zero;
        if (Input.GetAxis("Horizontal") != 0)
        {
            _movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _dragStartPosition = Input.mousePosition;
            _movementDirection = Vector3.zero;
        }
        
        if (Input.GetMouseButton(0) && _isDragging)
        {
            if (_resetActive)
                return;
            float dragDelta = Input.mousePosition.x - _dragStartPosition.x;
            _movementDirection = new Vector3(dragDelta * InputSensMultiplier, 0f, 0f);
            // _dragStartPosition.x = Mathf.Lerp(_dragStartPosition.x, Input.mousePosition.x, 3f * Time.deltaTime);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            _resetActive = false;
        }
        
    }
    public float GetXDirection()
    {
        float targetXPosition = _movementDirection.x;
        if (targetXPosition >= -1.5f && targetXPosition <= 1.5f)
            return targetXPosition;
        var targetXPositionClamped = Mathf.Clamp(targetXPosition / Screen.width, -1.5f, 1.5f);
        return targetXPositionClamped;
    }

    public void Reset()
    {
        _movementDirection = Vector3.zero;
        _resetActive = true;
    }
    
    public void ResetDrag()
    {
        _movementDirection = Vector3.zero;
        _dragStartPosition = Input.mousePosition;
    }
}
