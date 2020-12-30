using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorManager : MonoBehaviour
{
    Transform transformRef = null;
    public List<GameObject> sensors = new List<GameObject>();

    private void Awake()
    {
        transformRef = transform;
    }

    private void Start()
    {

    }

    void LateUpdate()
    {
        if (Vector3.Dot(transformRef.up, Vector3.up) > 0.75f)
            sensors[0].SetActive(true);
        else
            sensors[0].SetActive(false);

        if (Vector3.Dot(-transformRef.up, Vector3.up) > 0.75f)
            sensors[1].SetActive(true);
        else
            sensors[1].SetActive(false);

        if (Vector3.Dot(-transformRef.right, Vector3.up) > 0.75f)
            sensors[2].SetActive(true);
        else
            sensors[2].SetActive(false);

        if (Vector3.Dot(transformRef.right, Vector3.up) > 0.75f)
            sensors[3].SetActive(true);
        else
            sensors[3].SetActive(false);
    }
}
