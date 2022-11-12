using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>�L�����̐؂�ւ�</summary>
public class CharChange : MonoBehaviour
{
    [SerializeField]
    [Header("�؂�ւ��\�L����")]
    List<Sprite> _playerData = new List<Sprite>();
    
    [SerializeField]
    [Header("�X�v���C�g�����_���[")]
    SpriteRenderer _rend;

    /// <summary>�L�����i���o�[</summary>
    int _num = 0; 

    void Start() => _rend = GetComponent<SpriteRenderer>();

    void Update()
    {
        //E�L�[���������Ƃ�
        if(Input.GetKeyDown(KeyCode.E))
        {
            _num++;
        }

        //_num = ���݂̃L����
        switch (_num)
        {
            case 0:
            case 1:
            case 2:
                Debug.Log($"�L������{_num}�Ԃɐ؂�ւ���");
                _rend.sprite = _playerData[_num];
                if (_playerData[_num] == null) _num = 0;
                break;
            default:
                _num = 0;
                break;
        }

    }

    /// <summary>�r���ŃL������ǉ�</summary>
    /// <param name="sprite"></param>
    public void AddChar(Sprite sprite) => _playerData.Add(sprite);
}
