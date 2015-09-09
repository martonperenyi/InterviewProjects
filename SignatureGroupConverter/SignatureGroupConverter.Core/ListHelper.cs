﻿using System;
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


        private static void DisplaySet(HashSet<string> set)
        {
            Console.Write("{");
            foreach (var i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }


        public static void OrderByCount(List<List<String>> list)
        {


            list = list.OrderBy(item => item.Count()).ToList();

            int i = 0;
            while (i < list.Count() - 1)
            {

                HashSet<string> listIntersect = new HashSet<string>();

                if (list[i].Intersect(list[i + 1]).Any())
                {
                    listIntersect = new HashSet<string>(list[i].Intersect(list[i + 1]));
                }

                HashSet<string> listExcept = new HashSet<string>();
                HashSet<string> tempList = new HashSet<string>();
                HashSet<string> listRest = new HashSet<string>();

                HashSet<string> listAll = new HashSet<string>();

                if (list[i].Except(list[i + 1]).Any())
                {
                    listExcept = new HashSet<string>(list[i].Except(list[i + 1]));

                }
                
                tempList = new HashSet<string>(listIntersect.Union(listExcept).ToList());
                var result = (from m in tempList select m).Distinct().ToList();
                Console.Write("{");

                foreach (var s in tempList)
                {
                    Console.Write(" {0}", s);
                }
                Console.WriteLine(" }");


                i++;

                if (i == list.Count() - 1)
                {
                    listRest = new HashSet<string>(list[list.Count() - 1].Except(tempList));

                }




                listAll = new HashSet<string>(tempList.Union(listRest));


                // DisplaySet(listAll);
            }




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