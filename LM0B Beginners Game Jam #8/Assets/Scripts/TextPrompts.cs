using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompts : MonoBehaviour
{
    public Text prompt;
    public GameObject retryButton;
    public GameObject nextButton;
    public GameObject returnButton;

    private WaitForSeconds oneSecond = new WaitForSeconds(1.0f);
    private bool lastBlockCaught = false;

    private AudioSource audioSourceRef;
    public AudioClip countdownLow;
    public AudioClip countdownHigh;
    public AudioClip alert;
    public AudioClip tick;

    private void Awake()
    {
        audioSourceRef = Camera.main.GetComponent<AudioSource>();
    }

    void Five()
    {
        prompt.text = "5";
    }

    void Four()
    {
        prompt.text = "4";
    }

    void Three()
    {
        prompt.text = "3";

        if (!GameData.GameOn)
            audioSourceRef.PlayOneShot(countdownLow);
    }

    void Two()
    {
        prompt.text = "2";

        if (!GameData.GameOn)
            audioSourceRef.PlayOneShot(countdownLow);
    }

    void One()
    {
        prompt.text = "1";

        if (!GameData.GameOn)
            audioSourceRef.PlayOneShot(countdownLow);
    }
    void Go()
    {
        prompt.text = "GO!";

        if (!GameData.GameOn)
            audioSourceRef.PlayOneShot(countdownHigh);

        //Fire start event
        string rValue = EventRelay.RelayEvent(EventRelay.EventMessageType.GameStart, this);
        Debug.Log("Game Start Event was seen by: " + rValue);
    }

    void GameOver()
    {
        prompt.text = "Game Over";
    }

    void Success()
    {
        prompt.text = "Success";
    }

    void HoldIt()
    {
        prompt.text = "Hold It!";
    }

    void Blank()
    {
        prompt.text = "";
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

    IEnumerator FinalCountdown()
    {
        if (GameData.GameOn)
        {
            HoldIt();
            audioSourceRef.PlayOneShot(alert);
        }
        yield return oneSecond;

        if (GameData.GameOn)
        {
            Five();
            audioSourceRef.PlayOneShot(tick);
        }
        yield return oneSecond;

        if (GameData.GameOn)
        {
            Four();
            audioSourceRef.PlayOneShot(tick);
        }
        yield return oneSecond;

        if (GameData.GameOn)
        {
            Three();
            audioSourceRef.PlayOneShot(tick);
        }
        yield return oneSecond;

        if (GameData.GameOn)
        {
            Two();
            audioSourceRef.PlayOneShot(tick);
        }
        yield return oneSecond;

        if (GameData.GameOn)
        {
            One();
            audioSourceRef.PlayOneShot(tick);
        }
        yield return oneSecond;

        if(GameData.GameOn)
        {
            //Fire start event
            string rValue = EventRelay.RelayEvent(EventRelay.EventMessageType.GameWon, this);
            Debug.Log("Game Won Event was seen by: " + rValue);
        }

        yield break;
    }

    string HandleEvent(EventRelay.EventMessageType messageType, MonoBehaviour sender)
    {
        if (messageType == EventRelay.EventMessageType.GameOver)
        {
            GameOver();
            retryButton.SetActive(true);
            returnButton.SetActive(true);
        }
        if (messageType == EventRelay.EventMessageType.LastBlockCaught)
        {
            if(!lastBlockCaught)
            StartCoroutine(FinalCountdown());
            lastBlockCaught = true;
        }
        if (messageType == EventRelay.EventMessageType.GameWon)
        {
            Success();
            nextButton.SetActive(true);
            returnButton.SetActive(true);
        }
        if (messageType == EventRelay.EventMessageType.QueueNextLevel)
        {
            nextButton.GetComponent<Button>().interactable = true;
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
