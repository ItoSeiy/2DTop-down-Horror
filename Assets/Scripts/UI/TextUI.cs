using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>CSV管理</summary>
public class TextUI : MonoBehaviour
{
    /// <summary>CSVデータの保存場所</summary>
    List<string[]> _csvData = new List<string[]>();

    /// <summary>シナリオデータ</summary>
    [SerializeField]
    [Header("シナリオデータ")]
    TextAsset _textFail;

    /// <summary>UITextスクリプト</summary>
    [SerializeField]
    [Header("UITextスクリプト")]
    UIText _uitext;

    /// <summary>現在の行数</summary>
    int _textID = 1;

    /// <summary>イベントフラグ</summary>
    bool _eventflag = false;

    /// <summary>イベント名</summary>
    string _eventName;

    void Start() => LoadCSV();

    /// <summary>CSVを読み込む</summary>
    public void LoadCSV()
    {
        StringReader reader = new StringReader(_textFail.text);

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

        StartCoroutine(Cotext());
    }

    /// <summary>クリックでテキストを一気に表示</summary>
    IEnumerator Skip()
    {
        while (_uitext.Playing) yield return null;
        while (!_uitext.IsClicked()) yield return null;
    }

    /// <summary>CSVを上から一行ずつ出力</summary>
    IEnumerator Cotext()
    {
        Debug.Log($"現在：{_textID}行");

        _uitext.DrawText(_csvData[_textID][1], _csvData[_textID][2]); //(名前,セリフ)
        yield return StartCoroutine(Skip());//クリックで進む
        _textID++; //次の行へ

        EventCheck();
    }

    /// <summary>イベントフラグ確認</summary>
    public void EventCheck()
    {
        //イベントフラグが立っていない場合
        if (!_eventflag) StartCoroutine(Cotext());

        //イベントフラグが立っている場合
        else
        {
            switch (_eventName/*なんのイベントフラグが立っているか*/)
            {
                //イベントの種類
                case "0":
                    //イベントの処理:0
                    break;
                case "1":
                    //イベントの処理:1
                    break;
                case "2":
                    //イベントの処理:2
                    break;
                case "3":
                    //イベントの処理:3
                    break;

            }
        }
    }
}
