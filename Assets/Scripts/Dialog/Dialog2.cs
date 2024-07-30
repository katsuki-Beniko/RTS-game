using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class Dialog2 : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueLine
    {
        public Character character;
        public string text;
    }

    public TextMeshProUGUI textComponent;
    public DialogueLine[] lines;
    public RawImage characterDisplay;
    public float textSpeed;  // Time between characters when typing
    public float displayDuration;  // How long to display text before moving to next line
    public PlayableDirector playableDirector;
    public CharacterImagesScriptableObject characterImagesSO;

    private Dictionary<Character, Texture> characterImages;
    private int index;
    private bool allowTimelineToPlay = false;
    private float timeSinceDisplayed = 0f;  // Timer to track display duration

    void Start()
    {
        playableDirector.Pause();
        allowTimelineToPlay = false;
        characterImages = characterImagesSO.GetDictionary();
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (index >= lines.Length)
        {
            Debug.LogError("Index is out of range. No more dialogue lines to display.");
            return; // Stop the update method if index is out of bounds
        }

        // Ensure the textComponent and the current line's text are not null
        if (textComponent == null)
        {
            Debug.LogError("Text Component is null.");
            return;
        }

        if (lines[index].text == null)
        {
            Debug.LogError("Dialogue line text at index " + index + " is null.");
            return;
        }
        // Update the timer if there is text displayed
        if (textComponent.text == lines[index].text)
        {
            timeSinceDisplayed += Time.deltaTime;
            if (timeSinceDisplayed >= displayDuration)
            {
                NextLine();
            }
        }
    }

    public void NextLineButton()
    {
        // Allow manual override to skip to the next line
        NextLine();
    }

    void StartDialogue()
    {
        index = 7;
        SetCharacterImage(lines[index].character);
        StartCoroutine(TypeLine());
        timeSinceDisplayed = 0f;  // Reset timer when starting new dialogue
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].text.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            SetCharacterImage(lines[index].character);
            StartCoroutine(TypeLine());
            timeSinceDisplayed = 0f;  // Reset the timer after displaying a line
        }
        else
        {
            EndDialogue();
        }
    }

    void SetCharacterImage(Character character)
    {
        Texture characterTexture = characterImages[character];
        characterDisplay.texture = characterTexture;
        characterDisplay.gameObject.SetActive(true);
    }

    public void EndDialogue()
    {
        gameObject.SetActive(false);
        allowTimelineToPlay = true;

    }
}
