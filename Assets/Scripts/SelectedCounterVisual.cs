using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject;
    public void Start()
    {
        Player.Instance.OnSelectedCounterChanged += PlayerOnSelectedCounterChanged;
    }

    private void PlayerOnSelectedCounterChanged(ClearCounter obj)
    {
        if (obj == clearCounter)
        {
            visualGameObject.SetActive(true);
        }
        else
        {
            visualGameObject.SetActive(false);
        }
    }
}
