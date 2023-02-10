using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("�������邩����Ȃ���")]
    bool _isKey;

    [SerializeField]
    [Header("�ړ��������V�[���̏ꏊ�����Ă�������")]
    Transform _scenePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door) && !_isKey)
        {
            door.PosChange(_scenePos);
            //SoundManager.Instance.PlaySFX(SFXType.Door);// ���݂̓T�E���h���Ȃ����߃G���[��f���܂����C�ɂ��Ȃ��ł�������
        }
        else if (collision.TryGetComponent(out IKey key))// �����g�p�����Ƃ��̏���
        {
            key.OpenDoor(_isKey = false);
            door.PosChange(_scenePos);
            print("�����g�p���܂���");
        }
        else if (_isKey)
        {
            print("�����K�v�ł�");
        }
    }
}
