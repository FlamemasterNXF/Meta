using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public SaveData data;
    void Start()
    {
        SaveSystem.LoadPlayer(ref data);
        StartCoroutine(SaveClock());
    }

    public void FullReset()
    {
        data = new SaveData();
    }
    private void Save()
    {
        SaveSystem.SavePlayer(data);
    }
    
    private IEnumerator SaveClock()
    {
        Save();
        yield return new WaitForSecondsRealtime(10);
        print("saved");
        StartCoroutine(SaveClock());
    }
}
