﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : UnitGunEnemy
{
    public SimpleBullet simpleBullet;


    public override void ShootTurret()
    {
        if (myTime > fireDelta)
        {
            for(int i = 0; i < gunTransform.Length; i++)
            {
                GameObject enemyBullet = ObjectPooler.SharedInstance.GetPooledObject(simpleBullet.tag);
                if (enemyBullet != null)
                {
                    enemyBullet.transform.position = gunTransform[i].position;
                    enemyBullet.transform.rotation = gunTransform[i].rotation;
                    enemyBullet.SetActive(true);

                    enemyBullet.GetComponent<SimpleBullet>().Speed = bulletSpeed;
                    //enemyBullet.GetComponent<SimpleBullet>().Parent = gameObject;
                    enemyBullet.GetComponent<SimpleBullet>().Direction = this.transform.up;
                    enemyBullet.GetComponent<SimpleBullet>().Damage = bulletDamage;
                }

                //SimpleBullet newBullet = Instantiate(simpleBullet, gunTransform[i].position, simpleBullet.transform.rotation) as SimpleBullet;
                //newBullet.Speed = bulletSpeed;
                //newBullet.Parent = gameObject;
                //newBullet.Direction = this.transform.up;
                //newBullet.Damage = bulletDamage;
            }
            
            myTime = 0.0F;
        }
    }
}
