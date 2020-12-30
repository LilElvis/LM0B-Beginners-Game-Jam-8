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
    AudioSource audioSourceRef = null;
    [SerializeField]
    ParticleSystem particleSystemRef = null;
    ParticleSystem.MainModule particleSettings;

    float textureOffsetX = 0.0f;
    float textureOffsetY = 0.0f;

    enum Chemical
    {
        A,
        B,
        C,
        D
    }

    [SerializeField]
    Chemical type;

    float explosionForce = 35.0f;
    float explosionRadius = 10.0f;
    float upwardsModifier = 0.0f;

    private void Awake()
    {
        transformRef = transform;
        rigidbodyRef = transformRef.GetComponent<Rigidbody>();

        particleSettings = particleSystemRef.main;
    }

    private void Update()
    {
        textureOffsetX = textureOffsetX += 0.0003f;
        textureOffsetY = textureOffsetY += 0.0012f;

        materialRef.SetTextureOffset("_MainTex", new Vector2(textureOffsetX, textureOffsetY));
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
        
        rigidbodyRef.AddExplosionForce(explosionForce, contact.point, explosionRadius, upwardsModifier, ForceMode.Impulse);
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(-explosionForce, contact.point, explosionRadius, upwardsModifier, ForceMode.Impulse);

        audioSourceRef.Play();
    }
}
