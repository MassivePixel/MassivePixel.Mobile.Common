using System;
using GalaSoft.MvvmLight.Ioc;

namespace MassivePixel.Common.Mvvm
{
    public static class SimpleIocExtensions
    {
        public static void TryRegister<TClass>(this SimpleIoc simpleIoc)
            where TClass : class
        {
            if (simpleIoc == null)
                throw new ArgumentNullException();

            if (!simpleIoc.IsRegistered<TClass>())
                simpleIoc.Register<TClass>();
        }

        public static void TryRegister<TInterface, TClass>(this SimpleIoc simpleIoc)
            where TInterface : class
            where TClass : class, TInterface
        {
            if (!simpleIoc.IsRegistered<TInterface>())
                simpleIoc.Register<TInterface, TClass>();
        }

        public static void TryRegister<TClass>(this SimpleIoc simpleIoc, TClass instance)
            where TClass : class
        {
            if (!simpleIoc.IsRegistered<TClass>())
                simpleIoc.Register(() => instance);
        }
    }
}
