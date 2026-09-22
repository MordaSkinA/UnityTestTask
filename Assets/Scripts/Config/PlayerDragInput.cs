using System;
using UnityEngine;

[RequireComponent(typeof(PlayerLocomotion))]
public class PlayerInput : MonoBehaviour
{

    [SerializeField] float dragSensitivity = 0.05f;

    PlayerLocomotion locomotion;
    bool isDragging;
    private bool isFirstInputSent;
    private Vector2 lastPointerPosition;

    public event Action OnFirstInput;

    private void Awake()
    {
        locomotion = GetComponent<PlayerLocomotion>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 pointerPosition;
        bool isPointerDown, isPointerUp, isPointerHeld;

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            pointerPosition = touch.position;
            isPointerDown = touch.phase == TouchPhase.Began;
            isPointerHeld = touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary;
            isPointerUp = touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;
        }
        else
        {
            isPointerDown = Input.GetMouseButtonDown(0);
            isPointerUp = Input.GetMouseButtonUp(0);
            isPointerHeld = Input.GetMouseButton(0);
            pointerPosition = Input.mousePosition;
        }

        if (isPointerDown)
        {
            isDragging = true;
            lastPointerPosition = pointerPosition;
        } else if (isPointerHeld && isDragging)
        {
            float deltaX = pointerPosition.x - lastPointerPosition.x;
            lastPointerPosition = pointerPosition;

            float dt = Time.deltaTime;
            locomotion.HorizontalInput = dt > 0f ? deltaX * dragSensitivity / dt : 0f;


            if (!isFirstInputSent)
            {
                isFirstInputSent = true;
                OnFirstInput?.Invoke();
            }
        }
        else
        {
            locomotion.HorizontalInput = 0f;
        }

        if (isPointerUp)
        {
            isDragging = false;
            locomotion.HorizontalInput = 0f;
        }

    }
}