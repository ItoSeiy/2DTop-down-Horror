using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Triggers;
using UniRx;

/// <summary>
/// Player�Ǐ]�N���X
/// </summary>
public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    [Header("�v���C���[")]
    GameObject _player;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => MoveCamera());
    }

    void MoveCamera()
    {
        Vector3 playerPos = _player.transform.position;
        // �J�����ƃv���C���[�̈ʒu���ꏏ�ɂ���
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
    }
}
