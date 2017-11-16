using System;
using System.Collections;

public interface IService
{
    IEnumerator GetData(Action callback);
    IEnumerator PostData(Object obj);
}