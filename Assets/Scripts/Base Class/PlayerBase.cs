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
    /// �A�j���[�^�[
    /// </summary>
    Animator _animator;

    /// <summary>
    /// Rigidbody2D(����)
    /// </summary>
    Rigidbody2D _rb;

    /// <summary>
    /// �|�[�Y�J�E���g
    /// </summary>
    int _pauseCount = 1;

    /// <summary>
    /// �v���C���[�C���v�b�g
    /// </summary>
    Vector2 _movement;

    [SerializeField]
    [Header("�v���C���[�f�[�^")]
    PlayerData _playerData;

    [SerializeField]
    [Header("�v���C���[�̈ړ��X�s�[�h")]
    float _speed = 0.05f;

    [SerializeField]
    [Header("�|�[�Y�p�l��")]
    Image _pausePanel;

    [SerializeField]
    [Header("UIManager")]
    UIManager _uiManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        this.UpdateAsObservable().Subscribe(x => Move());
        this.UpdateAsObservable().Subscribe(x => PauseResume());
        this.FixedUpdateAsObservable().Subscribe(x => MovePosition());
        //print(_pauseCount);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IObject anyObj))
        {
            anyObj.AnyObject();
            _uiManager.LogText.text = "�����Q�b�g����";
            collision.gameObject.SetActive(false);
        }
    }

    void PauseResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SoundManager.Instance.PlaySFX(SFXType.Pause);// ���݉����������Ă��Ȃ����߃G���[��f���̂ŃR�����g�A�E�g���Ă����܂��B
            switch (_pauseCount)
            {
                case 1:
                    PauseTime.OnPaused.Subscribe(x => _speed = 4.55f).AddTo(gameObject);
                    PauseTime.Pause();
                    _pausePanel.gameObject.SetActive(true);
                    break;

                case 2:
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
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetBool("IsWalking", _movement != Vector2.zero);
        if (_movement != Vector2.zero)
        {
            _animator.SetFloat("X", _movement.x);
            _animator.SetFloat("Y", _movement.y);
        }
    }

    void MovePosition()
    {
        _rb.MovePosition(_rb.position + _movement.normalized * _speed * Time.deltaTime);
    }

    /// <summary>
    /// �V�[����ς���֐�
    /// </summary>
    /// <param name="sceneName">�J�ڂ������V�[���̖��O</param>
    public void PosChange(Transform sceneName)
    {
        transform.position = sceneName.transform.position;
        print(sceneName.transform.name + "�ֈړ�����");
    }
}