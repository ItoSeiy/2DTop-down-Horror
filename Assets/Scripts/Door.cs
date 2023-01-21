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
        else if (collision.TryGetComponent(out IKey key))
        {
            key.OpenDoor(_isKey = false);
        }
        else if (_isKey)// �����Ȃ��Ƃ��̏���
        {
            print("�����K�v�ł�");
        }
    }
}
