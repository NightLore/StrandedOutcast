using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject movementText;
    public GameObject interactText;
    public GameObject craftingText;
    public GameObject boatText;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        if (!GameSettings.tutorialFinished)
        {
            StartCoroutine("WaitForMovement");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForMovement()
    {
        movementText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.A) &&
               !Input.GetKeyDown(KeyCode.S) && !Input.GetKeyDown(KeyCode.D)) {
            yield return null;
        }
        movementText.SetActive(false);
        StartCoroutine("WaitForInteraction");
    }

    IEnumerator WaitForInteraction()
    {
        interactText.SetActive(true);
        while (!Input.GetKeyDown(KeyCode.Space)) {
            yield return null;
        }
        interactText.SetActive(false);
        StartCoroutine("CategoriesClickable");
    }

    IEnumerator CategoriesClickable()
    {
        craftingText.SetActive(true);
        yield return new WaitForSeconds(GameSettings.tutorialDelay);
        craftingText.SetActive(false);
        StartCoroutine("BoatWin");
    }

    IEnumerator BoatWin()
    {
        boatText.SetActive(true);
        yield return new WaitForSeconds(GameSettings.tutorialDelay);
        boatText.SetActive(false);
        GameSettings.tutorialFinished = true;
    }
}
