using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private static int currentLevelSelection = 0;

    public static int CurrentLevelSelection
    {
        get { return currentLevelSelection; }
        set { currentLevelSelection = value; }
    }

    private static int levelsUnlocked = 0;

    public static int LevelsUnlocked
    {
        get { return levelsUnlocked; }
        set { levelsUnlocked = value; }
    }

    private static bool gameOn = false;

    public static bool GameOn
    {
        get { return gameOn; }
        set { gameOn = value; }
    }
}
