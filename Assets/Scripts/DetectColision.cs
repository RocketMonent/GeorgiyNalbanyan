using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
