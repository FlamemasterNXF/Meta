using BreakInfinity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BreakInfinity.BigDouble;

[Serializable]
public class SaveData
{
    public BigDouble currency;
    #region Generators
    public List<Generator> genList;
    public Generator genObj;
    public int genCap;
    #endregion
    
    public SaveData()
    {
        currency = 320;
        genCap = 10;
        genList = new List<Generator>();
    }
}