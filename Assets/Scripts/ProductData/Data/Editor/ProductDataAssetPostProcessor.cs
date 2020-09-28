using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class ProductDataAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/QuickSheet/Example1/Excel/ProductData.xlsx";
    private static readonly string assetFilePath = "Assets/QuickSheet/Example1/Excel/ProductData.asset";
    private static readonly string sheetName = "ProductData";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            ProductData data = (ProductData)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ProductData));
            if (data == null) {
                data = ScriptableObject.CreateInstance<ProductData> ();
                //data.SheetName = filePath;
                //data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<ProductDataData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<ProductDataData>();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
