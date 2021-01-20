using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class AnimaController : MonoBehaviour
    {
        [Space(10)]
        public bool isEnabled;

        [Header("Default Animation Settings")]
        public bool usingDefault;
        public UnityEvent DefaultEvent;

        [Header("Stand Animation Settings")]
        public bool usingIdle;
        public UnityEvent IdleEvent;
        [Space(10)]
        public bool usingWalk;
        public UnityEvent WalkEvent;
        public bool usingWalkLR;
        public UnityEvent WalkLeftEvent;
        public UnityEvent WalkRightEvent;
        [Space(10)]
        public bool usingRun;
        public UnityEvent RunEvent;
        public bool usingRunLR;
        public UnityEvent RunLeftEvent;
        public UnityEvent RunRightEvent;

        [Header("Jump Animation Settings")]
        public bool usingJump;
        public UnityEvent JumpEvent;

        [Header("Fall Animation Settings")]
        public bool usingFall;
        public UnityEvent FallEvent;

        [Header("GetHit Animation Settings")]
        public bool usingGetHit;
        public UnityEvent GetHitEvent;

        [Header("Death Animation Settings")]
        public bool usingDeath;
        public UnityEvent DeathEvent;

        [System.Serializable]
        public class CAnimaSetting
        {
            public string AnimaName;
            public UnityEvent AnimaEvent;
        }

        [Header("Custom Animation Settings")]
        public bool usingCustomAnima;
        public List<CAnimaSetting> CustomAnimaEvent;

        public void InvokeIdleAnimation()
        {
            if (usingIdle)
            {
                IdleEvent.Invoke();
            }
        }

        public void InvokeWalkAnimation()
        {
            if (usingWalk)
            {
                WalkEvent.Invoke();
            }
        }

        public void InvokeWalkLeftAnimation()
        {
            if (usingWalkLR)
            {
                WalkLeftEvent.Invoke();
            }
        }

        public void InvokeWalkRightAnimation()
        {
            if (usingWalkLR)
            {
                WalkRightEvent.Invoke();
            }
        }

        public void InvokeRunLeftAnimation()
        {
            if (usingRunLR)
            {
                RunLeftEvent.Invoke();
            }
        }

        public void InvokeRunRightAnimation()
        {
            if (usingRunLR)
            {
                RunRightEvent.Invoke();
            }
        }

        public void InvokeRunAnimation()
        {
            if (usingRun)
            {
                RunEvent.Invoke();
            }
        }

        public void InvokeJumpAnimation()
        {
            if (usingJump)
            {
                JumpEvent.Invoke();
            }
        }

        public void InvokeFallAnimation()
        {
            if (usingFall)
            {
                FallEvent.Invoke();
            }
        }

        public void InvokeGetHitAnimation()
        {
            if (usingGetHit)
            {
                GetHitEvent.Invoke();
            }
        }

        public void InvokeDeathAnimation()
        {
            if (usingDeath)
            {
                DeathEvent.Invoke();
            }
        }

        public void InvokeCustomAnimation(int aIndex)
        {
            if (usingCustomAnima)
            {
                if (aIndex < CustomAnimaEvent.Count)
                {
                    CustomAnimaEvent[aIndex].AnimaEvent.Invoke();
                }
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (usingDefault)
            {
                DefaultEvent.Invoke();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
