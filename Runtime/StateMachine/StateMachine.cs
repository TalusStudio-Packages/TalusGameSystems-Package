using System;
using System.Collections.Generic;

using Sirenix.OdinInspector;

using UnityEngine;

using TalusFramework.Behaviours.Interfaces;

namespace TalusGameSystems.StateMachine
{
    public class StateMachine : BaseBehaviour
    {
        public BaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }

        [SerializeField, ReadOnly]
        private BaseState _currentState;

        [SerializeField, Required]
        private BaseState _initialState;

        private Dictionary<Type, Component> _cachedComponents;

        protected override void Awake()
        {
            CurrentState = _initialState;
            
            _cachedComponents = new Dictionary<Type, Component>();
        }

        private void Update()
        {
            CurrentState.Execute(this);
        }

        public new T GetComponent<T>() where T : Component
        {
            if (_cachedComponents.ContainsKey(typeof(T)))
            {
                return _cachedComponents[typeof(T)] as T;
            }

            var component = base.GetComponent<T>();
            if (component != null)
            {
                _cachedComponents.Add(typeof(T), component);
            }

            return component;
        }
    }
}
