using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public enum TargetType
    {
        Good,
        Bad,
    }

    public TargetType targetType;

    public ParticleSystem explosion;
    public int pointValue;

    private Rigidbody rigidbody;
    private GameManager gameManager;

    private float minSpeed = 14;
    private float maxSpeed = 19;
    private float torqueRange = 10;
    private int xRange = 4;
    private int ySpawnPosition = -6;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

        rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPosition);
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        gameManager.UpdateScore(pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetType == TargetType.Good)
        {
            gameManager.UpdateHealth(1);
        }
        Destroy(gameObject);
    }
}
