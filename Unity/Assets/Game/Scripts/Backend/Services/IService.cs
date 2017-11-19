using System;
using System.Collections;

public interface IService
{
    IEnumerator GetData(Action<string> callback);
    IEnumerator PostData<T>(T[] array, Action<string> callback);
    IEnumerator InsertData<T>(T[] array, Action<string> callback);
    IEnumerator UpdateData<T>(T[] array, Action<string> callback);
    IEnumerator DeleteData<T>(T[] array, Action<string> callback);
}