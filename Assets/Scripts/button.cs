using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    //���͂̕ێ��p�̕ϐ�
    //variable to hold the input
    public int hoji;
    //������悤�ɂ��邽�߂̕ϐ�
    //variables for clarity
    public int wakaru;
    //�����ƍׂ���������悤�ɂ��邽�߂̕ϐ�
    //Variables for better understanding
    public int metyawaka;
    // Start is called before the first frame update
    void Start()
    {
        //�f�o�b�O���O�͊�{�����č\��Ȃ�
        //�������Y�ꂻ�����������珑����
        //Debug logs can basically be deleted
        Debug.Log("�O�F�̔�������c");
        Debug.Log("�^�񒆂̔��ɂ́u����̏��ԂŒ@����v�Ə����Ă��钣�莆���\���Ă���");
        Debug.Log("�����Ɏ��������Ă���u�Y��Ȃ��悤�ɏ����������A�@�����Ԃ̓A�J�A�A�I�A�~�h���A�A�J�Bby���莆���������l�v���莆���������z�����Ƃ����悤��");
        hoji = 0;
        wakaru = 0;
        metyawaka = 0;
    }

    // Update is called once per frame
    //�������f�[�^��ێ�������@��������Ȃ���������ϐ���if���g�����S������
    //I didn't know how to hold the pressed data, so I pushed using variables and if
    void Update()
    {
        if (hoji == 0 && wakaru == 0 && metyawaka == 0) {
            Debug.Log("�ǂ̔���@����");
        }
       else if (hoji == 1 && wakaru == 0 && metyawaka == 3) {
            Debug.Log("�e�X�g�p�@����1");
            wakaru += 1;                                       
        }
       else if (hoji == 3 && wakaru == 1 && metyawaka == 4) {
            wakaru += 1;
            Debug.Log("�e�X�g�p�@����2");
        }
       else if (hoji == 6 && wakaru == 2 && metyawaka == 6) {
            wakaru += 1;
            Debug.Log("�e�X�g�p�@����3");
        }
       else if (hoji == 7 && wakaru == 3 && metyawaka == 9) {
            wakaru += 1;
            Debug.Log("����");
            //�����ɐԂ������J���Ēʂ��悤�ɂȂ�R�[�h���͂�����Ăяo�����߂̓z������
            //Write here the code that opens the red door and allows you to pass through, or someone to call it
        }

    }
    public void RedButton() {
        hoji += 1;
        metyawaka += 3;
        Debug.Log("�g�̔�����������");
    }
    public void BlueButton() {
        hoji += 2;
        metyawaka += 1;
        Debug.Log("���̔�����������");
    }
    public void GreenButton() {
        hoji += 3;
        metyawaka += 2;
        Debug.Log("���̔�����������");
    }
    //Unity�ɂ��Ƃ��炠��Button���g���č���Ă�z��
    //Assuming that it is made using Button that is originally in Unity
    //����̓��Z�b�g�{�^���������ꂽ�Ƃ��Ƀ��Z�b�g�����悤�ɍ���Ă���
    //This is made to be reset when the reset button is pressed
    //���ς��Ĕ�����������ʂ��痣���Ƃ��ɌĂяo���Ă�����
    //Remake it and knock on the door You can call it when you leave the screen
    public void ResetButton() {
        hoji = 0;
        wakaru = 0;
        metyawaka = 0;
        Debug.Log("reset");
    }
    private void Acashia() {
        //nothing in particular
        //is like a log
        //nice folds today
        //flowers are blooming
        //Even the birds are singing
        //On a day like this, someone like you
        //burn in hell
        //you are really stupid
        //Can you go by defeating about 10 bodies by yourself?
        //�������B
        //���܂�C�ɂ��Ȃ��ŁB
        //r-@-q=p
        //|�K�KT
        //| ~  |���ق��Ƃ��e���B
        //!    !
        // ~~~~~
    }
}
