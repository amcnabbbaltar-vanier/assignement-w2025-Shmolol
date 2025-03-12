using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPowerUpComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private new Collider collider;
    private MeshRenderer mesh;
    private float rotateSpeed = 80f;
    private Vector3 startPos;
    private ParticleSystem collectParticles;

    private void Start()
    {
        startPos = transform.position;
        collider = GetComponent<Collider>();
        collectParticles = GetComponent<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        float newY = Mathf.Sin(Time.time * 3) * 0.2f;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    private void Pickup(Collider player)
    {
        GameManager.Instance.IncrementScore();

        // Detach particle system so it plays independently
        collectParticles.transform.SetParent(null);
        collectParticles.Play();

        // Disable the power-up visuals & collider
        mesh.enabled = false;
        collider.enabled = false;

        // Destroy after particles finish playing
        Invoke("DisablePowerUp", collectParticles.main.duration);
    }

    private void DisablePowerUp()
    {
        gameObject.SetActive(false);
    }
}
