using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("�������邩����Ȃ���")]
    bool _isKey;

    [SerializeField]
    [Header("�ړ��������V�[���̏ꏊ�����Ă�������")]
    Transform _scenePos;

    [SerializeField]
    [Header("���̖��O")]
    string _keyName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door) && !_isKey)
        {
            door.PosChange(_scenePos);
            //SoundManager.Instance.PlaySFX(SFXType.Door);// ���݂̓T�E���h���Ȃ����߃G���[��f���܂����C�ɂ��Ȃ��ł�������
        }
        else if (_isKey)// �����g�p�����Ƃ��̏���
        {
            door.PosChange(_scenePos);
            print("�����g�p���܂���");
        }
        else
        {
            print("�����K�v�ł�");
        }
    }
}
