using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM02Bridge : MonoBehaviour
{
    private void Start()
    {
        //Sphere sphere = new Sphere();
        //sphere.openGLDraw();
        //Cube cube = new Cube();
        //cube.openGLDraw();
        //Capsule capsule = new Capsule();
        //capsule.openGLDraw();
        //OpenGL openGL = new OpenGL();
        //openGL.Render("Cube");

        //桥接模式
        //IRenderEngine renderEngine = new OpenGL();//使用OpenGL引擎实现
        //IRenderEngine renderEngine = new DrectX();//使用DrectX引擎实现
        //IRenderEngine renderEngine = new SuperRender();//使用SuperRender引擎实现
        //Sphere sphere = new Sphere(renderEngine);
        //sphere.Draw();
        //Cube cube = new Cube(renderEngine);
        //cube.Draw();
        //Capsule capsule = new Capsule(renderEngine);
        //capsule.Draw();

        //ICharacter character = new SoldierCaptain();
        //WeaponGun gun = new WeaponGun();
        //character.gun = gun;
        //WeaponShotGun shotGun = new WeaponShotGun();
        //character.shotGun = shotGun;
        //character.Attack(Vector3.one);
        //Debug.Log("shotGun");

        //桥接模式
        ICharacter character = new SoldierCaptain();
        //character.weapon = new WeaponRocket();
        //character.Attack(Vector3.one);

    }
}
/// <summary>
/// 提供图形基类
/// </summary>
public abstract class IShape
{
    public string name;
    public IRenderEngine renderEngine;
    public IShape(IRenderEngine renderEngine)
    {
        this.renderEngine = renderEngine;
    }
    public void Draw()
    {
        renderEngine.Render(name);
    }
}
/// <summary>
/// 提供渲染引擎基类
/// </summary>
public abstract class IRenderEngine
{
    public abstract void Render(string name);
}
public class Sphere :IShape
{
    /// <summary>
    /// 桥接模式
    /// 通过构造函数接收一个 IRenderEngine 类型的参数，用于设置基类的相关属性。在构造函数内部，将类的 name 属性设置为 "Sphere"。
    ///  base(renderEngine)：这里使用了 base 关键字，表示调用基类（父类）的构造函数
    /// </summary>
    /// <param name="renderEngine"></param>
    public Sphere(IRenderEngine renderEngine) : base(renderEngine)
    {
        name = "Sphere";
    }
    //public string name = "Sphere";
    //OpenGL openGL = new OpenGL();
    //DrectX dx = new DrectX();//切换到dx引擎绘制图形
    //public void openGLDraw()
    //{
    //    openGL.Render(name);//自我绘制
    //}
    //public void dxDraw()
    //{
    //    dx.Render(name);
    //}
}
public class Cube:IShape
{
    /// <summary>
    /// 桥接模式
    /// </summary>
    /// <param name="renderEngine"></param>
    public Cube(IRenderEngine renderEngine) : base(renderEngine)
    {
        name = "Cube";
    }
    //public string name = "Cube";
    //OpenGL openGL = new OpenGL();
    //DrectX dx = new DrectX();
    //public void openGLDraw()
    //{
    //    openGL.Render(name);//自我绘制
    //}
    //public void dxDraw()
    //{
    //    dx.Render(name);
    //}
}
public class Capsule:IShape
{
    /// <summary>
    /// 桥接模式
    /// </summary>
    /// <param name="renderEngine"></param>
    public Capsule(IRenderEngine renderEngine) : base(renderEngine)
    {
        name = "Capsule";
    }
    //public string name = "Capsule";
    //OpenGL openGL = new OpenGL();
    //DrectX dx = new DrectX();
    //public void openGLDraw()
    //{
    //    openGL.Render(name);//自我绘制
    //}
    //public void dxDraw()
    //{
    //    dx.Render(name);
    //}
}
//渲染引擎
public class OpenGL:IRenderEngine
{
    /// <summary>
    /// 绘制图形
    /// </summary>
    /// <param name="name"></param>
    //public void Render(string name)
    //{
    //    Debug.Log("openGL绘制了图形"+name);
    //}
    public override void Render(string name)
    {
        Debug.Log("openGL绘制了图形" + name);
    }
}
public class DrectX:IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("DrectX绘制了图形" + name);
    }
}
public class SuperRender : IRenderEngine
{
    public override void Render(string name)
    {
        Debug.Log("SuperRender绘制了图形" + name);
    }
}
