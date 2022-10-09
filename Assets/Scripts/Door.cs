using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Header("�ړ��������V�[���̖��O�����Ă�������")]
    string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDoor door))
        {
            door.SceneName(_sceneName);
        }
    }
}
