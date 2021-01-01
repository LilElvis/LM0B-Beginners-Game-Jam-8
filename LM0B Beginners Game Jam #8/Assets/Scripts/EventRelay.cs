//This script is modeled after the event system modeled in the LinkedInLearning lecture found here: https://www.lynda.com/Unity-3D-tutorials/Events-messaging-systems/160270/177261-4.html?autoplay=true

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRelay : MonoBehaviour
{
    public delegate string EventAction(EventMessageType type, MonoBehaviour sender);
    public static event EventAction OnEventAction;

    public enum EventMessageType
    {
        GameStart,
        LastBlockCaught,
        GameOver,
        GameWon,
        QueueNextLevel
    }

    public static string RelayEvent(EventMessageType messageType, MonoBehaviour sender)
    {
        return OnEventAction(messageType, sender);
    }
}