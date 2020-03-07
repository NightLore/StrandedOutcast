using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject movementText;
    public GameObject interactText;
    public GameObject craftingText;
    public GameObject harvestText;
    public GameObject forgeText;
    public GameObject boatText;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        StartCoroutine("WaitForMovement");
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

    private void ActivateHarvestText()
    {
        harvestText.SetActive(true);
    }

    private void DeactivateHarvestText()
    {
        harvestText.SetActive(false);
    }

    private void ActivateForgeText()
    {
        forgeText.SetActive(true);
    }

    private void DeactivateForgeText()
    {
        forgeText.SetActive(false);
    }

    private void ActivateBoatText()
    {
        boatText.SetActive(true);
    }

    private void DeactivateBoatText()
    {
        boatText.SetActive(false);
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
        StartCoroutine("CategoriesClickable");
    }

    IEnumerator CategoriesClickable()
    {
        ActivateCraftingText();
        yield return new WaitForSeconds(GameSettings.tutorialDelay);
        DeactivateCraftingText();
        StartCoroutine("AxeAndPick");
    }

    IEnumerator AxeAndPick()
    {
        ActivateHarvestText();
        yield return new WaitForSeconds(GameSettings.tutorialDelay * 2);
        DeactivateHarvestText();
        StartCoroutine("ForgeFunction");
    }

    IEnumerator ForgeFunction()
    {
        ActivateForgeText();
        yield return new WaitForSeconds(GameSettings.tutorialDelay);
        DeactivateForgeText();
        StartCoroutine("BoatWin");
    }

    IEnumerator BoatWin()
    {
        ActivateBoatText();
        yield return new WaitForSeconds(GameSettings.tutorialDelay);
        DeactivateBoatText();
    }
}
