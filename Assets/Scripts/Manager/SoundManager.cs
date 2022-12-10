using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    const string TITLE_SCENE_NAME = "Title";
    const string GAME_SCENE_NAME = "GameScene";

    AudioSource _audioSource;

    

    [SerializeField]
    [Header("���ʉ��n")]
    SoundSFX[] _soundSFX;

    [SerializeField]
    [Header("BGM�n")]
    SoundBGM[] _soundBGM;

    void Awake()
    {
        if (TryGetComponent(out _audioSource))
        {
            print("�I�[�f�B�I�\�[�X���Q�Ƃł���");
        }


        FirstBGM();
    }

    /// <summary>
    /// �V�[����ǂݍ��񂾎��ɃV�[���̖��O�ɂ���Ė炷���y��ς���
    /// </summary>
    void FirstBGM()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case TITLE_SCENE_NAME:
                break;

            case GAME_SCENE_NAME:
                break;
        }

        _audioSource.Play();
    }

    /// <summary>
    /// BGM��炷�֐�
    /// </summary>
    /// <param name="type"></param>
    public void PlayBGM(BGMType type)
    {
        var s = Array.Find(_soundBGM, e => e.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClip���Ȃ��ł�");
        }
    }

    /// <summary>
    /// ���ʉ���炷�֐�
    /// </summary>
    /// <param name="type"></param>
    public void PlaySFX(SFXType type)
    {
        var s = Array.Find(_soundSFX, e => e.Type == type);
        if (s != null)
        {
            _audioSource.PlayOneShot(s.Clip);
        }
        else
        {
            Debug.LogError("AudioClip���Ȃ��ł�");
        }
    }

    [Serializable]
    public class SoundSFX
    {
        public AudioClip Clip => _clip;

        public SFXType Type => _type;

        [SerializeField]
        SFXType _type;

        [SerializeField]
        AudioClip _clip;
    }

    [Serializable]
    public class SoundBGM
    {
        public BGMType Type => _type;

        public AudioClip Clip => _clip;

        [SerializeField]
        BGMType _type;

        [SerializeField]
        AudioClip _clip;
    }
}
