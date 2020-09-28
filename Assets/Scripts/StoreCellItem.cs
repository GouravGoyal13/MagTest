using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreCellItem : MonoBehaviour,IContext
{
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private GameObject prefabParent;

    private ProductDataData context;

    void RefreshUI()
    {
        if (descriptionText != null && context.Description!=null)
        { 
            descriptionText.text = context.Description;
        }
        if(priceText != null)
        {
            priceText.text = context.Price.ToString();
        }
        if (prefabParent != null && context.Icon!=null)
        {
            GameObject go = Resources.Load(context.Icon) as GameObject;
            Instantiate(go,prefabParent.transform);
        }
    }

    public void OnCellClick()
    {
        IScreen screen = UIManager.Instance.GetScreenByType(ScreenType.PRODUCT_INFO_POPUP);
        screen.Init(context);
    }

    public void SetContext(object context)
    {
        if (context != null)
        {
            if (context is ProductDataData)
            {
                this.context = (ProductDataData)context;
                RefreshUI();
            }
        }
    }
}
