using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScreenType
{
    STORE_MENU,
    PRODUCT_INFO_POPUP
}
[Serializable]
public class UIScreen
{
    public ScreenType screenType;
    public GameObject screenObject;
}

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIScreen[] screens;

    private Dictionary<ScreenType, IScreen> screenMap = new Dictionary<ScreenType, IScreen>();
    public static UIManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        for (int i = 0; i<screens.Length;i++)
        {
            if (!screenMap.ContainsKey(screens[i].screenType))
            {
                screenMap.Add(screens[i].screenType, screens[i].screenObject.GetComponent<IScreen>());
            }
        }
    }

    // Update is called once per frame
    public IScreen GetScreenByType(ScreenType screenType)
    {
        if (screenMap.ContainsKey(screenType))
            return screenMap[screenType];
        return null;
    }
}
