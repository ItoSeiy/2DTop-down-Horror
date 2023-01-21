using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text LogText => _logText;

    [SerializeField]
    [Header("���O�e�L�X�g")]
    private Text _logText;

    void Start()
    {
        _logText.text = null;
    }
}
