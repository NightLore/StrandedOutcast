using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoldBlinkText : MonoBehaviour
{
    public Color blinkColor;
    private Color normalColor;

    private TextMeshProUGUI text;
    private bool blinking;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        blinking = false;
        normalColor = text.color;
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
                text.color = normalColor;
            }
            else
            {
                text.fontStyle = FontStyles.Bold;
                text.color = blinkColor;
            }
            isBolded = !isBolded;
            yield return new WaitForSeconds(GameSettings.blinkTextDelay);
            timer += GameSettings.blinkTextDelay;
        }
        text.fontStyle = FontStyles.Normal;
        text.color = normalColor;
        blinking = false;
    }
}
