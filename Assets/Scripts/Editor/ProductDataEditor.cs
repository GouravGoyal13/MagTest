using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class ProductDataEditor : EditorWindow
{
    public static ProductDataEditor productDataEditor;
    private ProductData productDataScriptableObj;
    Vector2 scrollPos;
    ProductDataData[] productData;

    bool priceOrderToggle;
    bool IdOrderToggle;
    Item item;
    Item prevItem;
    char upArrow = '\u25B2';
    char downArrow = '\u25BC';
    string orderByPrice = "OrderBy Price";
    [MenuItem("MagTools/ProductDataEditor")]
    public static void Init()
    {
        // initialize window, show it, set the properties
        productDataEditor = EditorWindow.CreateInstance<ProductDataEditor>();
        productDataEditor.titleContent = new GUIContent("Columns");
        productDataEditor.Show();
        productDataEditor.Populate();
    }

    void Populate()
    {
        productDataScriptableObj = Resources.Load<ProductData>("ScriptableObjects/ProductData");
        //DrawHeader();
        productData = productDataScriptableObj.dataArray.ToArray();
    }


    void OnGUI()
    {
        if (productDataScriptableObj == null)
        {
            return;
        }

        DrawTableControls();
        GUILayout.EndScrollView();
        BottomButtons();

    }

    private void DrawTableControls()
    {
        scrollPos = GUILayout.BeginScrollView(scrollPos);
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("ProductId", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Description", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Price", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item1Name", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item1Amount", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item2Name", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item2Amount", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item3Name", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item3Amount", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();

        foreach (ProductDataData data in productData)
        {
            GUILayout.BeginHorizontal();

            EditorGUILayout.TextField(data.Productid.ToString());
            EditorGUILayout.TextField(data.Description);
            EditorGUILayout.TextField(data.Price.ToString());
            EditorGUILayout.TextField(data.Item1.ToString());
            EditorGUILayout.TextField(data.Amount1.ToString());
            EditorGUILayout.TextField(data.Item2.ToString());
            EditorGUILayout.TextField(data.Amount2.ToString());
            EditorGUILayout.TextField(data.Item3.ToString());
            EditorGUILayout.TextField(data.Amount3.ToString());
            GUILayout.EndHorizontal();
        }
    }

    private void BottomButtons()
    {
        GUILayout.BeginHorizontal();
        if (GUILayout.Button(orderByPrice, EditorStyles.miniButtonLeft))
        {
            if (priceOrderToggle)
            {
                orderByPrice = string.Format($"{0} {1}", orderByPrice, upArrow.ToString());
                productData = productDataScriptableObj.dataArray.OrderBy(i => i.Price).ToArray();
            }
            else
            {
                orderByPrice = string.Format($"{0} {1}", orderByPrice, downArrow.ToString());
                productData = productDataScriptableObj.dataArray.OrderByDescending(i => i.Price).ToArray();
            }
            priceOrderToggle = !priceOrderToggle;
        }
        if (GUILayout.Button("orderByProductID", EditorStyles.miniButtonLeft))
        {
            if (IdOrderToggle)
            {
                productData = productDataScriptableObj.dataArray.OrderBy(i => i.Productid).ToArray();
            }
            else
            {
                productData = productDataScriptableObj.dataArray.OrderByDescending(i => i.Productid).ToArray();
            }
            IdOrderToggle = !IdOrderToggle;
        }

        item = (Item)EditorGUILayout.EnumPopup("Sort By:", item);
        if (prevItem != item)
        {
            prevItem = item;
            productData = productDataScriptableObj.dataArray.OrderByDescending(i => i.Item1 == item.ToString() || i.Item2 == item.ToString() || i.Item2 == item.ToString()).ToArray();
        }
        GUILayout.EndHorizontal();
        if (GUILayout.Button("Save", EditorStyles.miniButtonLeft))
        {
            productDataScriptableObj.dataArray = productData.ToList();
            Undo.RecordObject(productDataScriptableObj, "modify");
            AssetDatabase.Refresh();
            EditorUtility.SetDirty(productDataScriptableObj);
            AssetDatabase.SaveAssets();
        }
    }
   
    void OnSelectionChange() { Populate(); Repaint(); }
    void OnEnable() { Populate(); }
    void OnFocus() { Populate(); }
}