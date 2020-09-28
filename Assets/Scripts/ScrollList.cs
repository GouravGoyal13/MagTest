using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IContext
{
    void SetContext(object context);
}
public class ScrollList : MonoBehaviour
{
    [SerializeField] 
    private Transform scrollParent;
    [SerializeField] 
    private GameObject cellPrefab;
    [SerializeField]
    private List<IContext> cells;
    private void Awake()
    {
        if (scrollParent == null)
        {
            Debug.LogError("Scroll parent should'nt be null");
            return;
        }
        cells = new List<IContext>();
    }

    public void Draw<T>(List<T> t)
    {
        // cells = new RectTransform[t.Count];
        if (cells == null)
        {
            cells = new List<IContext>();
        }
        for (int i = 0; i < t.Count; i++)
        {
            GameObject obj = (GameObject)Instantiate(cellPrefab, scrollParent.transform);
            IContext context = obj.GetComponent<IContext>();
            context.SetContext(t[i]);
            cells.Add(context);
        }
    }

    public void Redraw<T>(List<T> t)
    {
        if (scrollParent != null)
        {
            foreach (Transform transform in scrollParent)
            {
                Destroy(transform.gameObject);
            }
        }
        Draw<T>(t);
    }

    public void Refresh<T>(List<T> t)
    {
        if (t.Count == cells.Count)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].SetContext(t[i]);
            }
        }
    }
}
