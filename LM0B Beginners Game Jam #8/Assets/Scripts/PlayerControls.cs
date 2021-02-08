using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Transform transformRef;
    Camera cameraRef = null;
    [SerializeField]
    CharacterController characterControllerRef = null;

    static float TouchHorizontalAxis = 0.0f;
    static float t = 0.0f;
    float gravity = 3.0f;
    float sensitivity = 3.0f;


    private void Awake()
    {
        transformRef = transform;
        cameraRef = Camera.main;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        UpdateTouchHorizontalAxis();

        if (TouchHorizontalAxis != 0.0f && GameData.GameOn)
        {
            //rigidbodyRef.MovePosition(new Vector3(transformRef.position.x + (0.1f * Input.GetAxis("Horizontal")), 0.0f, 0.0f));
            characterControllerRef.Move(new Vector3(0.1f * TouchHorizontalAxis, 0.0f, 0.0f));
            //print(TouchHorizontalAxis);
        }
    }

    void UpdateTouchHorizontalAxis()
    {
        if (Input.touchCount > 0)
        {
            t = Mathf.Min(t + 0.05f * sensitivity, 1.0f);

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Ended)
                t = 0.0f;

            Vector3 correctedPosition = touch.position;

            correctedPosition.z = cameraRef.nearClipPlane;

            correctedPosition = cameraRef.ScreenToWorldPoint(correctedPosition);

            if (correctedPosition.x > 0.0f)
                TouchHorizontalAxis = Mathf.Lerp(0.0f, 1.0f, t);

            if (correctedPosition.x < 0.0f)
                TouchHorizontalAxis = Mathf.Lerp(0.0f, -1.0f, t);
        }
        else
        {
            t = Mathf.Max(t - 0.05f * gravity, 0.0f);
            TouchHorizontalAxis = Mathf.Lerp(0.0f, TouchHorizontalAxis, t);
        }
    }

    public static float GetTouchHorizontalAxis()
    {
        return TouchHorizontalAxis;
    }
}
