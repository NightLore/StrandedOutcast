using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoundaries : MonoBehaviour
{
    public GameObject boundaryText;
    
    private bool beenDisplayed = false;
    private bool normalTutorialFinished = false;
    // Start is called before the first frame update
    private void Update() {
        normalTutorialFinished = GameSettings.tutorialFinished;
    }
    
    void ActivateBoundaryText() {
        boundaryText.SetActive(true);
    }

    void DeactivateBoundaryText() {
        boundaryText.SetActive(false);
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !beenDisplayed
            && normalTutorialFinished) {
            Debug.Log("Entered Tutorial Boundary");
            ActivateBoundaryText();
            Invoke("DeactivateBoundaryText", GameSettings.tutorialDelay);
            beenDisplayed = true;
        }
    }
}
