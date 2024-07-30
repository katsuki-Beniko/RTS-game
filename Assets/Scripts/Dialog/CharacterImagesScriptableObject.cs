using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterImages", menuName = "ScriptableObjects/CharacterImages", order = 1)]
public class CharacterImagesScriptableObject : ScriptableObject
{
    public List<CharacterImage> characterImages;

    [System.Serializable]
    public struct CharacterImage
    {
        public Character character;
        public Texture texture;
    }

    public Dictionary<Character, Texture> GetDictionary()
    {
        Dictionary<Character, Texture> dict = new Dictionary<Character, Texture>();
        foreach (var characterImage in characterImages)
        {
            dict.Add(characterImage.character, characterImage.texture);
        }
        return dict;
    }
}
