using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The following class was written with inspiration from the online tutorial found here: https://www.youtube.com/watch?v=PVtf3vg8BXw

public class CarryRigidbodySensor : MonoBehaviour
{
    [HideInInspector] public CarryRigidbody carrier;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp != null)
            if (temp != carrier.rigidbodyRef)
                carrier.Add(temp);
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody temp = other.GetComponent<Rigidbody>();
        if (temp != null)
            if (temp != carrier.rigidbodyRef)
                carrier.Remove(temp);
    }
}
