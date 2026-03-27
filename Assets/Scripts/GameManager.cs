using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public GameObject player;
    public Canvas deathCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.activeInHierarchy)
        {
            deathCanvas.enabled = false;
        }
        else
        {
            deathCanvas.enabled = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
