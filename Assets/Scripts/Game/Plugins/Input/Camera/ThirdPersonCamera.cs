using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : CameraController
{
    public override Vector3 lookDirection => orientationTransform.forward;
    public override Vector3 abilityDirection => orientationTransform.forward;

    [SerializeField] private Camera orbitCamera;
    [SerializeField] private Transform orientationTransform;
    [SerializeField] private Transform positionTransform;

    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private Vector2 verticalAngleLimits;

    private IPositionProvider positionProvider;


    void LateUpdate()
    {
        if (positionProvider == null)
            return;

        // Debug.Log($"Camera position {positionTransform.position}, target {positionProvider.value}");
        positionTransform.position = positionProvider.value;
    }


    public override void Follow(IPositionProvider positionProvider)
    {
        this.positionProvider = positionProvider;
    }


    public override void Turn(Vector2 cameraInput)
    {
        if (positionProvider == null)
            return;

        var horizontalAngle = GetHorizontalAngle(cameraInput.x);
        var verticalAngle = GetVerticalAngle(-cameraInput.y);

        orientationTransform.eulerAngles = new Vector3(verticalAngle, horizontalAngle);
    }

    public override void SetDirection(Vector3 direction)
    {
        orientationTransform.forward = direction;
    }



    private float GetHorizontalAngle(float input)
    {
        return orientationTransform.eulerAngles.y + input * sensitivity.x;
    }

    private float GetVerticalAngle(float input)
    {
        var verticalAngle = GetAngleNormalized(orientationTransform.eulerAngles.x);

        if (IsAllowedToMove(verticalAngle, input))
            return Mathf.Clamp(verticalAngle + input * sensitivity.y, verticalAngleLimits.x, verticalAngleLimits.y);

        return verticalAngle;
    }


    private bool IsAllowedToMove(float verticalAngle, float verticalInput)
    {
        if (verticalInput > 0)
            return verticalAngle < verticalAngleLimits.y;

        if (verticalInput < 0)
            return verticalAngle > verticalAngleLimits.x;

        return false;
    }

    /// <summary>
    /// Transforms vertical angle from camera euler form to deviation from forward
    /// </summary>
    /// <param name="rawAngle">Vertical camera angle</param>
    private float GetAngleNormalized(float rawAngle)
    {
        if (rawAngle > 180)
            return rawAngle - 360;

        return rawAngle;
    }
}