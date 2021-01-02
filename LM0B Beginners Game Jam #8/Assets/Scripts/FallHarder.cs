using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHarder : MonoBehaviour
{
    //Event Listner
    public List<EventRelay.EventMessageType> eventsHandled = new List<EventRelay.EventMessageType>();

    void OnEnable()
    {
        EventRelay.OnEventAction += HandleEvent;
    }

    void OnDisable()
    {
        EventRelay.OnEventAction -= HandleEvent;
    }

    string HandleEvent(EventRelay.EventMessageType messageType, MonoBehaviour sender)
    {
        
        if (messageType == EventRelay.EventMessageType.GameOver)
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].drag = 0.0f;
            }
        }
        if (messageType == EventRelay.EventMessageType.GameWon)
        {
            Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].Sleep();
            }
        }

        if (eventsHandled.Contains(messageType))
        {
            Debug.Log("Handled Event: " + messageType + " from sender: " + sender);
            return ToString();
        }
        else
        {
            return ToString();
        }
    }
}
