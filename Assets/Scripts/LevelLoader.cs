using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
   


    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");  
    }





    public void LoadLevel1()
    {
        SceneManager.LoadScene("NewScene");
    }

  

}

