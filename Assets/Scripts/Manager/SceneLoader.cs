using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// �V�[����ύX����Ƃ��ɌĂяo���֐�
    /// </summary>
    /// <param name="sceneName">�V�[����</param>
    public static void SceneChange(string sceneName) => SceneManager.LoadSceneAsync(sceneName);
}
