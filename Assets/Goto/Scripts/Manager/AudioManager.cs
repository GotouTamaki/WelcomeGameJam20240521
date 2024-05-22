using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>サウンド系の管理機能を提供します</summary>
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] AudioSource _bgmAudioSource;
    [SerializeField] AudioSource _seAudioSource;
    [SerializeField] List<BGMSoundData> _bgmSoundData;
    [SerializeField] List<SESoundData> _seSoundData;
    [SerializeField] Slider _masterSlider;
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _seSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    
    void Start()
    {
        //スライダーを動かした時の処理を登録。Startでないとうまくいかない。
        _masterSlider.onValueChanged.AddListener(SetAudioMixerMasterVolume);
        _bgmSlider.onValueChanged.AddListener(SetAudioMixerBGMVolume);
        _seSlider.onValueChanged.AddListener(SetAudioMixerSEVolume);
        SetAudioMixerMasterVolume(_masterSlider.value);
        SetAudioMixerBGMVolume(_bgmSlider.value);
        SetAudioMixerSEVolume(_seSlider.value);
    }

    /// <summary>BGMを再生します</summary>
    /// <param name="bgm">BGMの種類</param>
    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = _bgmSoundData.Find(data => data.bgm == bgm);
        _bgmAudioSource.clip = data.audioClip;
        _bgmAudioSource.Play();
    }

    /// <summary>SEを再生します</summary>
    /// <param name="se">SEの種類</param>
    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = _seSoundData.Find(data => data.se == se);
        _seAudioSource.PlayOneShot(data.audioClip);
    }

    /// <summary>AudioMixerでMasterの音量をセットします</summary>
    /// <param name="value">Masterの音量</param>
    public void SetAudioMixerMasterVolume(float value)
    {
        // valueはSliderの初期設定である0～1の値を想定しています。
        value = Mathf.Clamp01(value);
        // デシベルを考慮した計算
        float decibel = 20f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80f, 0f);
        _audioMixer.SetFloat("MasterVolume", decibel);
    }

    /// <summary>AudioMixerでBGMの音量をセットします</summary>
    /// <param name="value">BGMの音量</param>
    public void SetAudioMixerBGMVolume(float value)
    {
        // valueはSliderの初期設定である0～1の値を想定しています。
        value = Mathf.Clamp01(value);
        // デシベルを考慮した計算
        float decibel = 20f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80f, 0f);
        _audioMixer.SetFloat("BGMVolume", decibel);
    }

    /// <summary>AudioMixerでSEの音量をセットします</summary>
    /// <param name="value">SEの音量</param>
    public void SetAudioMixerSEVolume(float value)
    {
        // valueはSliderの初期設定である0～1の値を想定しています。
        value = Mathf.Clamp01(value);
        // デシベルを考慮した計算
        float decibel = 20f * Mathf.Log10(value);
        decibel = Mathf.Clamp(decibel, -80f, 0f);
        _audioMixer.SetFloat("SEVolume", decibel);
    }
}

[System.Serializable]
public class BGMSoundData
{
    // これがラベルになる
    public enum BGM
    {
        Title,
        InGame,
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
}

[System.Serializable]
public class SESoundData
{
    // これがラベルになる
    public enum SE
    {
        Attack,
        Damage,
        GetItem,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)] public float volume = 1;
}