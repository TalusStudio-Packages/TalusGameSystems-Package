using System;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

using TalusFramework.Behaviours.Interfaces;

namespace TalusGameSystems.StateMachine
{
    [AddComponentMenu("TalusGameSystems/State Machine/State Machine", 0)]
    public class StateMachine : BaseBehaviour
    {
        [AssetList]
        [SerializeField, Required]
        private BaseState _InitialState;
        
        [Space, SerializeField] 
        private Transition[] _Transitions;

        public BaseState CurrentState
        {
            get => _CurrentState;
            set => _CurrentState = value;
        }
        
        [Header("Debugging")]
        [SerializeField, ReadOnly] 
        private BaseState _CurrentState;

        private Dictionary<Type, Component> _CachedComponents;

        protected override void Awake()
        {
            _CachedComponents = new Dictionary<Type, Component>();
            CurrentState = _InitialState;
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
            for (int i = 0; i < _Transitions.Length; ++i)
            {
                Transition transition = _Transitions[i];
                if (transition.TargetState == CurrentState) { continue; }
                if (!transition.IsSatisfy(this)) { continue; }

                CurrentState.OnExit(this);
                CurrentState = transition.TargetState;
                CurrentState.OnEnter(this);
            }
        }

        public new T GetComponent<T>() where T : Component
        {
            if (_CachedComponents.ContainsKey(typeof(T)))
            {
                return _CachedComponents[typeof(T)] as T;
            }

            var component = base.GetComponent<T>();
            if (component != null)
            {
                _CachedComponents.Add(typeof(T), component);
            }

            return component;
        }
    }
}
