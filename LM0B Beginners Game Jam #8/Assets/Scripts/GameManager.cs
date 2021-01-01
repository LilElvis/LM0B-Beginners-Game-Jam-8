using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Levels = new List<GameObject>();

    public GameObject deathBoundaries = null;

    void Start()
    {
        
    }

    void Update()
    {

    }

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
        if (messageType == EventRelay.EventMessageType.GameStart)
        {
            Levels[GameData.CurrentLevelSelection].SetActive(true);
            GameData.GameOn = true;
        }
        if (messageType == EventRelay.EventMessageType.GameOver)
        {
            GameData.GameOn = false;
        }
        if (messageType == EventRelay.EventMessageType.GameWon)
        {
            GameData.GameOn = false;
            deathBoundaries.SetActive(false);

            GameData.CurrentLevelSelection++;
            if (!(GameData.CurrentLevelSelection > Levels.Count - 1))
            {
                //Fire Game Over event
                string rValue = EventRelay.RelayEvent(EventRelay.EventMessageType.QueueNextLevel, this);
                Debug.Log("Queue Next Level Event was seen by: " + rValue);
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
