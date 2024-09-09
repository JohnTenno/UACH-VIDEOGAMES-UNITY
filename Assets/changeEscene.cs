using UnityEngine;
using UnityEngine.SceneManagement;

public class changeEscene : MonoBehaviour
{
    public string levelName;

    public void changeEscenes()
    {
        SceneManager.LoadScene(levelName);
    }

}
