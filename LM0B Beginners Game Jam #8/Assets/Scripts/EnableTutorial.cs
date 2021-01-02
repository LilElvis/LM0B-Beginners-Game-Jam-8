using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTutorial : MonoBehaviour
{
    public GameObject tutorialPromptsRef;

    void Awake()
    {
        if (GameData.CurrentLevelSelection == 0)
            tutorialPromptsRef.SetActive(true);
    }
}
