using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx.Triggers;
using UniRx;
/// <summary>
/// Player�̓�������
/// </summary>
public class PlayerBase : MonoBehaviour,IDoor
{
    /// <summary>
    /// �v���C���[�̕`��
    /// </summary>
    SpriteRenderer _renderer;

    /// <summary>
    /// Rigidbody2D(����)
    /// </summary>
    Rigidbody2D _rb2D;

    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;


    [SerializeField]
    [Header("�v���C���[�̈ړ��X�s�[�h")]
    float _speed = 0.05f;

    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => Move());
        _renderer = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //_playerData.Damage(10);// ��Ń}�W�b�N�i���o�[��ύX���܂��B
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y).normalized;
        _rb2D.velocity = dir * _speed;
    }

    public void SceneName(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        print(sceneName + "�ֈړ�����");
    }
}