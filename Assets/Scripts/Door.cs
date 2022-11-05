using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("�ړ��������V�[���̏ꏊ�����Ă�������")]
    Transform _scenePos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door))
        {
            door.SceneName(_scenePos);
            SoundManager.Instance.PlaySFX(SFXType.Door);// ���݂̓T�E���h���Ȃ����߃G���[��f���܂����C�ɂ��Ȃ��ł�������
        }
    }
}
