using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script handles fades 
//can fadeIn at start or fadeOut when leaving

public class FadeSprite : MonoBehaviour
{

    //store image/text + color
    SpriteRenderer thisSR;
    Color alphaValue;

    //these will be on during the fades
    public bool fadingIn, fadingOut, keepActive, fadeOutImmediately;

    //controls the speed of the fade
    public float fadeInWait, fadeOutWait, fadeInSpeed = 0.75f, fadeOutSpeed = 1f;

    void Start()
    {
        //checks privately whether this object has image or text component
        thisSR = GetComponent<SpriteRenderer>();

        //differet syntax for image and text
        alphaValue = thisSR.color;
        alphaValue.a = 0;
        thisSR.color = alphaValue;

        //automatically fadeIn at start if object has this script
        StartCoroutine(WaitToFadeIn());
    }

    void Update()
    {
        //when fadingIn, this is called every frame
        if (fadingIn)
        {
            if (alphaValue.a < 0.5f)
            {

                alphaValue.a += fadeInSpeed * Time.deltaTime;
                thisSR.color = alphaValue;
            }
            else
            {
                fadingIn = false;
                if (fadeOutImmediately)
                {
                    StartCoroutine(WaitToFadeOut());
                }
            }
        }

        //when fading out, this is called every frame and eventually turns off object
        if (fadingOut)
        {
            if (alphaValue.a > 0f)
            {

                alphaValue.a -= fadeOutSpeed * Time.deltaTime;
                thisSR.color = alphaValue;
            }
            else
            {
                fadingOut = false;
                if (!keepActive)
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }

    public IEnumerator WaitToFadeIn()
    {
        yield return new WaitForSeconds(fadeInWait);

        fadingIn = true;
    }

    public IEnumerator WaitToFadeOut()
    {
        yield return new WaitForSeconds(fadeOutWait);

        fadingOut = true;
    }
}