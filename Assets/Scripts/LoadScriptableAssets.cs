using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadScriptableAssets : MonoBehaviour
{
    public const string AssetPath = "ScriptableObjects";
    List<ScriptableObject> configs = new List<ScriptableObject>();

    public static LoadScriptableAssets Instance;

    // Start is called before the first frame update
    private void OnValidate()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        configs = Resources.LoadAll<ScriptableObject>(AssetPath).ToList();
        GetProductList();
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        configs = Resources.LoadAll<ScriptableObject>(AssetPath).ToList();
        GetProductList();
    }

    [ExecuteInEditMode]
    public List<ProductDataData> GetProductList()
    {
        ProductData products = (ProductData)configs.FirstOrDefault(i => i.GetType() == typeof(ProductData));
        if(products!=null)
            return products.dataArray.ToList();
        return null;
    }
}
