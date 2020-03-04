﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class textParser : MonoBehaviour
{


    struct DialogueLine
    {
        public string name;
        public string content;
        public string[] options;

        public DialogueLine(string Name, string Content)
        {
            name = Name;
            content = Content;
            options = new string[0];
        }
    }

    List<DialogueLine> lines;

    // Start is called before the first frame update
    void Start()
    {
        string file = "Assets/VRScripts/princeDialogue.txt";
        lines = new List<DialogueLine>();
        LoadDialogue(file);

    }

    void LoadDialogue(string filename)
    {
        string line;
        StreamReader r = new StreamReader(filename);

        using (r)
        {
           do
            {
                line = r.ReadLine();
                if (line != null)
                {
                    string[] lineData = line.Split(':');
                    if (lineData [0] == "Player") {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], "");
                        lineEntry.options = new string[lineData.Length - 1];
                        for (int i = 1; i < lineData.Length; i++)
                        {
                            lineEntry.options[i - 1] = lineData[i];
                        }
                        lines.Add(lineEntry);
                    }
                    else
                    {
                        DialogueLine lineEntry = new DialogueLine(lineData[0], lineData[1]);
                        lines.Add(lineEntry);
                    }
                }
            }
            while (line != null);
            r.Close();
        }
            }

    public string GetName(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].name;
        }
        return "";
    }

    public string GetContent(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].content;
        }
        return "";
    }

    public string[] GetOptions(int lineNumber)
    {
        if (lineNumber < lines.Count)
        {
            return lines[lineNumber].options;
        }
        return new string[0];
    }



}
