using System;
using System.Collections.Generic;
using System.Linq;
namespace KaprekarsConstantSearch
{
    class KapNumber
    {
        public UInt64[] value;
        UInt64 length;
        UInt64 numberbase;
        public KapNumber(int length, int numberbase)
        {
            this.length = Convert.ToUInt64(length);
            this.numberbase = Convert.ToUInt64(numberbase);
            value = Enumerable.Repeat<UInt64>(0, Convert.ToInt32(this.length)).ToArray();
            
        }
        public bool Increment()
        {
            int pos = Convert.ToInt32(this.length - 1);
            while (true)
            {
                // OK to increment number[pos]
                if (value[pos] != Convert.ToUInt64(this.numberbase - 1))
                {
                    value[pos]++;
                    return true;
                }
                // number[pos] is at max value
                else
                {
                    // pos==0 and we cant increment any more
                    if (pos == 0) { return false; }
                    value[pos] = 0;
                    pos--;
                }
            }
            
        }
        public string ValueToString()
        {
            string output = "";
            foreach(UInt64 i in value)
            {
                output += i.ToString() + ",";
            }
            return output;
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            KapNumber kap = new KapNumber(1, 4);
            while (kap.Increment())
            {
                Console.WriteLine(kap.ValueToString());
            }

        }
    }
}
