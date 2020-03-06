using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
[System.Serializable]
public class PlayerAccountInfo{

    static PlayerAccountInfo _instance;
    PlayerAccountInfo()
    {
        
    }

    [SerializeField]
    public List<accountInfo> list_accountInfo;
    public static PlayerAccountInfo Instance
    {
        get
        {
            if (null == _instance)
            {
                string json = "";
                StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/Json/PlayerAccountInfo.txt", System.Text.Encoding.UTF8);
                try
                {
                    json = sr.ReadToEnd();
                    _instance = JsonUtility.FromJson<PlayerAccountInfo>(json);
                    if (_instance.list_accountInfo == null)
                    {
                        _instance.list_accountInfo = new List<accountInfo>();
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

    public string CurUsername
    {
        get
        {
            return curUsername;
        }
        set
        {
            this.curUsername = value;
        }
    }

    public string CurPassword
    {
        get
        {
            return curPassword;
        }
        set
        {
            this.curPassword = value;
        }
    }

    public void SaveInfo()
    {
        string json = JsonUtility.ToJson(this);
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/Json/PlayerAccountInfo.txt");
        try
        {
            sw.Write(json);
            Debug.Log("saveinfo");
        }catch(System.Exception e)
        {
            throw e;
        }
        sw.Close();
    }

    [SerializeField]
    string curUsername;

    [SerializeField]
    string curPassword;

    [System.Serializable]
    public struct accountInfo
    {
        [SerializeField]
        public string username;
        [SerializeField]
        public string password;

        public accountInfo(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
