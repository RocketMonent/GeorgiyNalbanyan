using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public RotateCamera focalPoint;
    public bool hasPowerup;
    private float powerupStrength = 15;
    public GameObject powerupIndicator;

    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rigidbody.AddForce(focalPoint.transform.forward * verticalInput);

        powerupIndicator.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Powerup powerup))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(powerup.gameObject);
            StartCoroutine(PowerupCountDown());
        }
    }

    private IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && hasPowerup)
        {
            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (enemy.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);

        }
    }
}
