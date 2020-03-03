using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject movementText;
    public GameObject interactText;
    public GameObject craftingText;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        StartCoroutine("WaitForMovement");
        // Invoke("ActivateMovementText", GameSettings.tutorialDelay * 0);
        // Invoke("DeactivateMovementText", GameSettings.tutorialDelay * 1);
        // Invoke("ActivateInteractText", GameSettings.tutorialDelay * 2);
        // Invoke("DeactivateInteractText", GameSettings.tutorialDelay * 3);
        // Invoke("ActivateCraftingText", GameSettings.tutorialDelay * 4);
        // Invoke("DeactivateCraftingText", GameSettings.tutorialDelay * 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActivateMovementText()
    {
        movementText.SetActive(true);
    }

    private void DeactivateMovementText()
    {
        movementText.SetActive(false);
    }

    private void ActivateInteractText()
    {
        interactText.SetActive(true);
    }

    private void DeactivateInteractText()
    {
        interactText.SetActive(false);
    }

    private void ActivateCraftingText()
    {
        craftingText.SetActive(true);
    }

    private void DeactivateCraftingText()
    {
        craftingText.SetActive(false);
    }

    IEnumerator WaitForMovement()
    {
        ActivateMovementText();
        while (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) &&
               !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D)) {
            yield return null;
        }
        DeactivateMovementText();
        StartCoroutine("WaitForInteraction");
    }

    IEnumerator WaitForInteraction()
    {
        ActivateInteractText();
        while (!Input.GetKeyDown(KeyCode.Space)) {
            yield return null;
        }
        DeactivateInteractText();
        StartCoroutine("WaitForClick");
    }

    IEnumerator WaitForClick()
    {
        ActivateCraftingText();
        
        yield return new WaitForSeconds(GameSettings.tutorialDelay);
        DeactivateCraftingText();
    }
}
