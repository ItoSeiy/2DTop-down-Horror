using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour, IObject
{
    public void AnyObject()
    {
        // �����Ƀe�L�X�g�Ƃ��o���֐����Ă�
        print("�����" + transform.name + "�ł�");
    }
}
