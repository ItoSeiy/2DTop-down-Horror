using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CreateStage : MonoBehaviour
{
    GameObject stageFolder;
    public List <string[]> csvDatas = new List<string[]>(); // CSV�̒��g�����郊�X�g
    private GameObject obj;

    public void ReadStageData()
    {
        TextAsset _csvFile = Resources.Load("Assets/Resources/MapData/Map") as TextAsset; //Resouces����CSV�ǂݍ���
        StringReader reader = new StringReader(_csvFile.text);
        string ObjectAddress = "Object/";
        // , �ŕ�������s���ǂݍ���
        // ���X�g�ɒǉ����Ă���
        int maxX = -1;
        int maxY = -1;
        string line = "";
        while (reader.Peek() != -1) // reader.Peaek��-1�ɂȂ�܂�
        {
            line = reader.ReadLine(); // ��s���ǂݍ���
            csvDatas.Add(line.Split(',')); // , ��؂�Ń��X�g�ɒǉ�
            Debug.Log("" + line);
            maxY++;
        }
        maxX = CountChar(line, ',');

        for (int x = 0; x <= maxX; ++x) // y��1�`9�܂ŁA1�����₵�ČJ��Ԃ�
        {
            for (int y = 0; y <= maxY; ++y) // y��1�`9�܂ŁA1�����₵�ČJ��Ԃ�
            {
                if (csvDatas[y][x] != "0")
                {
                    CreateStageObject(maxY - y, x, ObjectAddress + csvDatas[y][x]);
                }
            }
        }
    }
    //�v���n�u���쐬����
    private void CreateStageObject(int y, int x, string objname)
    {
        Debug.Log((GameObject)Resources.Load(objname));
        obj = Instantiate((GameObject)Resources.Load(objname), new Vector3(x, y, 0), Quaternion.identity);

        obj.transform.parent = transform;//�I�u�W�F�N�g�̒��ɓ����
    }
    //�񐔂��J�E���g����
    public static int CountChar(string s, char c)
    {
        return s.Length - s.Replace(c.ToString(), "").Length;
    }
}