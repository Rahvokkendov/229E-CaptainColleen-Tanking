using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Credits");
    }

    
}
