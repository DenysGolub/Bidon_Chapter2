using System.Collections;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
public class WebRequestExample : MonoBehaviour
{
    public TextMeshProUGUI topicNumber_TMP;
    public TextMeshProUGUI title_TMP;
    public bool isGetRequest = true;

    public void StartRequest()
    {
        if (isGetRequest)
        {
            StartCoroutine(GetRequest());
        }
        else
        {
            StartCoroutine(PostRequest());
        }
    }
    public IEnumerator GetRequest()
    {
        string cleanedNumber = topicNumber_TMP.text.Replace("\u200B", "").Trim();
        using (UnityWebRequest webRequest = UnityWebRequest.Get($"https://jsonplaceholder.typicode.com/posts/{cleanedNumber}"))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Topic topicInfo = JsonUtility.FromJson<Topic>(webRequest.downloadHandler.text);
                Debug.Log(webRequest.downloadHandler.text);
                title_TMP.text = $"Title: {topicInfo.title}";
            }
        }
    }

    public IEnumerator PostRequest()
    {
        string cleanedNumber = topicNumber_TMP.text.Replace("\u200B", "").Trim();
        WWWForm form = new WWWForm();
        form.AddField("userId", cleanedNumber);
        form.AddField("title", "Test Title");
        using (UnityWebRequest webRequest = UnityWebRequest.Post($"https://jsonplaceholder.typicode.com/posts", form))
        {
            yield return webRequest.SendWebRequest();

            Debug.Log(webRequest.result);
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Topic topicInfo = JsonUtility.FromJson<Topic>(webRequest.downloadHandler.text);
                Debug.Log(webRequest.downloadHandler.text);
                title_TMP.text = $"Title: {topicInfo.title}";
            }
        }
    }

    public class Topic
    {
        public int userId;
        public int id;
        public string title;
        public string body;
    } 
}
