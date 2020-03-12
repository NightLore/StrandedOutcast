using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBoundaries : MonoBehaviour
{
    public GameObject boundaryText;
    
    private bool beenDisplayed = false;
    // Start is called before the first frame update
    private void Update() {

    }
    
    void DeactivateBoundaryText() {
        boundaryText.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !beenDisplayed
            && GameSettings.tutorialFinished)
        {
            boundaryText.SetActive(true);
            Invoke("DeactivateBoundaryText", GameSettings.tutorialDelay);
            beenDisplayed = true;
        }
    }
}
