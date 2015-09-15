using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SignatureGroupConverter.Core
{
    public static class ListHelper
    {

        /// <summary>
        /// Transfor incoming individual item based "siggroup" list to a list containing groups of items, which groups can be assigned to original "siggroups"
        /// Result is ordered by group item count first (e.g. groups with 1 item come first), and after that ordered based on first item in the group (e.g. group containing A,C comes before B,D)
        /// Original siggroups:
        /// Siggroup1 (1st item of allLists): A,B,C,D,E,F 
        /// Siggroup2 (2nd item of allLists): A,      E  ,G
        /// Siggroup3 (3rd item of allLists):           F
        /// Result list of partner groups (in the order described above)
        /// PartnerGroup1: F
        /// PartnerGroup2: G
        /// PartnerGroup3: A,E
        /// PartnerGroup4: B,C,D
        /// Note: Original partner assignment can be done this way (not part of this excercise)
        /// Siggroup1: PartnerGroup1,3,4
        /// Siggroup2: PartnerGroup2,3
        /// Siggroup3: PartnerGroup1
        /// </summary>
        /// <param name="allLists">Partner assignemnt of siggroups</param>
        /// <returns>Partner groups in length/alphabetical order as above</returns>

        public static List<List<string>> TransformPartnerItemListToPartnerGroupList(List<List<string>> allLists)
        {

            OrderByCount(allLists);

            throw new NotImplementedException();

        }

        
        private static void DisplaySet(List<List<string>> set)
        {
            set = set.OrderBy(item => item.Count()).ToList();
            foreach (var sublist in set)
            {
                Console.Write("{");
                foreach (var k in sublist)
                {
                    Console.Write("{0}", k);

                }
                Console.WriteLine("}");
            }
        }


        public static void OrderByCount(List<List<String>> list)
        {


            list = list.OrderBy(item => item.Count()).ToList();
            

            HashSet<string> sumAll = new HashSet<string>();
            HashSet<string> listIntersect = new HashSet<string>();
            HashSet<string> listExcept = new HashSet<string>();
            HashSet<string> listEndExc = new HashSet<string>();
            List<List<string>> tmpIntExc = new List<List<string>>(); // List of lists
            int i = 0;
            while (i < list.Count() - 1)
            {
          
                listIntersect = new HashSet<string>(list[i].Intersect(list[i + 1]));
                listIntersect.ExceptWith(sumAll);
                sumAll.UnionWith(listIntersect);

                listExcept = new HashSet<string>(list[i].Except(list[i + 1]));
                listExcept.ExceptWith(sumAll);
                sumAll.UnionWith(listExcept);

                i++;

                if (i == list.Count() - 1)
                {
                    listEndExc = new HashSet<string>(list[list.Count() - 1]);
                    listEndExc.ExceptWith(sumAll);

                }

                List<string> kkk = new List<string>(listIntersect);// List of Intersect
                List<string> mmm = new List<string>(listExcept);// List of Except
                List<string> nnn = new List<string>(listEndExc);
                if (kkk.Any())
                {
                    tmpIntExc.Add(kkk);
                }
                if (mmm.Any())
                {
                    tmpIntExc.Add(mmm);
                }
                if (nnn.Any())
                {
                    tmpIntExc.Add(nnn);
                }


            }

            DisplaySet(tmpIntExc);
            Console.ReadKey();

        }


        /// <summary>
        /// Do not edit, used to generate test result from real word example
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private static string TestResultToString(List<List<string>> result)
        {
            var stringResult = "";
            foreach (var grp in result)
            {
                stringResult += "new List<string> {";
                var cnt = 0;
                foreach (var p in grp)
                {
                    if (cnt++ > 0)
                        stringResult += ",";
                    stringResult += "\"" + p + "\"";
                }
                stringResult += "}," + Environment.NewLine;
            }

            return stringResult;
        }

    }
}