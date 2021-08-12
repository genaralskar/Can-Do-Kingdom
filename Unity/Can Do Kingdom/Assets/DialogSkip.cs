using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSkip : MonoBehaviour
{
    [SerializeField] private TextAnimatorPlayer player;

    [SerializeField] private string inputName = "Jump";

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            player.SkipTypewriter();
        }
    }
}
