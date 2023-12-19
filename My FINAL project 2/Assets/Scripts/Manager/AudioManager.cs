using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameData gameData;
    private AudioSource _myAS;
    [SerializeField] AudioMixer Audio;
    private const string musicVolumeParameter = "Music";
    private const string SFXVolumeParameter = "SFX";

    public Slider Master;
    public Slider Music;
    public Slider SFX;
    void Awake()
    {
        Music.onValueChanged.AddListener(SetMusicVolume);
        _myAS = GetComponent<AudioSource>();
        gameData.audioManager = this;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {
        
    }

    public void PlayerShot()
    {
        _myAS.PlayOneShot(gameData.GameAudio[3]);
    }
    public void PlayerHurt()
    {
        _myAS.PlayOneShot(gameData.GameAudio[2]);
    }
    public void EnemyShot()
    {
        _myAS.PlayOneShot(gameData.GameAudio[1]);

    }
    public void EnemyHurt()
    {
        _myAS.PlayOneShot(gameData.GameAudio[0]);
    }
    public void SetMusicVolume(float volume)
    {
        Audio.SetFloat(musicVolumeParameter, Mathf.Log10(volume) * 20);
    }
}