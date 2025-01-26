using UnityEngine;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class VolumeSlider : MonoBehaviour
{



    [Header("UI Sliders")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    [Header("FMOD VCA Names")]
    [SerializeField] private string masterVCAPath = "vca:/MasterVCA";
    [SerializeField] private string sfxVCAPath = "vca:/SFXVCA";
    [SerializeField] private string musicVCAPath = "vca:/MusicVCA";

    private VCA masterVCA;
    private VCA sfxVCA;
    private VCA musicVCA;

    private void Start()
    {
        // Get VCA references
        masterVCA = RuntimeManager.GetVCA(masterVCAPath);
        sfxVCA = RuntimeManager.GetVCA(sfxVCAPath);
        musicVCA = RuntimeManager.GetVCA(musicVCAPath);

        // Load saved volume settings or set defaults
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);

        // Apply volume settings on start
        SetMasterVolume(masterVolumeSlider.value);
        SetSFXVolume(sfxVolumeSlider.value);
        SetMusicVolume(musicVolumeSlider.value);

        // Add listeners for when sliders are changed
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    public void SetMasterVolume(float value)
    {
        masterVCA.setVolume(value);
        PlayerPrefs.SetFloat("MasterVolume", value);  // Save volume
    }

    public void SetSFXVolume(float value)
    {
        sfxVCA.setVolume(value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        musicVCA.setVolume(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void OnDestroy()
    {
        // Remove listeners when the object is destroyed
        masterVolumeSlider.onValueChanged.RemoveListener(SetMasterVolume);
        sfxVolumeSlider.onValueChanged.RemoveListener(SetSFXVolume);
        musicVolumeSlider.onValueChanged.RemoveListener(SetMusicVolume);
    }


}
