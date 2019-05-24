using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#region Class EnumsConverter
/// <summary>
/// Static class for Convert enum keys and values to NameArray,ValueArray, ListOfValues, ToEumerable 
/// </summary>
public static class EnumConverter
{
    /// <summary>
    /// Converts Enum T to array with the names of Enum T
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Array of strings</returns>
    public static string[] ToNameArray<T>()
    {
        return Enum.GetNames(typeof(T)).ToArray();
    }
    /// <summary>
    /// Converts Enum T to array with the values of Enum T :[ 1,2,3..]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns> Array of numbers </returns>
    public static Array ToValueArray<T>()
    {
        return Enum.GetValues(typeof(T));
    }
    /// <summary>
    /// Converts Enum T to List with the values of Enum T List of [1,2,3..]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>List<T></returns>
    public static List<T> ToListOfValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>().ToList();
    }

    /// <summary>
    /// Converts Enum T to Enumerable with the Values of Enum T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>Enumerable</returns>
    public static IEnumerable<T> ToEnumerable<T>()
    {
        return (T[])Enum.GetValues(typeof(T));
    }

    #endregion
}
