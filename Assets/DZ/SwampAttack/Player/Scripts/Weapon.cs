using UnityEngine;

namespace SwampAttack
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private int _price;
        [SerializeField] private Sprite _icon;
        [SerializeField] private bool _isBuyed = false;
        [SerializeField] private Bullet _bullet;

        protected Bullet Bullet => _bullet;

        public string Name => _name;
        public int Price => _price;
        public Sprite Icon => _icon;
        public bool IsBuyed => _isBuyed;

        public abstract void Shot(Transform shotPoint);

        public void Buy()
        {
            _isBuyed = true;
        }
    }
}

