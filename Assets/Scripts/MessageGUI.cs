using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageGUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public GameObject messagePanel;

    private void Start()
    {
        MessageController.Instance.OnMessageChanged += MessageController_OnMessageChanged;
    }

    private void MessageController_OnMessageChanged(string obj)
    {
        messageText.text = obj;

        StartCoroutine(ShowMessage());
    }

    private void Show()
    {
        messagePanel.SetActive(true);
    }

    private void Hide()
    {
        messagePanel.SetActive(false);
    }

    private IEnumerator ShowMessage()
    {
        Show();

        yield return new WaitForSeconds(2.0f);
        Hide();
    }
}
