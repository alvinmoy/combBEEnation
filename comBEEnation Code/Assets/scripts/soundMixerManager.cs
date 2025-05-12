using UnityEngine;
using UnityEngine.Audio;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    public void setMasterVolume(float level){
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level)* 20f);
    }

    public void setSoundFXVolume(float level){
        audioMixer.SetFloat("soundFXVolume", Mathf.Log10(level)* 20f);
    }

    public void setMusicVolume(float level){
        audioMixer.SetFloat("musicVolume", Mathf.Log10(level)* 20f);
    }
}
