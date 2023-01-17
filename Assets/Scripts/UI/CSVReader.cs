using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CSVReader : MonoBehaviour
{
    const string SHEET_ID = "1xTZ2Xvx3pPuaPjDKANB4pBR8UQknj1ipKAmbhpaC0y0";
    const string SHEET_NAME = "�V�[�g1";

    /// <summary>GSS�f�[�^�̕ۑ��ꏊ</summary>
    List<string[]> _gssData = new();

    /// <summary>���݂̍s��</summary>
    int _textID = 0;

    public void Awake()
    {
        StartCoroutine(Method(SHEET_NAME));
    }

    IEnumerator Method(string _SHEET_NAME)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            ViewCSV(request.downloadHandler.text);
        }
    }
    public void ReLoadGoogleSheet()
    {
        StartCoroutine(Method(SHEET_NAME));
    }

    void ViewCSV(string _text)
    {
        StringReader reader = new StringReader(_text);
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();        // ��s���ǂݍ���
            //_gssData.Add(line.Split(','));
            var elements = line.Split(',');    // �s�̃Z����,�ŋ�؂���
            for (var i = 0; i < elements.Length; i++)
            {
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            _gssData.Add(elements);
        }
        StartCoroutine(Cotext());
    }
    /// <summary>CSV���ォ���s���o��</summary>
    IEnumerator Cotext()
    {
        UIText.I.DrawText(_gssData[_textID][0], _gssData[_textID][1]); //(���O,�Z���t)
        yield return StartCoroutine(Skip());//�N���b�N�Ői��
        _textID++; //���̍s��
        StartCoroutine(Cotext());
    }

    IEnumerator Skip()
    {
        while (UIText.I.Playing) yield return null;
        while (!UIText.I.IsClicked()) yield return null;
    }

}
