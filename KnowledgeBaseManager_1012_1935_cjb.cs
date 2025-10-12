// 代码生成时间: 2025-10-12 19:35:53
using System;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeBaseManager
{
    // 知识库中的文章集合
    private Dictionary<string, string> articles = new Dictionary<string, string>();

    /**
     * 添加文章到知识库
     * @param articleId 文章的唯一标识符
     * @param content 文章的内容
     * @return 添加成功返回true，否则返回false
     */
    public bool AddArticle(string articleId, string content)
    {
        if (string.IsNullOrEmpty(articleId) || string.IsNullOrEmpty(content))
        {
            Debug.LogError("文章ID或内容不能为空");
            return false;
        }
        
        if (articles.ContainsKey(articleId))
        {
            Debug.LogError("文章ID已存在，无法添加重复的文章");
            return false;
        }
        
        articles[articleId] = content;
        Debug.Log($"文章 {articleId} 添加成功");
        return true;
    }

    /**
     * 删除知识库中的文章
     * @param articleId 文章的唯一标识符
     * @return 删除成功返回true，否则返回false
     */
    public bool RemoveArticle(string articleId)
    {
        if (string.IsNullOrEmpty(articleId))
        {
            Debug.LogError("文章ID不能为空");
            return false;
        }
        
        if (!articles.ContainsKey(articleId))
        {
            Debug.LogError($"文章ID {articleId} 不存在，无法删除");
            return false;
        }
        
        articles.Remove(articleId);
        Debug.Log($"文章 {articleId} 删除成功");
        return true;
    }

    /**
     * 修改知识库中的文章
     * @param articleId 文章的唯一标识符
     * @param newContent 新的文章内容
     * @return 修改成功返回true，否则返回false
     */
    public bool UpdateArticle(string articleId, string newContent)
    {
        if (string.IsNullOrEmpty(articleId) || string.IsNullOrEmpty(newContent))
        {
            Debug.LogError("文章ID或新内容不能为空");
            return false;
        }
        
        if (!articles.ContainsKey(articleId))
        {
            Debug.LogError($"文章ID {articleId} 不存在，无法修改");
            return false;
        }
        
        articles[articleId] = newContent;
        Debug.Log($"文章 {articleId} 修改成功");
        return true;
    }

    /**
     * 查询知识库中的文章
     * @param articleId 文章的唯一标识符
     * @return 返回文章的内容，如果文章不存在返回null
     */
    public string GetArticle(string articleId)
    {
        if (string.IsNullOrEmpty(articleId))
        {
            Debug.LogError("文章ID不能为空");
            return null;
        }
        
        if (articles.TryGetValue(articleId, out string content))
        {
            Debug.Log($"文章 {articleId} 查询成功");
            return content;
        }
        else
        {
            Debug.LogError($"文章ID {articleId} 不存在");
            return null;
        }
    }

    /**
     * 清空知识库
     * 用于测试或重置知识库状态
     */
    public void ClearKnowledgeBase()
    {
        articles.Clear();
        Debug.Log("知识库已清空");
    }
}
