using UnityEngine;

/// <summary>�^�C�g����ʂ�UI</summary>
public class TitleUI : MonoBehaviour
{
    /// <summary>����������</summary>
    [SerializeField]
    [Header("����������")]
    GameObject _controlPanel;

    /// <summary>�p�l�����\��</summary>
    public void OffPanel() => _controlPanel.SetActive(false);

    /// <summary>�p�l����\��</summary>
    public void OnPanel() => _controlPanel.SetActive(true);
}
