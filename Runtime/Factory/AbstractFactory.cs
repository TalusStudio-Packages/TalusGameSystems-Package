using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Base;

namespace TalusGameSystems.Factory
{
    public abstract class AbstractFactory<T> : BaseSO
    {
        [LabelWidth(50)]
        [PropertySpace(SpaceAfter = 10)]
        [Required, SerializeField]
        private T _Object;
        public T Object => _Object;

        public abstract T Create();
    }
}