using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> originalWords = new List<string>()
    {
        "private", "float", "playerheight", "void", "movedir", "if", "vector", "deltatime", "return", "update", "else", "iswalking", "slerp", "normalized", "enable", "awake", "class", "input", "true", "keycode", "getkey", "audiosource", "public", "using", "false", "const", "animator", "setbool", "string", "debug", "raycast", "spriteatlas", "cinematics", "walkable", "fbx", "spotlight", "import", "texture", "fixedupdate", "layer", "textmeshpro", "tilemap", "render",  "console", "hierarchy", "layout", "assetstore", "parameters"
};

    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConverToLower(workingWords);

    }

    private void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
        
    }

    private void ConverToLower(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
            list[i] = list[i].ToLower();

    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }

        return newWord;
    }
}
