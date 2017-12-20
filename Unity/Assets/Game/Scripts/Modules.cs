using System;
using System.Collections.Generic;

namespace Game.Scripts
{
    public class Modules
    {
        private List<IModuleWrapper> moduleWrapperList;

        public Modules()
        {

        }

        public T Set<T>(T instance)
        {
            if (ModuleWrapper<T>.instance != null)
            {
                throw new InvalidOperationException("An instance of this module class has already been set!");
            }

            ModuleWrapper<T>.instance = instance;

            if (moduleWrapperList == null)
            {
                moduleWrapperList = new List<IModuleWrapper>();
            }

            moduleWrapperList.Add(new ModuleWrapper<T>());

            return instance;
        }

        public static T Get<T>()
        {
            return ModuleWrapper<T>.instance;
        }

        public static bool IsSet<T>()
        {
            return ModuleWrapper<T>.instance != null;
        }

        public static void Clear<T>()
        {
            ModuleWrapper<T>.instance = default(T);
        }

    }
}

