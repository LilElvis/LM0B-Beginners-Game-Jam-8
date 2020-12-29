using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReaction : MonoBehaviour
{
    Transform transformRef = null;
    Rigidbody rigidbodyRef = null;

    enum Chemical
    {
        A,
        B,
        C,
        D
    }

    [SerializeField]
    Chemical type;

    float explosionForce = 25.0f;
    float explosionRadius = 5.0f;

    private void Awake()
    {
        transformRef = transform;
        rigidbodyRef = transformRef.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (type)
        {
            case Chemical.A:
                if(collision.gameObject.CompareTag("Chemical B"))
                {
                    ContactPoint contact = collision.contacts[0];
                    rigidbodyRef.AddExplosionForce(explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(-explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    print("A touched B.");
                }
                break;
            case Chemical.B:
                if (collision.gameObject.CompareTag("Chemical C"))
                {
                    ContactPoint contact = collision.contacts[0];
                    rigidbodyRef.AddExplosionForce(explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(-explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    print("B touched C.");
                }
                break;
            case Chemical.C:
                if (collision.gameObject.CompareTag("Chemical D"))
                {
                    ContactPoint contact = collision.contacts[0];
                    rigidbodyRef.AddExplosionForce(explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(-explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    print("C touched D.");
                }
                break;
            case Chemical.D:
                if (collision.gameObject.CompareTag("Chemical A"))
                {
                    ContactPoint contact = collision.contacts[0];
                    rigidbodyRef.AddExplosionForce(explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(-explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
                    print("D touched A.");
                }
                break;
            default:
                print("Chemical collision detected!");
                break;
        }
    }
}
