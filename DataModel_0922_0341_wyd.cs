// 代码生成时间: 2025-09-22 03:41:55
using System;
using UnityEngine;

// 数据模型类
public class DataModel
{
    // 私有字段
    private string _id;
    private string _name;
    private int _age;

    // 构造函数
    public DataModel(string id, string name, int age)
    {
        if (string.IsNullOrEmpty(id))
        {
            throw new ArgumentException("ID不能为空", nameof(id));
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("姓名不能为空", nameof(name));
        }
        if (age <= 0)
        {
            throw new ArgumentException("年龄必须大于0", nameof(age));
        }

        _id = id;
        _name = name;
        _age = age;
    }

    // ID属性
    public string ID
    {
        get { return _id; }
        private set { _id = value; }
    }

    // 名称属性
    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("姓名不能为空", nameof(value));
            }
            _name = value;
        }
    }

    // 年龄属性
    public int Age
    {
        get { return _age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("年龄必须大于0", nameof(value));
            }
            _age = value;
        }
    }

    // 打印信息方法
    public void PrintInfo()
    {
        Debug.Log($"ID: {ID}, 姓名: {Name}, 年龄: {Age}");
    }
}
