using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionChecker : MonoBehaviour
{
    public Text firstConditionText;
    public Text secondConditionText;
    public Text thirdConditionText;

    private DataSaver dataSaver;

    void Start()
    {
        dataSaver = FindObjectOfType<DataSaver>();
    }

    public void CheckConditions()
    {
        bool condition1 = CheckCondition1();
        bool condition2 = CheckCondition2();
        bool condition3 = CheckCondition3();

        UpdateTextColor(firstConditionText, condition1);
        UpdateTextColor(secondConditionText, condition2);
        UpdateTextColor(thirdConditionText, condition3);

        SaveChallengeCompletion(condition1, condition2, condition3);
    }

    private bool CheckCondition1()
    {
        // Check if the stage has been cleared
        return FightGameOverUnit.StageCleared;
    }

    private bool CheckCondition2()
    {
        // Check if the stage has been cleared without any casualties
        return FightGameOverUnit.NoCasualties;
    }

    private bool CheckCondition3()
    {
        // Check if the stage has been cleared within the turn limit
        return FightGameOverUnit.WithinTurnLimit;
    }

    private void UpdateTextColor(Text text, bool conditionMet)
    {
        text.color = conditionMet ? Color.green : Color.red;
    }

    private void SaveChallengeCompletion(bool cond1, bool cond2, bool cond3)
    {
        int completionCount = 0;
        if (cond1) completionCount++;
        if (cond2) completionCount++;
        if (cond3) completionCount++;

        // Save the challenge completion count using DataSaver
        dataSaver.SaveChallengeCompletion(completionCount);
    }
}
