using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMovement : MonoBehaviour
{

    [SerializeField] private int _num;

    public void OnTriggerEnter2D(Collider2D other)
    {
        switch(_num)
        {
            case 0:
                SceneManager.LoadScene("GameScene");
                Debug.Log("�}�b�v0��");
                break;

            case 1:
                SceneManager.LoadScene("Map1");
                Debug.Log("�}�b�v1��");
                break;

            case 2:
                SceneManager.LoadScene("Map2");
                Debug.Log("�}�b�v2��");
                break;

            case 3:
                SceneManager.LoadScene("Map3");
                Debug.Log("�}�b�v3��");
                break;

            case 4:
                SceneManager.LoadScene("Map4");
                Debug.Log("�}�b�v4��");
                break;

            case 5:
                SceneManager.LoadScene("Map5");
                Debug.Log("�}�b�v5��");
                break;

            case 6:
                SceneManager.LoadScene("Map6");
                Debug.Log("�}�b�v6��");
                break;

            case 7:
                SceneManager.LoadScene("Map7");
                Debug.Log("�}�b�v7��");
                break;

            case 8:
                SceneManager.LoadScene("Map8");
                Debug.Log("�}�b�v8��");
                break;

            case 9:
                SceneManager.LoadScene("Map9");
                Debug.Log("�}�b�v9��");
                break;

            case 10:
                SceneManager.LoadScene("Map10");
                Debug.Log("�}�b�v10��");
                break;

            case 11:
                SceneManager.LoadScene("Map11");
                Debug.Log("�}�b�v11��");
                break;
        }
    }
}
