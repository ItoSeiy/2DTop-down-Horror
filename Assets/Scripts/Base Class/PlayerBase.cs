using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Triggers;
using UniRx;
/// <summary>
/// Player�̓�������
/// </summary>
public class PlayerBase : MonoBehaviour,IDoor
{
    /// <summary>
    /// Rigidbody2D(����)
    /// </summary>
    Rigidbody2D _rb2D;

    /// <summary>
    /// �|�[�Y�J�E���g
    /// </summary>
    int _pauseCount = 1;

    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�v���C���[�̈ړ��X�s�[�h")]
    float _speed = 0.05f;

    [SerializeField]
    [Header("�|�[�Y�p�l��")]
    Image _pausePanel;



    void Start()
    {
        this.UpdateAsObservable().Subscribe(x => Move());
        _rb2D = GetComponent<Rigidbody2D>();
        this.UpdateAsObservable().Subscribe(x => PauseResume());
        print(_pauseCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �^�O���g�������Ȃ��̂�Interface���g���܂��傤
        // (��)��
        //if (collision.gameObject.TryGetComponent(out IDamage damage))
        //{
        //    damage.Damage(_damage);
        //}
    }

    void PauseResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (_pauseCount)
            {
                case 1:
                    SoundManager.Instance.PlaySFX(SFXType.Pause);
                    PauseTime.OnPaused.Subscribe(x => _speed = 0f).AddTo(gameObject);
                    PauseTime.Pause();
                    _pausePanel.gameObject.SetActive(true);
                    break;

                case 2:
                    SoundManager.Instance.PlaySFX(SFXType.Pause);
                    PauseTime.OnResume.Subscribe(x => _speed = 4.55f).AddTo(gameObject);
                    PauseTime.Resume();
                    _pausePanel.gameObject.SetActive(false);
                    _pauseCount = 0;
                    break;
            }
            ++_pauseCount;
        }
    }

    /// <summary>
    /// Player�̓����𐧌䂷��֐�
    /// </summary>
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxis("Vertical");

        _rb2D.velocity = new Vector2(x, y) * _speed;

        if (x < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (x > 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
    }

    /// <summary>
    /// �V�[����ς���֐�
    /// </summary>
    /// <param name="sceneName">�J�ڂ������V�[���̖��O</param>
    public void SceneName(Transform sceneName)
    {
        transform.position = sceneName.transform.position;
        print(sceneName.transform.name + "�ֈړ�����");
    }
}