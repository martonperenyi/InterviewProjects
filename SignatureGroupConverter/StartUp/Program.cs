using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignatureGroupConverter.Core;



namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {

            var allLists = new List<List<string>>
            {
                new List<string> { "A","B" },
                new List<string> { "A","B","C" }
            };

            var result = ListHelper.TransformPartnerItemListToPartnerGroupList(allLists);
                //Console.WriteLine("Hello");
                Console.ReadKey();
        }

        private static void DisplaySet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (var i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

    }
}
