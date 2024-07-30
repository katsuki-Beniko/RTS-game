using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips : LossView
{
    public Text tipText;
    private string[] TIPS = 
    {
        "Try to pay attention where enemy position are.",
        "Use your character class as advantage.",
        "Sometimes, retreating is the best strategy."
    };
    public void DisplayRandomTip()
    {
        int randomIndex = Random.Range(0, TIPS.Length);
        tipText.text = TIPS[randomIndex];
    }
}

