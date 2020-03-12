using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoldBlinkText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private bool blinking;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        blinking = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Blink()
    {
        if (!blinking)
        {
            StartCoroutine(BlinkBoldness(GameSettings.blinkWarningTime));
        }
    }

    IEnumerator BlinkBoldness(float seconds)
    {
        float timer = 0;
        bool isBolded = false;
        blinking = true;
        while (timer < seconds)
        {
            if (isBolded)
            {
                text.fontStyle = FontStyles.Normal;
            }
            else
            {
                text.fontStyle = FontStyles.Bold | FontStyles.Italic;
            }
            isBolded = !isBolded;
            yield return new WaitForSeconds(GameSettings.blinkTextDelay);
            timer += GameSettings.blinkTextDelay;
        }
        text.fontStyle = FontStyles.Normal;
        blinking = false;
    }
}
