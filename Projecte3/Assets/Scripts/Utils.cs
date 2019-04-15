using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class Utils
    {
        public static bool CompareLists<T>(List<T> aListA, List<T> aListB)
        {
            if (aListA == null || aListB == null || aListA.Count != aListB.Count)
                return false;
            if (aListA.Count == 0)
                return true;
            Dictionary<T, int> lookUp = new Dictionary<T, int>();
            // create index for the first list
            for (int i = 0; i < aListA.Count; i++)
            {
                int count = 0;
                if (!lookUp.TryGetValue(aListA[i], out count))
                {
                    lookUp.Add(aListA[i], 1);
                    continue;
                }
                lookUp[aListA[i]] = count + 1;
            }
            for (int i = 0; i < aListB.Count; i++)
            {
                int count = 0;
                if (!lookUp.TryGetValue(aListB[i], out count))
                {
                    // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                    return false;
                }
                count--;
                if (count <= 0)
                    lookUp.Remove(aListB[i]);
                else
                    lookUp[aListB[i]] = count;
            }
            // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
            return lookUp.Count == 0;
        }
    //A method of type bool to give you the result of equality between two lists
   public static bool CompareLists2<T>(List<T> list1, List<T> list2)
    {
        //here we check the count of list elements if they match, it can work also if the list count doesn't meet, to do it just comment out this if statement
        if (list1.Count != list2.Count)
            return false;

        //here we check and find every element from the list1 in the list2
        foreach (var item in list1)
            if (list2.Find(i => i.Equals(item)) == null)
                return false;

        //here we check and find every element from the list2 in the list1 to make sure they don't have repeated and mismatched elements
        foreach (var item in list2)
            if (list1.Find(i => i.Equals(item)) == null)
                return false;

        //return true because we didn't find any missing element
        return true;
    }
}

