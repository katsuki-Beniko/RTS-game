using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.UI;
using System;

public enum Character
{
    CharacterA,
    CharacterB,
    CharacterC,
    CharacterD,
    CharacterE,
    CharacterF,
    CharacterG
}
[System.Serializable]

public class DialogueLine
{
    public Character character;  // Use enum for dropdown
    public string text;
}

public class Dialogue : MonoBehaviour
{
        public TMP_Text dialogueText; // Assign the TextMeshPro component
        public RawImage characterDisplay; // Ensure this is a RawImage component
        public List<DialogueLine> lines; // Dialogue lines
        public Dictionary<Character, Texture> characterImages; // Maps Characters to their images
        public CharacterImagesScriptableObject characterImagesSO;

    private int currentLine = 0;
        private bool isDialogueActive = false;

        void Start()
        {
            characterDisplay.gameObject.SetActive(false);
            dialogueText.gameObject.SetActive(false);
        characterImages = characterImagesSO.GetDictionary();
    }

        public void StartDialogue()
        {
            if (lines.Count == 0) return;
            currentLine = 0;
            isDialogueActive = true;
        SetCharacterImage(lines[currentLine].character);
        UpdateDialogue();
        }

        public void AdvanceDialogue()
        {
            if (!isDialogueActive) return;
           currentLine++;
              if (currentLine < lines.Count)
            {
                UpdateDialogue();
            }
            else
            {
                EndDialogue();
            }
        }

        private void UpdateDialogue()
        {
        
          dialogueText.text = lines[currentLine].text;
             SetCharacterImage(lines[currentLine].character);
            dialogueText.gameObject.SetActive(true);
        }
    void SetCharacterImage(Character character)
    {
        Texture characterTexture = characterImages[character];
        characterDisplay.texture = characterTexture;
        characterDisplay.gameObject.SetActive(true);
    }
    private void EndDialogue()
        {
            characterDisplay.gameObject.SetActive(false);
            dialogueText.gameObject.SetActive(false);
            isDialogueActive = false;
        }
    }
