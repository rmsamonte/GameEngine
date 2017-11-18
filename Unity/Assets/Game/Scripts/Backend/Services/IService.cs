using System;
using System.Collections;

public interface IService
{
    IEnumerator GetData(Action<string> callback);
    IEnumerator PostData(Object obj);
}