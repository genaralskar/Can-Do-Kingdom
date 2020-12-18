using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSplitter : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public void SplitDialog(string dialog)
    {
        string nText = "";
        string dText = dialog;

        string[] stringSeparators = new string[] { ":: " };
        string[] split = dialog.Split(stringSeparators, System.StringSplitOptions.None);
        if (split.Length > 1)
        {
            nText = split[0];
            dText = split[1];
        }

        nameText.text = nText;
        dialogText.text = dText;
    }
}
