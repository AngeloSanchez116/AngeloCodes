using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypeWritereffect : MonoBehaviour
{
    [SerializeField]
    private int typewriterspeed;
    public void Run(string textToType, TextMeshProUGUI textLabel) {

        StartCoroutine(TypeText(textToType,textLabel));
    }

    private IEnumerator TypeText(string textToType, TextMeshProUGUI textLabel) {

        
        float t = 0;
        int charIndex = 0;
        textLabel.text = string.Empty;
        GetComponent<GamePlayTutorial>().holdUntoTextIsDone = false;

        while (charIndex < textToType.Length) {

            t += Time.deltaTime * typewriterspeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex,0,textToType.Length);

            textLabel.text = textToType.Substring(0,charIndex);
            yield return null;
        }

        if (charIndex == textToType.Length) {

            GetComponent<GamePlayTutorial>().holdUntoTextIsDone = true;
        }

        textLabel.text = textToType;
    }
}
