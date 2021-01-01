using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoundaries : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameData.GameOn)
        {
            //Fire Game Over event
            string rValue = EventRelay.RelayEvent(EventRelay.EventMessageType.GameOver, this);
            Debug.Log("Game Over Event was seen by: " + rValue);
        }
    }
}
