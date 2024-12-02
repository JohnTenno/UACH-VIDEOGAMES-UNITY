using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ScoreManager : MonoBehaviour
{
    [System.Serializable]
    public class Score
    {
        public int score;
        public string playerName;
    }

    private string baseUrl = "http://localhost:3000/api/turtle-game-score/";

    void Start()
    {
    }

    public void GetScores()
    {
        StartCoroutine(GetRequest(baseUrl));
    }

    private IEnumerator GetRequest(string url)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {request.error} - Código de estado: {request.responseCode}");
            }
            else
            {
                Debug.Log($"Respuesta: {request.downloadHandler.text}");
            }
        }
    }

    public void NewScore(int puntos)
    {
        Score newScore = new Score { score = puntos };
        string jsonData = JsonUtility.ToJson(newScore);
        StartCoroutine(PostRequest(baseUrl, jsonData));
    }

    private IEnumerator PostRequest(string url, string jsonData)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {request.error} - Código de estado: {request.responseCode}");
            }
            else
            {
                Debug.Log($"Respuesta: {request.downloadHandler.text}");
            }
        }
    }
}
