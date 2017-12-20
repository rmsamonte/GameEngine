using System;

namespace Game.Scripts
{
    public class ModuleWrapper<T> : IModuleWrapper
    {
        public static T instance = default(T);

        public void Unset()
        {
            var disposeable = ModuleWrapper<T>.instance as IDisposable;
            if (disposeable != null)
            {
                disposeable.Dispose();
            }
            ModuleWrapper<T>.instance = default(T);
        }

    }

    internal interface IModuleWrapper
    {
        void Unset();
    }
}

