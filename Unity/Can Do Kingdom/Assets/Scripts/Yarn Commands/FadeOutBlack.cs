using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutBlack : BlockingCommand
{
    [SerializeField]
    private Image fadeOutImage;

    protected override void Command(string[] parameters, System.Action onComplete)
    {
        float time = float.Parse(parameters[1]);

        StopAllCoroutines();
        StartCoroutine(Fade(time, onComplete));
    }

    private IEnumerator Fade(float time, System.Action onComplete)
    {
        float timer = 0;
        WaitForEndOfFrame wait = new WaitForEndOfFrame();
        fadeOutImage.gameObject.SetActive(true);
        while (timer < time)
        {
            timer += Time.deltaTime;
            //get color
            Color c = fadeOutImage.color;
            //change a value
            c.a = timer / time;
            //set color
            fadeOutImage.color = c;

            yield return wait;
        }
        //fadeOutImage.gameObject.SetActive(false);

        onComplete?.Invoke();
    }
}
