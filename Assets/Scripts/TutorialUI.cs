using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public Canvas tutorialCanvas;


    private void OnTriggerExit(Collider other)
    {
        tutorialCanvas.enabled = false;
    }
}
