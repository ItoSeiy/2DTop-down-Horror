using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItem : MonoBehaviour, IObject
{
    [SerializeField]
    [Header("�A�C�e���\��")]
    Image _itemImage;

    public void AnyObject()
    {
        print(transform.name + "�Q�b�g");
        _itemImage.gameObject.SetActive(true);
    }
}