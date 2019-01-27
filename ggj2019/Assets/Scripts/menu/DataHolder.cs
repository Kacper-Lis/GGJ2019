using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataHolder
{
    public static int scoreManager;

    public static int ScoreManager
    {
        get
        {
            return scoreManager;
        }
        set
        {
            scoreManager = 0;
        }
    }

}
