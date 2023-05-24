using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SaveButton : MonoBehaviour
{
    [SerializeField] public GameObject targetObject { set; get; }
    private Button btn;
    public GameObject[] FurnitureDatas;
    public string path;

    // Start is called before the first frame update
    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "database.json");

        btn = GetComponent<Button>();
        btn.onClick.AddListener(JsonSave);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class SaveData
    {
        public SaveItem[] saveItems;
    }

    void JsonSave()
    {
        StartCoroutine(JsonSaveCoroutine());
        /*SaveData saveData = new SaveData();
        saveData.saveItems = new SaveItem[FurnitureDatas.Length];

        FurnitureDatas = GameObject.FindGameObjectsWithTag("Furniture");

        for (int i = 0; i < FurnitureDatas.Length; i++)
        {
            SaveItem item = new SaveItem();

            item.itemPrefab = FurnitureDatas[i];
            item.name = FurnitureDatas[i].name[..^7];
            item.position = FurnitureDatas[i].transform.position;
            item.scale = FurnitureDatas[i].transform.localScale;
            item.rotation = FurnitureDatas[i].transform.rotation;

            saveData.saveItems[i] = item;
        }


        string json = JsonUtility.ToJson(saveData, true);

        Debug.Log("JSON " + json);
        File.WriteAllText(path, json);*/
    }

    IEnumerator JsonSaveCoroutine()
    {
        SaveData saveData = new SaveData();
        saveData.saveItems = new SaveItem[FurnitureDatas.Length];

        FurnitureDatas = GameObject.FindGameObjectsWithTag("Furniture");
        
        for (int i = 0; i < FurnitureDatas.Length; i++)
        {
            SaveItem item = new SaveItem();

            item.itemPrefab = FurnitureDatas[i];
            item.name = FurnitureDatas[i].name[..^7];
            item.position = FurnitureDatas[i].transform.position;
            item.scale = FurnitureDatas[i].transform.localScale;
            item.rotation = FurnitureDatas[i].transform.rotation;

            saveData.saveItems[i] = item;
        }

        string json = JsonUtility.ToJson(saveData, true);

        //Debug.Log("JSON " + json);
        File.WriteAllText(path, json);

        //string url = "http://localhost:8080/home";
        string url = "http://172.20.10.5:8080/home";
        // UnityWebRequest를 생성하고 JSON 데이터를 전송합니다.
        UnityWebRequest request = UnityWebRequest.Post(url, json);

        Debug.Log("request : " + request);
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log(json);
        Debug.Log("request : " + request);

        // 요청을 보내고 요청 완료를 기다립니다.
        yield return request.SendWebRequest();

        // 요청이 완료되면 결과를 확인합니다.
        if (request.result == UnityWebRequest.Result.Success)
        {
            string id = request.downloadHandler.text;
            Debug.Log("POST 성공! ID: " + id);
            //ResponseData response = JsonUtility.FromJson<ResponseData>(id);

            //if (response != null)
            //{
            //string id = response.code;
            //Debug.Log("POST 성공! ID: ");
            //}
        }
        else
        {
            Debug.Log("POST 실패: " + request.error);
        }
    }
}
