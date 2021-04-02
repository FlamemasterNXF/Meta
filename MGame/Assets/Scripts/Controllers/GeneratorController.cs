using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BreakInfinity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static BreakInfinity.BigDouble;

public class GeneratorController : MonoBehaviour
{
    public SaveData data;
    public TMP_Text layerAndCurrencyText;
    public TMP_Text mainGenInfoText;
    public TMP_Text secondGenInfoText;
    private int CurrentGenID = 1;

    private void Start()
    {
        var n = data.genList.Count - 1;
        UpdateTexts();
    }

    private void Update()
    {
        layerAndCurrencyText.text = $"You are in<size=50><color=purple> Meta Layer 0</color></size>\n<size=40><color=yellow>You are in Prestige Layer 0</color></size>\n\n<size=50><color=orange>You have {Methods.NotationMethodBd(data.currency)} WIP Coin</color></size>";
        data.currency += (50 *data.genList[0].generatorAmount) * Time.deltaTime;
    }

    private void UpdateTexts()
    {
        CreateGenerators();
        if(data.genList[CurrentGenID].generatorsBought >= 5)
            CurrentGenID++;
        layerAndCurrencyText.text = $"You are in<size=50><color=purple> Meta Layer 0</color></size>\n<size=40><color=yellow>You are in Prestige Layer 0</color></size>\n\n<size=50><color=orange>You have {data.currency} WIP Coin</color></size>";
        if (CurrentGenID >= 2)
        {
            mainGenInfoText.text = $"You have<size=40> {Methods.NotationMethodBd(data.genList[CurrentGenID].generatorAmount)} Generator {CurrentGenID}s</size>\nCost: <size=30>{Methods.NotationMethodBd(data.genList[CurrentGenID].generatorCost)} WIP Coin</size>\nYour Generator {Methods.NotationMethodBd(data.genList[CurrentGenID].generatorID)}s produce<size=30> 0 Generator {Methods.NotationMethodBd(data.genList[CurrentGenID - 1].generatorID)}s per second</size>";
            secondGenInfoText.text = $"You have<size=40> {Methods.NotationMethodBd(data.genList[CurrentGenID - 1].generatorAmount)} Generator {(CurrentGenID - 1)}s</size>\nCost: <size=30>{Methods.NotationMethodBd(data.genList[CurrentGenID - 1].generatorCost)} WIP Coin</size>";
        }
        else
        {
            mainGenInfoText.text = $"You have<size=40> {Methods.NotationMethodBd(data.genList[CurrentGenID].generatorAmount)} Generator {CurrentGenID}s</size>\nCost: <size=30>{Methods.NotationMethodBd(data.genList[CurrentGenID].generatorCost)} WIP Coin</size>";
            secondGenInfoText.text = "There are no previous Generators";
        }
    }

    private void CreateGenerators()
    {
        for (var i = 1; i < data.genCap; i++)
        {
            data.genList.Add(data.genObj);
            var n = data.genList.Count-1;
            #region cost
            if (n != 1)
            {
                BigDouble previousBase = 10 * (2 * n);
                data.genList[n].generatorCost = (previousBase * 2) * Pow(1.25, data.genList[n].generatorsBought);   
            }
            else
            {
                data.genList[n].generatorCost = 10;
            }
            #endregion
            data.genList[n].generatorID = n + 1;
            Methods.UpgradeCheck(data.genList, i);
        }
    }

    public void BuyGenerator()
    {
        if (data.currency >= data.genList[CurrentGenID-1].generatorCost)
        {
            data.currency -= data.genList[CurrentGenID-1].generatorCost;
            data.genList[CurrentGenID-1].generatorsBought++;
            data.genList[CurrentGenID-1].generatorAmount++;
            UpdateTexts();
            BigDouble previousBase = 10 * (2 * CurrentGenID-1);
            data.genList[CurrentGenID-1].generatorCost = (previousBase * 2) * Pow(1.25, data.genList[CurrentGenID-1].generatorsBought);
            print("bought gen1");
        }
    }
}
