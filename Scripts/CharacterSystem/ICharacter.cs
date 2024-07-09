using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// 角色接口
/// </summary>
public abstract class ICharacter
{
    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    public NavMeshAgent mNavMeshAgent;
    protected AudioSource mAudioSource;
    protected Animation mAnim;    
    protected IWeapon mWeapon;
    protected bool mCanDestroy = false;//是否能被消灭
    protected bool mIsKilled = false;//是否死亡
    protected float mDestroyTimer = 2.0f;

    public IWeapon Weapon 
    { 
        set 
        { 
            mWeapon = value;  
            mWeapon.Owner = this;
            //获取角色身上的武器握持点
            GameObject child = UnityTool.FindChild(mGameObject, "weapon-point");
            // 连接武器和武器握持点
            UnityTool.Attach(child, mWeapon.gameObject);

        }
        get { return mWeapon; }
    }
    public float AtkRange { get { return mWeapon.atkRange; } }
    public ICharacterAttr Attr { set { mAttr = value; }get { return mAttr; } }
    public bool IsKilled { get { return mIsKilled; } }
    public bool CanDestroy
    {
        get { return mCanDestroy; }
        set { mCanDestroy = value; }
    }
    public GameObject gameObject
    {
        set
        {
            mGameObject = value;
            mNavMeshAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudioSource = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponent<Animation>();
        }
        get { return mGameObject; }
    }
    /// <summary>
    /// 获取物体的位置
    /// </summary>
    public Vector3 Position
    {
        get
        {
            if (mGameObject == null)
            {
                Debug.LogError("mGameObject为空");return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.Position);
        mGameObject.transform.LookAt(target.Position);
        PlayAnim("attack");
        target.UnderAttack(mWeapon.atk + mAttr.critValue);
    }
    /// <summary>
    /// 伤害处理
    /// </summary>
    /// <param name="damage"></param>
    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
        //被攻击的效果 视效只有敌人有
        //死亡效果 音效 视频效果 只有敌人有
    }
    public void Update()
    {
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if (mDestroyTimer <= 0)
            {
                mCanDestroy = true;
            }
            return;
        }
        mWeapon.Update();
    }    
    public virtual void Killed()
    {
        //死亡处理
        mIsKilled = true;
        //mNavMeshAgent.Stop();
        mNavMeshAgent.isStopped = true;
    }
    public void Release()
    {
        GameObject.Destroy(mGameObject);
    }
    public abstract void UpdateFsmAI(List<ICharacter> target);
    public void PlayAnim(string animName)
    {
        mAnim.CrossFade(animName);
    }
    /// <summary>
    /// 由导航系统进行移动
    /// </summary>
    /// <param name="targetPos"></param>
    public void MoveTo(Vector3 targetPos)
    {
        mNavMeshAgent?.SetDestination(targetPos);
        PlayAnim("move");
    }
    /// <summary>
    /// 播放特效
    /// </summary>
    /// <param name="effectName"></param>
    protected void DoPlayEffect(string effectName)
    {
        //加载特效
        GameObject effectGo = FactoryManager.assetFactory.LoadEffect(effectName);
        effectGo.transform.position = Position;//特效产生的位置
        //控制销毁
        effectGo.AddComponent<DestroyForTime>();
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="soundName"></param>
    protected void DoPlaySound(string clipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudioSource.clip = clip;
        mAudioSource.Play();
    }
    public abstract void RunVisitor(ICharacterVisitor visitor);
}
