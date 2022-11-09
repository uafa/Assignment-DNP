﻿using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{
    private const string filePath = "data.json";

    private DataContainer? dataContainer;

    public ICollection<Post> Posts
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Users;
        }
    }
    
    
    public ICollection<Comment> Comments
    {
        get
        {
            LazyLoadData();
            return dataContainer!.Comments;
        }
    }

    private void LazyLoadData()
    {
        if (dataContainer == null)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        string content = File.ReadAllText(filePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer);
        File.WriteAllText(filePath, serialized);
        dataContainer = null;
    }
}