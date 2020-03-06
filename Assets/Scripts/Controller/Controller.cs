using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Controller {

    static Controller _instance;

    Controller()
    {

    }

    public static Controller Instance
    {
        get
        {
            if (null == _instance)
            {
                _instance = new Controller();
            }
            return _instance;
        }
    }

    public void SaveCurAccountInfo(string curUsername,string curPassword)
    {
        PlayerAccountInfo.Instance.CurUsername = curUsername;
        PlayerAccountInfo.Instance.CurPassword = curPassword;
    }

    public bool CheckAccountInfo(string username,string password)
    {
        for(int i = 0; i < PlayerAccountInfo.Instance.list_accountInfo.Count; ++i)
        {
            if (username == PlayerAccountInfo.Instance.list_accountInfo[i].username)
            {
                if (password == PlayerAccountInfo.Instance.list_accountInfo[i].password)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
        }
        return false;
    }

    public bool CheckAccountExist(string username)
    {
        for(int i=0;i<PlayerAccountInfo.Instance.list_accountInfo.Count; ++i)
        {
            if (username == PlayerAccountInfo.Instance.list_accountInfo[i].username)
            {
                return true;
            }
        }
        return false;
    }

    public void AccountRegister(string username,string password)
    {
        PlayerAccountInfo.Instance.list_accountInfo.Add(new PlayerAccountInfo.accountInfo(username, password));
    }

    public Weapon GetWeapon(int id)
    {
        for(int i = 0; i < PlayerItemModel.Instance.list_weapon.Count; ++i)
        {
            if (id == PlayerItemModel.Instance.list_weapon[i].Id)
            {
                return PlayerItemModel.Instance.list_weapon[i];
            }
        }
        return null;
    }

    public Shield GetSheild(int id)
    {
        for (int i = 0; i < PlayerItemModel.Instance.list_shield.Count; ++i)
        {
            if (id == PlayerItemModel.Instance.list_shield[i].Id)
            {
                return PlayerItemModel.Instance.list_shield[i];
            }
        }
        return null;
    }

    public Bow GetBow(int id)
    {
        for (int i = 0; i < PlayerItemModel.Instance.list_bow.Count; ++i)
        {
            if (id == PlayerItemModel.Instance.list_bow[i].Id)
            {
                return PlayerItemModel.Instance.list_bow[i];
            }
        }
        return null;
    }


    public void updateItem_weapon(GameObject itemGrid,Weapon weapon)
    {
        Debug.Log("进来了");
        Image image_itemGrid = itemGrid.transform.Find("itemView").GetComponent<Image>();
        Sprite sp = Resources.Load<Sprite>("backgroung/itemIcon/weaponIcon/" + weapon.SpriteName);
        image_itemGrid.sprite = sp;
    }

    public void updateItem_bow(GameObject itemGrid, Bow bow)
    {
        Image image_itemGrid = itemGrid.transform.Find("itemView").GetComponent<Image>();
        Sprite sp = Resources.Load<Sprite>("backgroung/itemIcon/bowIcon/" + bow.SpriteName);
        image_itemGrid.sprite = sp;
    }

    public void updateItem_shield(GameObject itemGrid, Shield shield)
    {
        Image image_itemGrid = itemGrid.transform.Find("itemView").GetComponent<Image>();
        Sprite sp = Resources.Load<Sprite>("backgroung/itemIcon/shieldIcon/" + shield.SpriteName);
        image_itemGrid.sprite = sp;
    }

    public GameObject[] arrangeGameObjects(GameObject[] gameObjects)
    {
        for(int i = 0; i < gameObjects.Length; ++i)
        {
            for(int j = i+1; j < gameObjects.Length; ++j)
            {
                if (int.Parse(gameObjects[i].name.Remove(0,gameObjects[j].name.Length-2))>int.Parse(gameObjects[j].name.Remove(0, gameObjects[j].name.Length - 2)))
                {
                    GameObject temp = gameObjects[j];
                    gameObjects[j] = gameObjects[i];
                    gameObjects[i] = temp;
                }
            }
        }
        return gameObjects; 
    }


    //    updateItem_weapon=function(itemGrid, weapon)

    //    image_itemGrid = (CS.UnityEngine.UI.Image)itemGrid.transform:FindChild("itemView"):GetComponent("Image")
    //	--sp = (CS.UnityEngine.Sprite)CS.UnityEngine.Resources.Load("backgroung/itemIcon/weaponIcon/" + weapon.SpriteName, typeof(CS.UnityEngine.UI.Sprite))
    //	sp = CS.UnityEngine.Resources.Load("backgroung/itemIcon/weaponIcon/" + weapon.SpriteName, typeof(CS.UnityEngine.Sprite))

    //    print(sp)

    //    image_itemGrid.sprite = sp
    //end

    //updateItem_bow = function(itemGrid, bow)

    //    image_itemGrid = (CS.UnityEngine.UI.Image)itemGrid.transform:FindChild("itemView"):GetComponent("Image")

    //    sp = (CS.UnityEngine.Sprite)CS.UnityEngine.Resources.Load("backgroung/itemIcon/bowIcon/" + bow.SpriteName, typeof(CS.UnityEngine.Sprite))
    //	image_itemGrid.sprite = sp
    //end

    //updateItem_shield = function(itemGrid, shield)

    //    image_itemGrid = (CS.UnityEngine.UI.Image)itemGrid.transform:FindChild("itemView"):GetComponent("Image")

    //    sp = (CS.UnityEngine.Sprite)CS.UnityEngine.Resources.Load("backgroung/itemIcon/bowIcon/" + bow.SpriteName, typeof(CS.UnityEngine.Sprite))
    //	image_itemGrid.sprite = sp
    //end
}
