using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>CSV�Ǘ�</summary>
public class TextUI : MonoBehaviour
{
    /// <summary>CSV�f�[�^�̕ۑ��ꏊ</summary>
    List<string[]> _csvData = new List<string[]>();

    /// <summary>�V�i���I�f�[�^</summary>
    [SerializeField]
    [Header("�V�i���I�f�[�^")]
    TextAsset _textFail;

    /// <summary>UIText�X�N���v�g</summary>
    [SerializeField]
    [Header("UIText�X�N���v�g")]
    UIText _uitext;

    /// <summary>���݂̍s��</summary>
    int _textID = 1;

    /// <summary>�C�x���g�t���O</summary>
    bool _eventflag = false;

    /// <summary>�C�x���g��</summary>
    string _eventName;

    void Start() => LoadCSV();

    /// <summary>CSV��ǂݍ���</summary>
    public void LoadCSV()
    {
        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        StartCoroutine(Cotext());
    }

    /// <summary>�N���b�N�Ńe�L�X�g����C�ɕ\��</summary>
    IEnumerator Skip()
    {
        while (_uitext.Playing) yield return null;
        while (!_uitext.IsClicked()) yield return null;
    }

    /// <summary>CSV���ォ���s���o��</summary>
    IEnumerator Cotext()
    {
        Debug.Log($"���݁F{_textID}�s");

        _uitext.DrawText(_csvData[_textID][1], _csvData[_textID][2]); //(���O,�Z���t)
        yield return StartCoroutine(Skip());//�N���b�N�Ői��
        _textID++; //���̍s��

        EventCheck();
    }

    /// <summary>�C�x���g�t���O�m�F</summary>
    public void EventCheck()
    {
        //�C�x���g�t���O�������Ă��Ȃ��ꍇ
        if (!_eventflag) StartCoroutine(Cotext());

        //�C�x���g�t���O�������Ă���ꍇ
        else
        {
            switch (_eventName/*�Ȃ�̃C�x���g�t���O�������Ă��邩*/)
            {
                //�C�x���g�̎��
                case "0":
                    //�C�x���g�̏���:0
                    break;
                case "1":
                    //�C�x���g�̏���:1
                    break;
                case "2":
                    //�C�x���g�̏���:2
                    break;
                case "3":
                    //�C�x���g�̏���:3
                    break;

            }
        }
    }
    public void CharCheck()
    {
        switch (_eventName/*�Ȃ�̃C�x���g�t���O�������Ă��邩*/)
        {
            //�C�x���g�̎��
            case "0":
                //�C�x���g�̏���:0
                break;
            case "1":
                //�C�x���g�̏���:1
                break;
            case "2":
                //�C�x���g�̏���:2
                break;
            case "3":
                //�C�x���g�̏���:3
                break;

        }
    }

    /// <summary>�S�̔��𒲂ׂ�i�n���[����O�j</summary>
    public void ItemCheck()
    {
        _textID = 71 - 1;
        StartCoroutine(Cotext());
    }
}
