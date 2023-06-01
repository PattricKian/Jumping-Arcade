using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string sceneName = "Level2"; // Name of the scene to load
    [SerializeField] private AudioSource winSoundEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winSoundEffect.Play();
            SceneManager.LoadScene(sceneName);
        }
        
    }
}