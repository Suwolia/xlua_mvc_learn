using UnityEngine;
using System.Collections;
using XLua;
using System;
using UnityEngine.UI;
using System.Collections.Generic;

public class view_bag : MonoBehaviour {

    public LuaEnv luaenv;

    public Action _awake;
    public Action _start;
    public Action _update;
    public Action _destroy;

    private void Awake()
    {
        luaenv = new LuaEnv();
        luaenv.Global.Set("this", this);
        luaenv.DoString("require('view_bag')");

        _awake = luaenv.Global.Get<Action>("Awake");
        _start = luaenv.Global.Get<Action>("Start");
        _update = luaenv.Global.Get<Action>("Update");
        _destroy = luaenv.Global.Get<Action>("Destroy");

        if (null != _awake)
        {
            _awake();
        }
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("grid_weapon");
        //Debug.Log(objs.Length);
        //Image image;
        //image.enabled

        //string[] strs = new string[20] { "bagGridView13", "bagGridView3", "bagGridView2", "bagGridView5", "bagGridView12", "bagGridView15", "bagGridView4", "bagGridView14", "bagGridView", "bagGridView6", "bagGridView19", "bagGridView10", "bagGridView1", "bagGridView9", "bagGridView16", "bagGridView7", "tt3", "bagGridView18", "bagGridView8", "bagGridView17" };
        //string[] strs = new string[10] { "bagGridView1", "bagGridView3", "bagGridView12", "bagGridView5", "bagGridView18", "bagGridView4", "bagGridView19", "bagGridView0", "bagGridView17", "bagGridView6" };
        //foreach (var item in strs)
        //{
        //    Debug.Log(item);
        //}
        //strs = arrangeGameObjects(strs);
        //Debug.Log("--------------");
        //foreach (var item in strs)
        //{
        //    Debug.Log(item);
        //}
    }

    //string[] arrangeGameObjects(string[] gameObjects)
    //{
    //    List<string> list_str_short = new List<string>();
    //    List<string> list_str_long = new List<string>();
    //    string[] result = new string[gameObjects.Length];
    //    for(int i = 0; i < gameObjects.Length; ++i)
    //    {
    //        if (gameObjects[i].Length == 12)
    //        {
    //            list_str_short.Add(gameObjects[i]);
    //        }else
    //        {
    //            list_str_long.Add(gameObjects[i]);
    //        }
    //    }
    //    list_str_short.Sort();
    //    list_str_long.Sort();
    //    for (int i = 0; i < list_str_short.Count; ++i)
    //    {
    //        result[i] = list_str_short[i];
    //    }
    //    for(int i = 0; i < list_str_long.Count; ++i)
    //    {
    //        result[i + 5] = list_str_long[i];
    //    }
    //    return result;
    //}

    // Use this for initialization
    void Start () {

        if (null != _start)
        {
            _start();
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (null != _update)
        {
            _update();
        }

	}

    private void OnDestroy()
    {
        if (null != _destroy)
        {
            _destroy();
        }
    }
}
