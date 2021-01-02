using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public int levelNumber = 0;

    private Button buttonRef = null;

    void Awake()
    {
        buttonRef = GetComponent<Button>();
    }

    void Start()
    {
        if(levelNumber <= GameData.LevelsUnlocked)
        {
            buttonRef.interactable = true;
        }
    }
}
