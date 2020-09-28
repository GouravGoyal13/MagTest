using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProductInfoPopup : MonoBehaviour,IScreen
{
    [SerializeField]
    private GameObject prefabParent;
    [SerializeField]
    private Text descriptionText;
    [SerializeField]
    private Text[] bundleInfoTexts;

    private ProductDataData context;

    public void Init(object context)
    {
        if (context != null)
        {
            if (context is ProductDataData)
            {
                this.context = (ProductDataData)context;
                this.gameObject.SetActive(true);
                RefreshUI();
            }
        }
    }

    // Start is called before the first frame update
    void RefreshUI()
    {
        if (prefabParent != null && context.Icon!=null)
        {
            Instantiate(Resources.Load(context.Icon) as GameObject, prefabParent.transform);
        }

        if (descriptionText.text != null && context.Description != null)
        {
            descriptionText.text = context.Description;
        }
        if (bundleInfoTexts != null)
        {
            for (int i =0;i<context.GetItems().Count;i++)
            {
                if (bundleInfoTexts[i] != null && context.GetItems()[i].Amount > 0)
                {
                    bundleInfoTexts[i].text = string.Format("{0} {1}",context.GetItems()[i].Amount.ToString(), context.GetItems()[i].Item);
                    bundleInfoTexts[i].gameObject.SetActive(true);
                }
            }
        }

    }

    public void OnClose()
    {
        foreach (Text t in bundleInfoTexts)
        {
            t.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
        foreach (Transform child in prefabParent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
