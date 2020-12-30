using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Transform transformRef;

    Vector3 defaultPos;
    Quaternion leftTilt;
    Quaternion rightTilt;

    private void Awake()
    {
        transformRef = transform;

        defaultPos = transformRef.position;
        leftTilt = new Quaternion(0.0f, 0.0f, 0.0436194f, 0.9990482f);
        rightTilt = new Quaternion(0.0f, 0.0f, -0.0436194f, 0.9990482f);
    }

    void Update()
    {
        float t = (Input.GetAxis("Horizontal") / 2.0f + 0.5f);
        transformRef.SetPositionAndRotation(new Vector3(transformRef.position.x, defaultPos.y, defaultPos.z), Quaternion.Lerp(leftTilt, rightTilt, t));
    }
}
