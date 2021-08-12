using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogSplitter : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;

    public static UnityAction<string> DialogNameSplit;
    public static UnityAction<string> DialogSplit;
    public void SplitDialog(string dialog)
    {

        //replace *( with {
        string newDialog = dialog.Replace("*(", "{");

        //replace *) with }
        newDialog = newDialog.Replace("*)", "}");

        string nText = "";
        string dText = newDialog;

        string[] stringSeparators = new string[] { ":: " };
        string[] split = newDialog.Split(stringSeparators, System.StringSplitOptions.None);
        if (split.Length > 1)
        {
            nText = split[0];
            dText = split[1];
        }

        nameText.text = nText;
        DialogNameSplit?.Invoke(nText);
        dialogText.text = dText;
    }
}
