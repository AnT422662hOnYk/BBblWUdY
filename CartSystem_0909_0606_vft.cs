// 代码生成时间: 2025-09-09 06:06:21
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 购物车系统中的一个商品项
/// </summary>
public class CartItem
{
    public string ProductId { get; private set; }
    public string ProductName { get; private set; }
    public float Price { get; private set; }
    public int Quantity { get; private set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="productId">商品ID</param>
    /// <param name="productName">商品名称</param>
    /// <param name="price">商品价格</param>
    /// <param name="quantity">商品数量</param>
    public CartItem(string productId, string productName, float price, int quantity)
    {
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }
}

/// <summary>
/// 购物车类，用于管理购物车中的商品项
/// </summary>
public class ShoppingCart
{
    private List<CartItem> items;

    /// <summary>
    /// 构造函数
    /// </summary>
    public ShoppingCart()
    {
        items = new List<CartItem>();
    }

    /// <summary>
    /// 添加商品到购物车
    /// </summary>
    /// <param name="item">要添加的商品项</param>
    public void AddItem(CartItem item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        var existingItem = items.Find(i => i.ProductId == item.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            items.Add(item);
        }
    }

    /// <summary>
    /// 从购物车中移除商品
    /// </summary>
    /// <param name="productId">要移除的商品ID</param>
    public void RemoveItem(string productId)
    {
        if (string.IsNullOrEmpty(productId))
            throw new ArgumentException("Product ID cannot be null or empty.", nameof(productId));

        var item = items.Find(i => i.ProductId == productId);
        if (item != null)
        {
            items.Remove(item);
        }
        else
        {
            Debug.LogWarning($"No item found with product ID: {productId}");
        }
    }

    /// <summary>
    /// 更新购物车中商品的数量
    /// </summary>
    /// <param name="productId">商品ID</param>
    /// <param name="newQuantity">新的数量</param>
    public void UpdateQuantity(string productId, int newQuantity)
    {
        if (string.IsNullOrEmpty(productId))
            throw new ArgumentException("Product ID cannot be null or empty.", nameof(productId));

        var item = items.Find(i => i.ProductId == productId);
        if (item != null)
        {
            item.Quantity = newQuantity;
        }
        else
        {
            Debug.LogWarning($"No item found with product ID: {productId}");
        }
    }

    /// <summary>
    /// 获取购物车中的所有商品项
    /// </summary>
    /// <returns>商品项列表</returns>
    public List<CartItem> GetAllItems()
    {
        return new List<CartItem>(items);
    }

    /// <summary>
    /// 清空购物车
    /// </summary>
    public void Clear()
    {
        items.Clear();
    }
}
