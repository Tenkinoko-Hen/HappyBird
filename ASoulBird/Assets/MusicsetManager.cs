using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicsetManager : MonoBehaviour
{
    public GameObject _MusicPanel;
    public GameObject Player;
    public Dropdown _NowSong;

    private AudioSource _MusicSoure;
    bool FLAG = true;
    public List<AudioClip> _songs;

    private void Awake()
    {
 
        _MusicSoure = this.transform.GetComponent<AudioSource>();

        Debug.Log(">: " + PlayerPrefs.HasKey("Song_vlue"));
        if (PlayerPrefs.HasKey("Song_vlue"))
        {
            PlayerPrefs.SetInt("Song_value", 0);
            _MusicSoure.clip = _songs[PlayerPrefs.GetInt("Song_value")];
            _MusicSoure.Play();
            _NowSong.value = PlayerPrefs.GetInt("Song_value");
            return;
        }
          _MusicSoure.clip = _songs[PlayerPrefs.GetInt("Song_value")];
            _MusicSoure.Play();
        _NowSong.value = PlayerPrefs.GetInt("Song_value");

    }
    public void ShowAndHide_MusicPanel()
    {
        
        Player.SetActive(!Player.activeSelf);
        _MusicPanel.SetActive(!_MusicPanel.activeSelf);


    }

    public void Choose_Song(int value)
    {
        PlayerPrefs.SetInt("Song_value", value);

    }

    public void CompleteSet()
    {
        _MusicSoure.clip = _songs[PlayerPrefs.GetInt("Song_value")];
        _NowSong.value = PlayerPrefs.GetInt("Song_value");
        _MusicSoure.Play();
        ShowAndHide_MusicPanel();
    }


}
