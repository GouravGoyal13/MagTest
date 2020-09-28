using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMenu : MonoBehaviour,IScreen
{
    [SerializeField]
    private ScrollList scrollList;

    public void Init(object context)
    {
        
    }

    void Start()
    {
        scrollList.Draw<ProductDataData>(LoadScriptableAssets.Instance.GetProductList());
    }
}
