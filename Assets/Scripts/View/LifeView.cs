using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// MVRP��V
/// </summary>
public class LifeView : MonoBehaviour
{
    [SerializeField]
    [Header("HP�X���C�_�[")]
    Slider _lifeSlider;


    public void SetLife(int lifeValue) => _lifeSlider.value = lifeValue;
}
