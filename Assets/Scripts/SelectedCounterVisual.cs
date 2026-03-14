using System;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjects;
    public void Start()
    {
        Player.Instance.OnSelectedCounterChanged += PlayerOnSelectedCounterChanged;
    }

    private void PlayerOnSelectedCounterChanged(BaseCounter obj)
    {
        if (obj == baseCounter)
        {
            foreach (var visualGameObject in visualGameObjects)
            {
                visualGameObject.SetActive(true);
            }
        }
        else
        {
            foreach (var visualGameObject in visualGameObjects)
            {
                visualGameObject.SetActive(false);
            }
        }
    }
}
