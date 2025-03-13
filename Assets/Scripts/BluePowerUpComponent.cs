using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePowerUpComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private new Collider collider;
    private MeshRenderer mesh;
    private float rotateSpeed;
    private Vector3 startPos;
    private ParticleSystem collectParticles;
    private float boostDuration;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        collider = GetComponent<Collider>();
        collectParticles = GetComponent<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
        rotateSpeed = 80f;
        boostDuration = 30f;
    }

    // Update is called once per frame
    void Update()
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
        // TODO: implement the power functionality
        CharacterMovement movement = player.GetComponent<CharacterMovement>();
        if (movement != null)
        {
            Debug.Log("Power-up collected! Applying jump boost...");
            StartCoroutine(ApplyJumpBoost(movement));
        }

        // Detach particle system so it plays independently
        collectParticles.transform.SetParent(null);
        collectParticles.Play();

        // Disable the power-up visuals & collider
        mesh.enabled = false;
        collider.enabled = false;

        // Destroy after particles finish playing
        StartCoroutine(DisablePowerUp());
    }

    private IEnumerator ApplyJumpBoost(CharacterMovement movement)
    {
        // Apply the speed boost by multiplying base speeds with speedMultiplier
        movement.hasPowerUp = true;

        Debug.Log("Double Jump Time!");

        yield return new WaitForSeconds(boostDuration);

        movement.hasPowerUp = false;
        Debug.Log("No more double jump :(");
    }

    private IEnumerator DisablePowerUp()
    {
        // Wait until BOTH the speed boost and particle effect are finished
        yield return new WaitForSeconds(boostDuration);
        yield return new WaitForSeconds(collectParticles.main.duration);

        gameObject.SetActive(false);
    }
}
