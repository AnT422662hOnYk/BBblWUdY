// 代码生成时间: 2025-08-02 14:31:29
using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 消息通知系统，用于在游戏中发送和接收消息
/// </summary>
public class MessageNotificationSystem : MonoBehaviour
{
    // 用于存储订阅的消息和相应的回调方法
    private Dictionary<string, UnityEvent> messageListeners = new Dictionary<string, UnityEvent>();

    /// <summary>
    /// 注册消息监听器
    /// </summary>
    /// <param name="message">消息名称</param>
    /// <param name="action">当消息发出时执行的方法</param>
    public void RegisterListener(string message, UnityAction action)
    {
        if (!messageListeners.ContainsKey(message))
        {
            messageListeners[message] = new UnityEvent();
        }

        messageListeners[message].AddListener(action);
    }

    /// <summary>
    /// 注销消息监听器
    /// </summary>
    /// <param name="message">消息名称</param>
    /// <param name="action">要注销的方法</param>
    public void UnregisterListener(string message, UnityAction action)
    {
        if (messageListeners.ContainsKey(message))
        {
            messageListeners[message].RemoveListener(action);
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="message">消息名称</param>
    public void SendMessage(string message)
    {
        if (messageListeners.ContainsKey(message))
        {
            messageListeners[message].Invoke();
        }
        else
        {
            Debug.LogError($"No listeners found for message: '{message}'");
        }
    }

    // 在对象被销毁时清理事件
    private void OnDestroy()
    {
        foreach (var listener in messageListeners.Values)
        {
            listener.RemoveAllListeners();
        }
    }
}
