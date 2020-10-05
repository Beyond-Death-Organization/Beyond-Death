using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [HideInInspector] public Transform cam;
    public TextMeshProUGUI dialogBoxText;
    public GameObject dialogBox;
    public List<string> textSplit;
    public List<float> timeSplit;
    public bool isStart = false;
    public float beginTime = -1;
    private int trackDialog = 0;
    public string text;
    private bool bob = true;
    private void Start()
    {
        timeSplit = new List<float>();
        textSplit = new List<string>();
        ChangeDialogBoxText(text);
    }
    

    void Update()
    {
        if(bob)
            beginTime = Time.time;
        bob = false;
        dialogBoxText.text = textSplit[trackDialog];
        if (timeSplit.Count > trackDialog)
        {
            if (Time.time >= timeSplit[trackDialog] + beginTime)
            {
                trackDialog++;
                dialogBoxText.text = textSplit[trackDialog];
            }
        }
    }

    public void ChangeDialogBoxText(string text)
    {
        if (String.Equals(text, ""))
        {
            return;
        }

        timeSplit.Clear();
        textSplit.Clear();
        string[] textParse = Regex.Split(text, @"<t>|</t>");

        foreach (var textPiece in textParse)
        {
            if (Regex.IsMatch(textPiece, @"^(\(?\+?[0-9]*\)?)?[0-9.,_\- \(\)]*$"))
            {
                string tmp = Regex.Replace(textPiece, " ", "");
                tmp = Regex.Replace(tmp, "[.]", ",");
                if (float.TryParse(tmp, out var floatTmp))
                    timeSplit.Add(floatTmp);
                else
                    Debug.Log("Please verify balise syntax for notification bar");
            }
            else
            {
                textSplit.Add(textPiece);
            }

        }

        if (textSplit.Count - 1 != timeSplit.Count || textSplit.Count == 0)
        {
            Debug.Log("Please verify balise syntax for notification bar");
            return;
        }

        
    }
}
