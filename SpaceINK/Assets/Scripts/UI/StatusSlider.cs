﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusSlider : MonoBehaviour
{
    public Slider sliderArmor;
    public Slider sliderShield;
    [Header("SuperBoostRing")]
    public Image backBoostRing;
    public Image boostRing;
    [Header("SuperShootRing")]
    public Image backSuperShootRing;
    public Image superShootRing;
    
    private PlayerShip playerShip;
    // Start is called before the first frame update

    private void Awake()
    {
        playerShip = FindObjectOfType<PlayerShip>();
        //RefreshStat();
    }

    public void RefreshStat()
    {
        //Устанавливаем максимально возможное значение для слайдера показателя уровня щита. 
        //И сразу устанавливаем его значение на 100%
        sliderShield.maxValue = playerShip.shieldPoints;
        sliderShield.value = playerShip.shieldPoints;
        //Устанавливаем максимально возможное значение для слайдера показателя состояния обшивки корабля. 
        //И сразу устанавливаем его значение на 100%
        sliderArmor.maxValue = playerShip.armorPoints;
        sliderArmor.value = playerShip.armorPoints;

        backBoostRing.fillAmount = playerShip.boostPoints / playerShip.boostMaxPoints / 2.5f;
        backSuperShootRing.fillAmount = playerShip.superShootPoints / playerShip.superShootMaxPoints / 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Обновляем слайдеры щита и обшивки в зависимости от состояния корабля.
        sliderShield.value = playerShip.shieldPoints;
        sliderArmor.value = playerShip.armorPoints;

        //круглый слайде вокруг кнопок  SuperBoost и SuperShoot
        boostRing.fillAmount = playerShip.boostPoints / playerShip.boostMaxPoints / 2.5f;
        superShootRing.fillAmount = playerShip.superShootPoints / playerShip.superShootMaxPoints / 2.5f;
    }
}
