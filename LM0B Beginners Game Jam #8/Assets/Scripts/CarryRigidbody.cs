using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The following class was written with inspiration from the online tutorial found here: https://www.youtube.com/watch?v=PVtf3vg8BXw

public class CarryRigidbody : MonoBehaviour
{
    [SerializeField]
    bool useTriggerAsSensor = true;

    Transform transformRef = null;
    [HideInInspector] public Rigidbody rigidbodyRef = null;
    Vector3 lastPosition;

    public static List<Rigidbody> rigidbodiesInfluinced = new List<Rigidbody>();
    public List<Rigidbody> rigidbodyRefs = new List<Rigidbody>();

    private void Awake()
    {
        transformRef = transform;
        rigidbodyRef = GetComponent<Rigidbody>();
    }

    void Start()
    {
        lastPosition = transformRef.position;

        if (useTriggerAsSensor)
            foreach (CarryRigidbodySensor sensor in GetComponentsInChildren<CarryRigidbodySensor>())
                sensor.carrier = this;

    }

    private void LateUpdate()
    {
        Vector3 velocity = (transformRef.position - lastPosition);

        if (rigidbodyRefs.Count > 0)
        {
            for (int i = 0; i < rigidbodyRefs.Count; i++)
            {
                Rigidbody temp = rigidbodyRefs[i];
                temp.transform.Translate(velocity, Space.World);
            }
        }

        lastPosition = transformRef.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (useTriggerAsSensor) return;

        Rigidbody temp = collision.collider.GetComponent<Rigidbody>();

        if (temp != null)
        {
            Add(temp);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (useTriggerAsSensor) return;

        Rigidbody temp = collision.collider.GetComponent<Rigidbody>();

        if (temp != null)
        {
            Remove(temp);
        }
    }

    public void Add(Rigidbody rigidbody)
    {
        if (!rigidbodiesInfluinced.Contains(rigidbody))
            if (!rigidbodyRefs.Contains(rigidbody))
            {
                rigidbodyRefs.Add(rigidbody);
                rigidbodiesInfluinced.Add(rigidbody);
            }
    }

    public void Remove(Rigidbody rigidbody)
    {
        if (rigidbodiesInfluinced.Contains(rigidbody))
            if (rigidbodyRefs.Contains(rigidbody))
            {
                rigidbodyRefs.Remove(rigidbody);
                rigidbodiesInfluinced.Remove(rigidbody);
            }
    }
}
