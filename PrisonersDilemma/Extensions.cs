using System.Collections;

namespace PrisonersDilemma;

public static class Extensions
{
    public static bool IsNullOrEmpty(this IList collection) => collection == null || collection.Count == 0;
}