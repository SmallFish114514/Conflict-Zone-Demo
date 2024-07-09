using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DM05Builder : MonoBehaviour
{
    private void Start()
    {
        //IBuilder fatBuilder = new FatBuilder();
        IBuilder thinBuilder = new ThinBuilder();
        //Person fatPerson = Directior.Construst(fatBuilder);
        Person thinPerson = Directior.Construst(thinBuilder);
        //fatPerson.Show();
        thinPerson.Show();
        
    }
}
public class Person
{
    List<string> parts = new List<string>();
    public void AddPart(string part)
    {
        parts.Add(part);
    }
    public void Show()
    {
        foreach(string part in parts)
        {
            Debug.Log(part);
        }
    }
}
public class FatPerson : Person { }
public class ThinPerson : Person { }
 public interface  IBuilder
{    
    void GetHead();
    void GetBody();
    void GetHand();
    void GetFeet();
    Person GetResult();
}
public class FatBuilder : IBuilder
{
    private Person person;
    public FatBuilder()
    {
        person = new FatPerson();
    }
    public void GetBody()
    {
        person.AddPart("胖人的身体");
    }

    public void GetFeet()
    {
        person.AddPart("胖人的脚");
    }

    public void GetHand()
    {
        person.AddPart("胖人的手");
    }

    public void GetHead()
    {
        person.AddPart("胖人的头");
    }

    public Person GetResult()
    {
        return person;
    }
}
public class ThinBuilder : IBuilder
{
    private Person person;
    public ThinBuilder()
    {
        person = new ThinPerson();
    }
    public void GetBody()
    {
        person.AddPart("瘦人的身体");
    }

    public void GetFeet()
    {
        person.AddPart("瘦人的脚");
    }

    public void GetHand()
    {
        person.AddPart("瘦人的手");
    }

    public void GetHead()
    {
        person.AddPart("瘦人的头");
    }

    public Person GetResult()
    {
        return person;
    }
}
public class Directior
{
    public static Person Construst(IBuilder builder)
    {
        builder.GetHead();
        builder.GetBody();
        builder.GetHand();
        builder.GetFeet();
        return builder.GetResult();
    }
}
