using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour, ISoundController
{
    public Image MusicButton;
    public Image SoundButton;
    
    public void UpdateSound()
    {
        var save = SaveManager.Instance.Load();
        MusicButton.color = save.IsMusicOff ? Color.red : Color.green;
        SoundButton.color = save.IsSoundOff ? Color.red : Color.green;
    }

    public void CallSoundButton()
    {
        var save = SaveManager.Instance.Load();
        save.IsSoundOff = !save.IsSoundOff;
        SoundButton.color = save.IsSoundOff ? Color.red : Color.green;
        SaveManager.Instance.Save(save);
    }

    public void CallMusicButton()
    {
        var save = SaveManager.Instance.Load();
        save.IsMusicOff = !save.IsMusicOff;
        MusicButton.color = save.IsMusicOff ? Color.red : Color.green;
        SaveManager.Instance.Save(save);
    }
}
