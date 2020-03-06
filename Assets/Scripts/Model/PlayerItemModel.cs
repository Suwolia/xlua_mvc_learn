using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class PlayerItemModel {

    static PlayerItemModel _instance;

    PlayerItemModel()
    {

    }

    public static PlayerItemModel Instance
    {
        get
        {
            if (null == _instance)
            {
                string json = "";
                StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/Json/PlayerItemInfo.txt", System.Text.Encoding.UTF8);
                try
                {
                    json = sr.ReadToEnd();
                    _instance = JsonUtility.FromJson<PlayerItemModel>(json);
                    if (_instance.list_weapon == null)
                    {
                        _instance.list_weapon = new List<Weapon>();
                    }
                    if(_instance.list_bow == null)
                    {
                        _instance.list_bow = new List<Bow>();
                    }
                    if (_instance.list_shield == null)
                    {
                        _instance.list_shield = new List<Shield>();
                    }
                }
                catch (System.Exception e)
                {
                    throw e;
                }
                sr.Close();
            }
            return _instance;
        }
    }

    public void SaveInfo()
    {
        string json = JsonUtility.ToJson(this);
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/Json/PlayerItemInfo.txt");
        try
        {
            sw.Write(json);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        sw.Close();
    }

    [SerializeField]
    public List<Weapon> list_weapon;
    [SerializeField]
    public List<Shield> list_shield;
    [SerializeField]
    public List<Bow> list_bow;

}

[System.Serializable]
public class Item
{
    [SerializeField]
    protected ItemType itemType;

    [SerializeField]
    protected int atk;

    [SerializeField]
    protected int defend;

    [SerializeField]
    protected int id;

    [SerializeField]
    protected string itemInfo;

    [SerializeField]
    protected string itemName;

    [SerializeField]
    protected string spriteName;

    public ItemType ItemType
    {
        get
        {
            return itemType;
        }
    }

    public int Atk
    {
        get
        {
            return atk;
        }
    }

    public int Defend
    {
        get
        {
            return defend;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }
    }

    public string ItemInfo
    {
        get
        {
            return itemInfo;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }
    }

    public string SpriteName
    {
        get
        {
            return spriteName;
        }
    }

    public Item(ItemType itemType,int atk,int defend,int id,string itemInfo,string itemName,string spriteName)
    {
        this.itemType = itemType;
        this.atk = atk;
        this.defend = defend;
        this.id = id;
        this.itemInfo = itemInfo;
        this.itemName = itemName;
        this.spriteName = spriteName;
    }
}

[System.Serializable]
public class Weapon : Item
{
    public Weapon(ItemType itemType, int atk, int defend, int id, string itemInfo, string itemName, string spriteName) : base(itemType, atk, defend, id, itemInfo, itemName, spriteName)
    {
    }
}

[System.Serializable]
public class Shield : Item
{
    public Shield(ItemType itemType, int atk, int defend, int id, string itemInfo, string itemName, string spriteName) : base(itemType, atk, defend, id, itemInfo, itemName, spriteName)
    {
    }
}

[System.Serializable]
public class Bow : Item
{
    public Bow(ItemType itemType, int atk, int defend, int id, string itemInfo, string itemName, string spriteName) : base(itemType, atk, defend, id, itemInfo, itemName, spriteName)
    {
    }
}

public enum ItemType
{
    Weapon,
    Shield,
    Bow
}
