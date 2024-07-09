using System.Collections;
using UnityEngine;


public class DM12Adapter : MonoBehaviour
{
    private void Start()
    {
        //StandardInterface standard = new StandardImplementA();
        Adapter adapter = new Adapter(new NewPlugin());
        StandardInterface standard = adapter;
        standard.Request();
    }
}

interface StandardInterface
{
    void Request();
}
/// <summary>
/// 标准接口
/// </summary>
class StandardImplementA : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用了标准接口实现请求");
    }
}
/// <summary>
/// 适配器
/// </summary>
class Adapter : StandardInterface
{
    private NewPlugin mPlugin;
    public Adapter (NewPlugin plugin)
    {
        mPlugin = plugin;
    }
    public void Request()
    {
        mPlugin.SpecificRequest();
    }
}
/// <summary>
/// 特殊接口
/// </summary>
class NewPlugin
{
    public void SpecificRequest()
    {
        Debug.Log("使用了特殊接口实现了请求");
    }
}
