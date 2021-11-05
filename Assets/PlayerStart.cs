using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour
{
    AudioSource audio;
    public AudioSource audio2, audio3;
    public Image screen;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //start game
            Debug.Log("Start");
            audio.Play();
        }
    }

    private void Update()
    {
        if(audio.time >= audio.clip.length)
        {
            Debug.Log("End");
            EndTheGame();
        }

        if(Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void EndTheGame()
    {
        Debug.Log("Fade to Black");
        StartCoroutine("FadeToBlack");
    }

    IEnumerator FadeToBlack()
    {
        for (float alpha = 0.0f; alpha < 1.1f; alpha += Time.deltaTime)
        {
            screen.color = new Color(screen.color.r, screen.color.g, screen.color.b, alpha);
            audio.volume = Mathf.Lerp(0.4f, 0, alpha);
            audio2.volume = Mathf.Lerp(0.35f, 0, alpha);
            audio3.volume = Mathf.Lerp(0.01f, 0, alpha);
            yield return null;
        }
        Debug.Log("End Ended Quit");

#if UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
            Application.Quit();
#elif UNITY_WEBGL
        SceneManager.LoadScene(0);
#endif
    }
}
