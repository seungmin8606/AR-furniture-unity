﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DataHandler : MonoBehaviour
{
    [SerializeField]private GameObject furniture;
    
    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> _items;
    [SerializeField] private FurnitureData furnitureData;
    [SerializeField] private String label;
    
    private int id = 0;
    
    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
        
    }
    
    private async void Start()
    {
        _items = new List<Item>();
        //LoadItems();
        await Get(label);
        //CreateButtons();
    }

    private void Update()
    {

    }

    // void LoadItems()
    // {
    //     var items_obj =Resources.LoadAll("Items",typeof(Item));
    //     foreach (var item in items_obj)
    //     {
    //         _items.Add(item as Item);
    //     }
    //     
    // }

    public void SetFurinute(int id)
    {
        furniture = _items[id].itemPrefab;
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }

/*    public void LogFurnitureData()
    {
        foreach (FurnitureData furnitureData in _items)
        {
            Debug.Log("Furniture ID: " + furnitureData.id);
            Debug.Log("Position: " + furnitureData.position);
            Debug.Log("Scale: " + furnitureData.scale);
            Debug.Log("Rotation: " + furnitureData.rotation.eulerAngles);
        }
    }*/

    public async Task Get(String label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            _items.Add(obj);
        }
    }
}
