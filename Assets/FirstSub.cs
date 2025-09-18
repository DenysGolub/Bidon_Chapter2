using UnityEngine;

public class FirstSub : MonoBehaviour
{
    public void DoSomething()
    {
        Debug.Log("Client 1 writed!");
    }

    public void DoSomethingNumbers(int x)
    {
        Debug.Log("Numbers do smth!");
    }

    public int DoSomethingInteger()
    {
        return 0;
    }
}
