using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningBlock : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Fire Last Block Caught event
        string rValue = EventRelay.RelayEvent(EventRelay.EventMessageType.LastBlockCaught, this);
        Debug.Log("Game Start Event was seen by: " + rValue);
    }
}
