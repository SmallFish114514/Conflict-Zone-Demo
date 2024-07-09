using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 命令模式
/// </summary>
public class DM07Command : MonoBehaviour
{
    private void Start()
    {
        DMInvoker invoker = new DMInvoker();
        ConcreteCommand1 cmd1 = new ConcreteCommand1(new DMIReceiver1());
        invoker.AddCommand(cmd1);//添加命令
        invoker.ExecuteCommand();
    }

}
/// <summary>
/// 命令管理者(调用者)
/// </summary>
public class DMInvoker
{
    public List<DMICommand> commands = new List<DMICommand>();
    public void AddCommand(DMICommand command)
    {
        commands.Add(command);
    }
    public void ExecuteCommand()
    {
        foreach(DMICommand command in commands)
        {
            command.Execute();
        }
        commands.Clear();//执行完清空
    }
}
public abstract class DMICommand
{
    public abstract void Execute();
}
/// <summary>
/// 具体命令1
/// </summary>
public class ConcreteCommand1 : DMICommand
{
    public DMIReceiver1 receiver1;
    public ConcreteCommand1 (DMIReceiver1 receiver1)
    {
        this.receiver1 = receiver1;
    }
    /// <summary>
    /// 调用接收者的功能来完成命令要执行的操作
    /// </summary>
    public override void Execute()
    {
        receiver1.Action("Command1");
    }
}
/// <summary>
/// 接收者 执行命令
/// </summary>
public class DMIReceiver1
{
    public void Action(string cmd)
    {
        Debug.Log("Receiver1执行了" + cmd + "命令");
    }
}

