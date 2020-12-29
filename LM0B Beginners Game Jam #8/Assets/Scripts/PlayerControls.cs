using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Transform transformRef;
    [SerializeField]
    Rigidbody rigidbodyRef;

    private void Awake()
    {
        transformRef = transform;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0.0f)
        {
            rigidbodyRef.MovePosition(new Vector3(transformRef.position.x + (0.1f * Input.GetAxis("Horizontal")), 0.0f, 0.0f));
        }
    }
}
