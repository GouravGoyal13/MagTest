using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//[System.Serializable]
public class ProductData : ScriptableObject 
{	
    //[HideInInspector] [SerializeField] 
    //public string SheetName = "";
    
    //[HideInInspector] [SerializeField] 
    //public string WorksheetName = "";


    public List<ProductDataData> dataArray;
}
