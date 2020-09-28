using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class ProductDataData
{
    [SerializeField]
    int productid;
    public int Productid { get { return productid; } set { this.productid = value; } }

    [SerializeField]
    bool isbundle;
    public bool Isbundle { get { return isbundle; } set { this.isbundle = value; } }

    [SerializeField]
    string item1;
    public string Item1 { get { return item1; } set { this.item1 = value; } }

    [SerializeField]
    long amount1;
    public long Amount1 { get { return amount1; } set { this.amount1 = value; } }

    [SerializeField]
    string item2;
    public string Item2 { get { return item2; } set { this.item2 = value; } }

    [SerializeField]
    long amount2;
    public long Amount2 { get { return amount2; } set { this.amount2 = value; } }

    [SerializeField]
    string item3;
    public string Item3 { get { return item3; } set { this.item3 = value; } }

    [SerializeField]
    long amount3;
    public long Amount3 { get { return amount3; } set { this.amount3 = value; } }

    [SerializeField]
    string description;
    public string Description { get { return description; } set { this.description = value; } }

    [SerializeField]
    long price;
    public long Price { get { return price; } set { this.price = value; } }

    [SerializeField]
    string icon;
    public string Icon { get { return icon; } set { this.icon = value; } }
    public List<ItemList> GetItems()
    {
        List<ItemList> Items = new List<ItemList>();
        if (item1 != null)
        {
            Items.Add(new ItemList(item1, amount1));
        }
        if (item2 != null)
        {
            Items.Add(new ItemList(item2, amount2));
        }
        if (item3 != null)
        {
            Items.Add(new ItemList(item3, amount3));
        }
        return Items;
}
}

public class ItemList : IComparable
{
    public string Item;
    public long Amount;
    public ItemList(string item, long amount)
    {
        Item = item;
        Amount = amount;
    }

    public int CompareTo(object obj)
    {
        ItemList other = obj as ItemList;
        if (other != null)
            return this.Item.CompareTo(other.Item);
        else
            throw new ArgumentException();
    }
}
public enum Item
{
    NONE = 0,
    COIN = 1,
    GEM = 2,
    TOKEN = 3
}
