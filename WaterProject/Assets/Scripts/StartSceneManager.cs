using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public float transitionTime = 10.0f;
    public int counter = 0;

    [HideInInspector]
    public AudioSource audio1;
    [HideInInspector]
    public AudioSource audio2;

    public GameObject canvas;

    public float AudioTimer;

    public void Awake()
    {
        FindObjectOfType<AudioManager>().Play("StartMenu");
        audio1 = FindObjectOfType<AudioManager>().sounds[0].source;
        audio2 = FindObjectOfType<AudioManager>().sounds[1].source;
        audio2.volume = 0f;
        AudioTimer = audio1.clip.length - 2.0f;
        Invoke("ChangeSongs", AudioTimer);
    }

    public void OnStartButton()
    {
        StartCoroutine(FadeMusic(0.1f, 0.1f, 0.1f));
        //StartCoroutine(Transition(canvas.GetComponent<CanvasGroup>().alpha, 0.1f, 0.1f));

        Invoke("LoadNextScene", transitionTime);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator FadeMusic(float TimeInterval, float AudioValueInterval, float UIValueInterval)
    {
        for( float i = 1f; i > 0.0f; i -= 0.1f)
        {
            audio1.volume -= AudioValueInterval;
            audio2.volume -= AudioValueInterval;
            canvas.GetComponent<CanvasGroup>().alpha -= UIValueInterval;
            yield return new WaitForSeconds(TimeInterval);
        }
    }
    

   /* IEnumerator Transition(float x, float y, float z)
    {
        for(float i = 1f; i > 0.0f; i -= z)
        {
            x = i;
            yield return new WaitForSeconds(y);
        }
    }
   */

    public void ChangeSongs()
    {
        FindObjectOfType<AudioManager>().Play("StartMenuCon");
        StartCoroutine(CrossFadeAudio());
    }

    IEnumerator CrossFadeAudio()
    {
        for (float i = 0f; i < 1f; i += 0.1f)
        {
            audio1.volume -= 0.075f;
            audio2.volume += 0.075f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
