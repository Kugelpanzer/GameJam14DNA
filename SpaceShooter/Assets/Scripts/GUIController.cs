using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public Slider volumeSlider;
    public Canvas mainCanvas;
    Scene currentScene;
    AudioSource bcgSound;
    public GameObject player;
    public Text Lives;

    public void PlayGame()
    {

        SceneManager.LoadScene("First");
    }
    public void ResumeGame()
    {
        ControllerVal.Instance.pause = false;
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        bcgSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bcgSound.volume = ControllerVal.Instance.volume;
        if (volumeSlider!=null)
            ControllerVal.Instance.volume = volumeSlider.value;
        if (player != null && Lives!=null)
        {
            Lives.text = player.GetComponent<PlayerScript>().health.ToString();

        }
        if(currentScene.name != "Menu" && currentScene.name != "VictoryScene")
            if (!ControllerVal.Instance.pause  )
            {
                mainCanvas.enabled = false;

            }else if(ControllerVal.Instance.pause)
            {
                mainCanvas.enabled = true;
            }
    }
}
