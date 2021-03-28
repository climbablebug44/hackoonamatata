using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class typingComponent : MonoBehaviour
{
    public TMP_Text textComponent;
    public TMP_Text matchComponent;

    string text;

    // Start is called before the first frame update
    void Start()
    {
        text = "";
    }

    string generateRandom()
    {
        var chars = "abcdefghijklmnopqrstuvwxyz0123456789;'/.,[] ";
        var stringChars = new char[20];
        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[Random.Range(0,chars.Length-1)];
        }

        return new string(stringChars);
    }

    public void ResetText()
    {
        textComponent.text = "";
        matchComponent.text = generateRandom();
    }

    private void OnGUI()
    {
        if (Event.current.isKey && Event.current.type == EventType.KeyDown)
        {
            if ((int)Event.current.keyCode >= 32)
                text += (char)((int)Event.current.keyCode);
            else if (Event.current.keyCode == KeyCode.Backspace)
            {
                text = text.Remove(text.Length - 1, 1);
            }
            else if (Event.current.keyCode == KeyCode.Return)
                text += '\n';
        }
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = text + "_";
    }

    public float calculateScore()
    {
        string player = textComponent.text, compare = matchComponent.text;
        if (compare.Length == 0)
            return 1.0f;
        int minl = Mathf.Min(player.Length, compare.Length);
        float total = 0f;
        for(int i=0;i<minl;i++)
        {
            if (player[i] == compare[i])
                total += 1.0f;
        }

        return total/compare.Length;
    }

}
