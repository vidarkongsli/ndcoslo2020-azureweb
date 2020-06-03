
using System;
using Antiboilerplate.Functional;

namespace Kongsli.Ndc2020.Jokes.Api.Extensions
{
    public static class ArrayExtensions
    {
        public static string PickRandomElement(this string[] @this)
            => new Random()
                .Map(r => r.Next(0, @this.Length - 1))
                .Map(i => @this[i]);
    }
}

