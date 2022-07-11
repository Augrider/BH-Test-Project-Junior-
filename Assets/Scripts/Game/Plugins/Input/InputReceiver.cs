using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiver : MonoBehaviour
{
    public Vector2 movementDirection { get; private set; }
    public Vector2 cameraMovement { get; private set; }

    public bool useAbility { get; private set; }
    public bool switchCharacter { get; private set; }

    public event System.Action OnInputChanged;

    private GameControls gameControls;


    // void Awake()
    // {
    //     SubscribeInput();
    // }

    void OnEnable()
    {
        SubscribeInput();
    }

    void OnDisable()
    {
        UnsubscribeInput();
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        movementDirection = context.ReadValue<Vector2>();
        OnInputChanged?.Invoke();
    }

    public void OnCameraMovement(InputAction.CallbackContext context)
    {
        cameraMovement = context.ReadValue<Vector2>();
        OnInputChanged?.Invoke();
    }

    public void OnAbility(InputAction.CallbackContext context)
    {
        useAbility = context.ReadValue<float>() > 0.5f;
        OnInputChanged?.Invoke();
    }



    private void SubscribeInput()
    {
        if (gameControls == null)
            gameControls = new GameControls();

        gameControls.CharacterControl.Movement.started += OnMovement;
        gameControls.CharacterControl.Movement.performed += OnMovement;
        gameControls.CharacterControl.Movement.canceled += OnMovement;

        gameControls.CharacterControl.Camera.started += OnCameraMovement;
        gameControls.CharacterControl.Camera.performed += OnCameraMovement;
        gameControls.CharacterControl.Camera.canceled += OnCameraMovement;

        gameControls.CharacterControl.Ability.started += OnAbility;
        gameControls.CharacterControl.Ability.canceled += OnAbility;

        gameControls.CharacterControl.Enable();
    }

    private void UnsubscribeInput()
    {
        gameControls.CharacterControl.Movement.started -= OnMovement;
        gameControls.CharacterControl.Movement.performed -= OnMovement;
        gameControls.CharacterControl.Movement.canceled -= OnMovement;

        gameControls.CharacterControl.Camera.started -= OnCameraMovement;
        gameControls.CharacterControl.Camera.performed -= OnCameraMovement;
        gameControls.CharacterControl.Camera.canceled -= OnCameraMovement;

        gameControls.CharacterControl.Ability.started -= OnAbility;
        gameControls.CharacterControl.Ability.canceled -= OnAbility;

        gameControls.CharacterControl.Disable();
    }
}
