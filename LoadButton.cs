using System.IO;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadButton : MonoBehaviour
{
    private Button btn;
    public string path;
    private TouchScreenKeyboard keyboard;
    private string inputText;

    // Start is called before the first frame update
    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "database.json");

        btn = GetComponent<Button>();
        btn.onClick.AddListener(JsonLoad);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public class SaveData
    {
        public SaveItem[] saveItems;
    }

    void JsonLoad()
    {
        //StartCoroutine(JsonLoadCoroutine());
        // 터치 또는 마우스 입력으로 키보드 열기
/*        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (keyboard == null || !keyboard.active)
            {
                // 키보드 열기
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            }
        }

        // 키보드 입력 처리
        if (keyboard != null && keyboard.active)
        {
            if (keyboard.status == TouchScreenKeyboard.Status.Done || keyboard.status == TouchScreenKeyboard.Status.Canceled)
            {
                // 키보드 입력이 완료되었거나 취소되었을 때 처리
                inputText = keyboard.text;
                Debug.Log("입력된 inputText: " + inputText);
                Debug.Log("입력된 keyboard.text: " + keyboard.text);
                // 키보드 객체 해제
                keyboard = null;
            }
        }
        Debug.Log("입력된 inputText: " + inputText);*/
        /*if (File.Exists(path))
        {
            // JSON 파일 읽기
            string json = File.ReadAllText(path);

            // JSON 데이터 파싱
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            // 가구 배치
            foreach (SaveItem item in saveData.saveItems)
            {
                string p_path = "Prefab/" + item.name;

                GameObject prefab = Resources.Load<GameObject>(p_path);

                if (prefab == null)
                {
                    Debug.Log($"Failed to load prefab : {p_path}");
                }

                GameObject furniture = Instantiate(prefab, item.position, item.rotation);
                //furniture.name = item.name;
                furniture.transform.localScale = item.scale;
            }
        }
        else
        {
            Debug.LogError("JSON 파일이 존재하지 않습니다.");
        }*/
    }
    /*IEnumerator JsonLoadCoroutine()
    {
        // 터치 또는 마우스 입력으로 키보드 열기
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (keyboard == null || !keyboard.active)
            {
                // 키보드 열기
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            }
        }

        // 키보드 입력 처리
        if (keyboard != null && keyboard.active)
        {
            if (keyboard.status == TouchScreenKeyboard.Status.Done || keyboard.status == TouchScreenKeyboard.Status.Canceled)
            {
                // 키보드 입력이 완료되었거나 취소되었을 때 처리
                string inputText = keyboard.text;
                Debug.Log("입력된 텍스트: " + inputText);

                // 키보드 객체 해제
                keyboard = null;
            }
        }

        string url = "http://localhost:8080/home/furniture/" + keyboard;

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("Content-Type", "application/json");

        // 요청을 보내고 요청 완료를 기다립니다.
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;
            Debug.Log("Received JSON: " + json);

            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            if (saveData != null && saveData.saveItems != null)
            {
                foreach (SaveItem item in saveData.saveItems)
                {
                    string p_path = "Prefab/" + item.name;

                    GameObject prefab = Resources.Load<GameObject>(p_path);

                    if (prefab == null)
                    {
                        Debug.Log($"Failed to load prefab : {p_path}");
                    }
                    else
                    {
                        GameObject furniture = Instantiate(prefab, item.position, item.rotation);
                        furniture.name = item.name;
                        furniture.transform.localScale = item.scale;
                    }
                }
                Debug.Log("Furniture placement completed.");
            }
            else
            {
                Debug.Log("Invalid JSON data.");
            }
        }
        else
        {
            Debug.Log("GET request failed: " + request.error);
        }
    }*/
}