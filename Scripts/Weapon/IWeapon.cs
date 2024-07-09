using System.Collections;
using UnityEngine;

public enum WeaponType
{
    Gun=0,
    Rifle=1,
    Rocket=2,
    Max
}
/// <summary>
/// 模板模式模式应用
/// </summary>
public abstract class IWeapon
{
    protected WeaponBaseAttr mBaseAttr;
    protected int mAtkPlusValue;//敌人暴击

    protected GameObject mGameObject;//武器对应的物体    
    protected ParticleSystem mParticle;//武器粒子效果
    protected LineRenderer mLine;//武器射线
    protected Light mLight;
    protected AudioSource mAudio;
    protected ICharacter mOwner;//武器的拥有者
    protected float mEffectDisplayTime=0;
    public float atkRange { get { return mBaseAttr.AtkRange; } }    
    public int atk { get { return mBaseAttr.Atk; } }
    public ICharacter Owner { set { mOwner = value; } }
    public GameObject gameObject { get { return mGameObject; } }
    public IWeapon(WeaponBaseAttr baseAttr,GameObject gameObject)
    {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;
        Transform effect = mGameObject.transform.Find("Effect");
        mParticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }
    /// <summary>
    /// 计时器计时关闭特效
    /// </summary>
    public void Update()
    {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime <= 0)
            {
                mLine.enabled = false;
                mLight.enabled = false;
            }
        }
    }
    public void Fire(Vector3 targetPos)
    {
        PlayMuzzleEffect();
        PlayBulletEffect(targetPos);
        SetEffectDisplayTime();
        PlaySound();
    }
    /// <summary>
    /// 设置特效显示时间
    /// </summary>
    protected abstract void SetEffectDisplayTime();
    /// <summary>
    /// 显示枪口特效
    /// </summary>
    protected void PlayMuzzleEffect()
    {
        mParticle.Stop();//重置粒子特效
        mParticle.Play();
        mLight.enabled = true;//枪口闪光
    }
    /// <summary>
    /// 显示子弹轨迹特效        
    /// </summary>
    protected abstract void PlayBulletEffect(Vector3 targetPos);
    protected void DoPlayBulletEffect( float width,Vector3 targetPos)
    {
        mLine.enabled = true;
        mLine.startWidth = width; mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPos);
    }
    /// <summary>
    /// 播放声音
    /// </summary>
    protected abstract void PlaySound();
    protected void DoPlaySound(string ClipName)
    {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(ClipName);
        mAudio.clip = clip;
        mAudio.Play();
    }
}