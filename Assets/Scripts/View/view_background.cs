using UnityEngine;
using System.Collections;
using System;
using XLua;
using UnityEngine.UI;

public class view_background : MonoBehaviour {

    LuaEnv luaenv;

    public Action _awake;
    public Action _start;
    public Action _update;
    public Action _destroy;

    public float curTime = 0;
    public float timeInterval = 10;
    public float maxDeltaDis = 576;
    private void Awake()
    {
        luaenv = new LuaEnv();
        luaenv.Global.Set("this", this);
        luaenv.DoString("require('view_background')");

        _awake = luaenv.Global.Get<Action>("Awake");
        _start = luaenv.Global.Get<Action>("Start");
        _update = luaenv.Global.Get<Action>("Update");
        _destroy = luaenv.Global.Get<Action>("Destroy");

        if (null != _awake)
        {
            _awake();
        }
    }

    // Use this for initialization
    void Start()
    {

        if (null != _start)
        {
            _start();
        }
    }

    // Update is called once per frame
    void Update()
    {

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
