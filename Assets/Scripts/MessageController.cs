using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    public static MessageController Instance { get; private set; }

    public event Action<string> OnMessageChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetMessageByType(MessageType.Start);
    }

    public void SetMessageByType(MessageType messageType)
    {
        string message = "";

        switch (messageType)
        {
            case MessageType.Start:
                message = "Hello, you must find exit from the mansion, but first find the key.";
                break;
            case MessageType.GrabKey:
                message = "Press E to grab the key!";
                break;
            case MessageType.FindExit:
                message = "And now you need to find the exit from the mansion.";
                break;
            case MessageType.FindKey:
                message = "WoW, you find the exit, but you still need the key.";
                break;
        }

        OnMessageChanged?.Invoke(message);
    }
}


public enum MessageType
{
    Start,
    GrabKey,
    FindExit,
    FindKey
}
