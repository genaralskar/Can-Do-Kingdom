using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInBlack : BlockingCommand
{
    [SerializeField]
    private Image fadeInImage;

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
        fadeInImage.gameObject.SetActive(true);
        while (timer < time)
        {
            timer += Time.deltaTime;
            //get color
            Color c = fadeInImage.color;
            //change a value
            c.a = 1 - (timer / time);
            //set color
            fadeInImage.color = c;

            yield return wait;
        }
        fadeInImage.gameObject.SetActive(false);
        onComplete?.Invoke();
    }
}
