using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text ScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        ScoreDisplay.text = "Your Score was: " + DataHolder.scoreManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
