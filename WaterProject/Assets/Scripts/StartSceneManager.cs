using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public float transitionTime = 5.0f;
    public float transitionTime2 = 0.02f;
    public int counter = 0;

    [HideInInspector]
    public AudioSource audio1;
    [HideInInspector]
    public AudioSource audio2;

    public GameObject canvas;

    public void Awake()
    {
        FindObjectOfType<AudioManager>().Play("StartMenu");
        audio1 = FindObjectOfType<AudioManager>().sounds[0].source;
        audio2 = FindObjectOfType<AudioManager>().sounds[1].source;
    }

    public void Update()
    {
        if(!audio1.isPlaying && counter == 0)
        {
            FindObjectOfType<AudioManager>().Play("StartMenuCon");
            counter++;
        }
    }
    public void OnStartButton()
    {
        Transition();
        FadeMusic();

        Invoke("LoadNextScene", transitionTime);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Transition()
    {
        if(canvas.GetComponent<CanvasGroup>().alpha > 0.0f)
        {
            canvas.GetComponent<CanvasGroup>().alpha -= .1f;
        }
        Invoke("Transition", transitionTime2); 
    }

    public void FadeMusic()
    {
        if(audio1.volume > 0.0f || audio2.volume > 0.0f)
        {
            audio1.volume -= .1f;
            audio2.volume -= .1f;
        }
        Invoke("FadeMusic", transitionTime2);
    }
}
