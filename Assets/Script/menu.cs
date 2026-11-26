using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    [SerializeField,Tooltip("mixer pour le volume")]
    private AudioMixer mixer;
    [SerializeField,Tooltip("slider pour le volume")]
    private Slider sliderVolume;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("VolumeMaster", 1f);
        sliderVolume.onValueChanged.AddListener(SetVolume);
        SetVolume(sliderVolume.value);
    }

    private void SetVolume(float volume)
    {
        mixer.SetFloat("VolumeMaster", Mathf.Log10(Mathf.Max(volume, 0.0001f)) * 20);
        PlayerPrefs.SetFloat("VolumeMaster", volume);
    }
    public void ChangerScene(string NomScene)
    {
        SceneManager.LoadScene(NomScene);
    }
}
