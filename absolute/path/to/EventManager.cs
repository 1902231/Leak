using UnityEngine;
using System;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    // 单例模式
    public static EventManager Instance { get; private set; }
    
    // 事件字典，用于存储不同类型的事件
    private Dictionary<string, Action<object[]>> eventDictionary;

    private void Awake()
    {
        // 确保只有一个EventManager实例
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            eventDictionary = new Dictionary<string, Action<object[]>>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 注册事件监听
    public static void StartListening(string eventName, Action<object[]> listener)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out Action<object[]> thisEvent))
        {
            thisEvent += listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            Instance.eventDictionary.Add(eventName, listener);
        }
    }

    // 取消事件监听
    public static void StopListening(string eventName, Action<object[]> listener)
    {
        if (Instance != null && Instance.eventDictionary.TryGetValue(eventName, out Action<object[]> thisEvent))
        {
            thisEvent -= listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
    }

    // 触发事件
    public static void TriggerEvent(string eventName, params object[] parameters)
    {
        if (Instance != null && Instance.eventDictionary.TryGetValue(eventName, out Action<object[]> thisEvent))
        {
            thisEvent?.Invoke(parameters);
        }
    }
}

