using UnityEngine;

[System.Serializable]
[Tooltip("In this place ither soundType Should place or Music type")]
public class SoundData<T>
{
    public T effectType;
    public AudioClip effectClip;
}

public enum SoundType
{
    Jump,
    Die,
    UIInteractSound,
    Key,
    Win,
    Loss,
    Damage,
    enemyDie
}

public enum MusicType
{
    lobbyMusic,
    levelMusic
}
public interface ISoundMusicChanger
{
    public void ChangeBGMusic (MusicType musicType);
    public void PlayEffect (SoundType soundType);
}