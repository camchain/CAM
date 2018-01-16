﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cam.IO.Caching
{
    public class ReflectionCache<T> : Dictionary<T, Type>
    {



        public ReflectionCache() { }




        public static ReflectionCache<T> CreateFromEnum<EnumType>() where EnumType : struct, IConvertible
        {
            Type enumType = typeof(EnumType);

            if (!enumType.GetTypeInfo().IsEnum)
                throw new ArgumentException("K must be an enumerated type");

            ReflectionCache<T> r = new ReflectionCache<T>();

            foreach (object t in Enum.GetValues(enumType))
            {

                MemberInfo[] memInfo = enumType.GetMember(t.ToString());
                if (memInfo == null || memInfo.Length != 1)
                    throw (new FormatException());

                ReflectionCacheAttribute attribute = memInfo[0].GetCustomAttributes(typeof(ReflectionCacheAttribute), false)
                    .Cast<ReflectionCacheAttribute>()
                    .FirstOrDefault();

                if (attribute == null)
                    throw (new FormatException());

                r.Add((T)t, attribute.Type);
            }
            return r;
        }





        public object CreateInstance(T key, object def = null)
        {
            Type tp;

            if (TryGetValue(key, out tp)) return Activator.CreateInstance(tp);

            return def;
        }






        public K CreateInstance<K>(T key, K def = default(K))
        {
            Type tp;

            if (TryGetValue(key, out tp)) return (K)Activator.CreateInstance(tp);

            return def;
        }
    }
}