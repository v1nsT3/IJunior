using SwampAttack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private float _delay;
    [SerializeField] private int _numberBulletSpawnOnShot;

    private Coroutine _coroutine;

    public override void Shot(Transform shotPoint)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ShotDelay(shotPoint));
    }

    private IEnumerator ShotDelay(Transform shotPoint)
    {
        int countBullet = 0;

        while(countBullet != _numberBulletSpawnOnShot)
        {
            Instantiate(Bullet, shotPoint.position, Quaternion.identity);
            countBullet++;
            yield return new WaitForSeconds(_delay);
        }
    }
}
