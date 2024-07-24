using UnityEngine;
using TMPro;  // Import TextMeshPro namespace
using System.Collections;

public class TextDisplayTMP : MonoBehaviour
{
    public TextMeshProUGUI messageText;  // Reference to the TextMeshProUGUI component
    public float displayDuration = 3f;  // Duration to display each message
    public float fadeDuration = 1f;  // Duration to fade out the text
    public string[] messages;  // Array of messages to display

    void Start()
    {
        // Start the coroutine to display messages
        StartCoroutine(DisplayMessages());
    }

    private IEnumerator DisplayMessages()
    {
        foreach (string message in messages)
        {
            messageText.text = message;
            yield return new WaitForSeconds(displayDuration);
        }

        // Fade out the text
        yield return StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutText()
    {
        Color originalColor = messageText.color;
        for (float t = 0.01f; t < fadeDuration; t += Time.deltaTime)
        {
            messageText.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeDuration));
            yield return null;
        }
        messageText.text = string.Empty;
    }
}
