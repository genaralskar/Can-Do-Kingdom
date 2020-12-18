using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBubbleCrowd : MonoBehaviour
{
    public Transform location;
    public TextMeshPro dialogText;

    public void SetText(string newText)
    {
        dialogText.text = newText;
    }
}
