using System;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;

namespace TalusGameSystems.StateMachine
{
    public class StateMachine : BaseBehaviour
    {
        [AssetList]
        [SerializeField, Required]
        private BaseState _initialState;
        
        [Space, SerializeField] 
        private Transition[] _transitions;

        public BaseState CurrentState
        {
            get => _currentState;
            set => _currentState = value;
        }
        
        [Header("Debugging")]
        [SerializeField, ReadOnly] 
        private BaseState _currentState;

        private Dictionary<Type, Component> _cachedComponents;

        protected override void Awake()
        {
            _cachedComponents = new Dictionary<Type, Component>();
            CurrentState = _initialState;
        }

        protected override void Start()
        {
            CurrentState.OnEnter(this);
        }

        private void Update()
        {
            CurrentState.OnUpdate(this);
            
            CheckTransitions();
        }

        private void FixedUpdate()
        {
            CurrentState.OnFixedUpdate(this);
        }
        
        private void CheckTransitions()
        {
            for (int i = 0; i < _transitions.Length; ++i)
            {
                Transition transition = _transitions[i];
                if (transition.TargetState == CurrentState) { continue; }
                if (!transition.IsSatisfy(this)) { continue; }

                CurrentState.OnExit(this);
                CurrentState = transition.TargetState;
                CurrentState.OnEnter(this);
            }
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
