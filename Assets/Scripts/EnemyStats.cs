using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] private int hp;
    public int coins;
    public int currentHp;

    private void Start()
    {
        currentHp = hp;
    }
    private void Update()
    {
        hpSlider.value   = (float) currentHp / hp;
    }
}
