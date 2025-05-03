using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool hasKey;
    private bool isNearKey;
    private Key grabedKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Key key))
        {
            isNearKey = true;
            grabedKey = key;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Key key))
        {
            isNearKey = false;
            grabedKey = null;
        }
    }

    private void Update()
    {
        if (isNearKey)
        {
            MessageController.Instance.SetMessageByType(MessageType.GrabKey);

            if (Input.GetKey(KeyCode.E))
            {
                Destroy(grabedKey.gameObject);
                hasKey = true;

                isNearKey = false;

                MessageController.Instance.SetMessageByType(MessageType.FindExit);
            }
        }
    }

    public bool GetHasKeyValue()
    {
        return hasKey; 
    }
}
