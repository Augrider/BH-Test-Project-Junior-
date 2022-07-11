using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPresenter : MonoBehaviour, IInput
{
    public GameInput gameInput { get; private set; }
    public event Action<GameInput> OnInputChanged;

    [SerializeField] private InputReceiver inputReceiver;
    [SerializeField] private CameraController cameraController;


    void Start()
    {
        InputLocator.Provide(this);
        inputReceiver.OnInputChanged += UpdateGameInput;
    }

    void OnDestroy()
    {
        InputLocator.Provide(null);
        inputReceiver.OnInputChanged -= UpdateGameInput;
    }


    void LateUpdate()
    {
        cameraController.Turn(inputReceiver.cameraMovement);
    }


    public void CameraFollowObject(IPositionProvider positionProvider)
    {
        cameraController.Follow(positionProvider);
    }

    public void CameraFollowObject(IPositionProvider positionProvider, Vector3 direction)
    {
        CameraFollowObject(positionProvider);
        cameraController.SetDirection(direction);
    }



    private void UpdateGameInput()
    {
        var result = new GameInput();

        result.movement = inputReceiver.movementDirection;
        result.useAbility = inputReceiver.useAbility;

        result.lookDirection = cameraController.lookDirection;
        result.abilityDirection = cameraController.abilityDirection;

        this.gameInput = result;
        OnInputChanged?.Invoke(gameInput);
    }
}
