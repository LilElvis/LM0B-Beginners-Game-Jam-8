using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReaction : MonoBehaviour
{
    Transform transformRef = null;
    Rigidbody rigidbodyRef = null;
    [SerializeField]
    Material materialRef = null;
    [SerializeField]
    ParticleSystem particleSystemRef = null;
    ParticleSystem.MainModule particleSettings;
    public Transform worldSpaceParticleParent = null;

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

        particleSettings = particleSystemRef.main;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (type)
        {
            case Chemical.A:
                if(collision.gameObject.CompareTag("Chemical B"))
                {
                    CreateExplosion(collision);
                    print("A touched B.");
                }
                break;
            case Chemical.B:
                if (collision.gameObject.CompareTag("Chemical C"))
                {
                    CreateExplosion(collision);
                    print("B touched C.");
                }
                break;
            case Chemical.C:
                if (collision.gameObject.CompareTag("Chemical D"))
                {
                    CreateExplosion(collision);
                    print("C touched D.");
                }
                break;
            case Chemical.D:
                if (collision.gameObject.CompareTag("Chemical A"))
                {
                    CreateExplosion(collision);
                    print("D touched A.");
                }
                break;
            default:
                print("Chemical collision detected!");
                break;
        }
    }

    void CreateExplosion(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        particleSettings.startColor = materialRef.color;
        ParticleSystem temp = Instantiate(particleSystemRef, contact.point, Quaternion.identity);
        
        rigidbodyRef.AddExplosionForce(explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(-explosionForce, contact.point, explosionRadius, 0.0f, ForceMode.Impulse);
    }
}
