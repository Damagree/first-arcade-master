using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TechnomediaLabs;

namespace Zetcil
{
    public class PlantZombieController : MonoBehaviour
    {
        public enum CPlayerType {  Player, Zombie }
        public enum CStatusType { Walk, Aim, Attack }
        public enum CAttackType { Weak, Middle, Strong }

        [Space(10)]
        public bool isEnabled;

        [Header("Main Settings")]
        public CPlayerType PlayerType;
        public GameObject TargetObject;
        public Animator TargetAnimator;
        public VarHealth TargetHealth;

        [Header("Animation Settings")]
        public string IdleAnimation;
        public string WalkAnimation;
        public string HitAnimation;
        public string AimAnimation;
        public string AttackAnimation;
        public string DeathAnimation;

        [Header("Walk Settings")]
        [Tag] public string WalkBumperTag;
        public float WalkSpeed;

        [Header("Attack Settings")]
        public CStatusType StatusType;
        public CAttackType AttackType;
        [Tag] public string AttackBumperTag;
        public int AttackDelay;
        public int AttackForce;

        [Header("Death Settings")]
        public UnityEvent DeathEvent;

        bool isAlive = true;
        bool isZombieAttack = false;
        GameObject collisionTarget;

        // Start is called before the first frame update
        void Start()
        {
            if (PlayerType == CPlayerType.Player)
            {
                TargetAnimator.Play(AttackAnimation);
            } else
            if (PlayerType == CPlayerType.Zombie)
            {
                TargetAnimator.Play(WalkAnimation);
            }
            InvokeRepeating("AlwaysWalk", 1, AttackForce);
        }

        void AlwaysWalk()
        {
            StatusType = CStatusType.Walk;
        }

        void ZombieAttackAnimation()
        {
            TargetAnimator.Play(AttackAnimation);
        }

        void WeakAttack()
        {
            Invoke("GetHitAnimationPlay", 0.5f);
            TargetHealth.CurrentValue -= 1;
        }

        void MiddleAttack()
        {
            Invoke("GetHitAnimationPlay", 0.5f);
            TargetHealth.CurrentValue -= 5;
        }

        void StrongAttack()
        {
            Invoke("GetHitAnimationPlay", 0.5f);
            TargetHealth.CurrentValue -= 10;
        }

        void GetHitAnimationPlay()
        {
            if (TargetHealth.CurrentValue > 0)
            {
                TargetAnimator.Play(HitAnimation);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (isEnabled)
            {
                if (isAlive)
                {
                    if (TargetHealth.CurrentValue <= 0)
                    {
                        TargetAnimator.Play("None", 1);
                        TargetAnimator.Play(DeathAnimation);
                        DeathEvent.Invoke();
                        GetComponent<BoxCollider2D>().enabled = false;
                        isAlive = false;
                        Destroy(this.gameObject, 3);
                    }
                    if (TargetHealth.CurrentValue > 0 && PlayerType == CPlayerType.Zombie)
                    {
                        if (StatusType == CStatusType.Walk)
                        {
                            TargetObject.transform.Translate(-1 * WalkSpeed * Time.deltaTime, 0, 0);
                        }
                        if (StatusType == CStatusType.Attack)
                        {
                            if (!isZombieAttack)
                            {
                                TargetAnimator.Play(AttackAnimation);
                                isZombieAttack = true;
                                if (collisionTarget != null)
                                {
                                    if (AttackType == CAttackType.Weak)
                                    {
                                        collisionTarget.SendMessage("WeakAttack");
                                    }
                                    if (AttackType == CAttackType.Middle)
                                    {
                                        collisionTarget.SendMessage("MiddleAttack");
                                    }
                                    if (AttackType == CAttackType.Strong)
                                    {
                                        collisionTarget.SendMessage("StrongAttack");
                                    }
                                }
                                Invoke("ZombieCoolDown", AttackDelay);
                            }
                        }
                    }
                }
            }
        }

        void ZombieCoolDown()
        {
            isZombieAttack = false;
        }

        void LateUpdate()
        {
            if (TargetHealth.CurrentValue > 0 && PlayerType == CPlayerType.Zombie)
            {
                if (collisionTarget == null)
                {
                    StatusType = CStatusType.Walk;
                    TargetAnimator.Play(WalkAnimation);
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            //StatusType = CStatusType.Walk;
            if (collider.gameObject.tag == WalkBumperTag)
            {
                StatusType = CStatusType.Attack;
                collisionTarget = collider.gameObject;
            }
            if (collider.gameObject.tag == AttackBumperTag)
            {
                TargetHealth.CurrentValue -= 5;
                GetHitAnimationPlay();
            }
        }

        void OnTriggerStay2D(Collider2D collider)
        {
            //StatusType = CStatusType.Walk;
            if (collider.gameObject.tag == WalkBumperTag)
            {
                StatusType = CStatusType.Attack;
                collisionTarget = collider.gameObject;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            StatusType = CStatusType.Walk;
            if (collision.gameObject.tag == WalkBumperTag)
            {
                StatusType = CStatusType.Attack;
                collisionTarget = collision.gameObject;
            }
            if (collision.gameObject.tag == AttackBumperTag)
            {
                TargetHealth.CurrentValue -= 5;
                GetHitAnimationPlay();
            }
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            StatusType = CStatusType.Walk;
            if (collision.gameObject.tag == WalkBumperTag)
            {
                StatusType = CStatusType.Attack;
                collisionTarget = collision.gameObject;
            }
        }
    }
}
