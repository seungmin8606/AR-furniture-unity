using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FixButtonController : MonoBehaviour
{
    [SerializeField] public GameObject targetObject { set; get; }
    private Button btn;
    private GameObject[] furnitureDatas;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(FixedFurniture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedFurniture()
    {
        targetObject = InputManager.Instance.spawnObject;
        if (targetObject.GetComponent<ItemController>().is_fixed)
        {
            targetObject.GetComponent<ItemController>().is_fixed = false;
            InputManager.Instance.FadeOut();
            furnitureDatas = GameObject.FindGameObjectsWithTag("Furniture");
            targetObject.GetComponent<Collider>().enabled = false ;
        }
        else
        {
            targetObject.GetComponent<ItemController>().is_fixed = true;
            InputManager.Instance.FadeIn();
            furnitureDatas = GameObject.FindGameObjectsWithTag("Furniture");
            targetObject.GetComponent<Collider>().enabled = true;
        }
    }
}
