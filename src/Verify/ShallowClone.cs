﻿using System.Collections.Generic;

static class ShallowClone
{
    public static List<T> Clone<T>(this List<T> original)
    {
        return new(original);
    }
}