using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase.Database;
using System.Collections;

[Serializable]
public class dataToSave
{
    public string userName;
    public int crrLevel;
    public int challengeCompletion; // Add this field to store challenge completion
}

public class DataSaver : MonoBehaviour
{
    public dataToSave dts;
    public string userId;
    DatabaseReference dbRef;

    private void Awake()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Optional: Method to get the current score if needed
    

    public void SaveChallengeCompletion(int completionCount)
    {
        // Update the local data structure
        dts.challengeCompletion = completionCount;

        // Convert the data to JSON format
        string json = JsonUtility.ToJson(dts);

        // Save the JSON data to Firebase under the user's specific child node
        dbRef.Child("users").Child(userId).SetRawJsonValueAsync(json)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("Failed to save challenge completion: " + task.Exception);
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("Challenge completion saved successfully!");
                }
            });
    }

    public void LoadDataFn()
    {
        StartCoroutine(LoadDataEnum());
    }

    IEnumerator LoadDataEnum()
    {
        var serverData = dbRef.Child("users").Child(userId).GetValueAsync();
        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        print("process is complete");

        DataSnapshot snapshot = serverData.Result;
        string jsonData = snapshot.GetRawJsonValue();

        if (jsonData != null)
        {
            print("server data found");

            dts = JsonUtility.FromJson<dataToSave>(jsonData);
        }
        else
        {
            print("no data found");
        }
    }
}
