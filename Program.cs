using System;

namespace call_by_value_reference
{
    class Program
    {
        unsafe static void DemoFixed()
        {

            int[] list = new int[] { 1, 2, 3 };

            fixed (int* list_a = list)
            {

            }
        }

        unsafe static void Main(string[] args)
        {
            int a = 1;

            System.Console.WriteLine("Call by Value:");
            int b = a;                // Call by value
            a = 2;
            System.Console.WriteLine($"  a : {a}");
            System.Console.WriteLine($"  b : {b}");
            System.Console.WriteLine($"  &a: 0x{(int)&a:x16}");
            System.Console.WriteLine($"  &b: 0x{(int)&b:x16}\n");

            System.Console.WriteLine("Call by Reference:");
            ref int ref_int = ref a;  // Call by reference
            ref_int = 3;
            System.Console.WriteLine($"  a                   : {a}");
            System.Console.WriteLine($"  ref_int             : {ref_int}");
            System.Console.WriteLine($"  &a                  : 0x{(int)&a:x16}");
            fixed (int* p_ref_int = &ref_int)
            {
                System.Console.WriteLine($"  &ref_int / p_ref_int: 0x{(int)p_ref_int:x16}\n");
            };
            // System.Console.WriteLine($"  &ref_int: 0x{(int)&ref_int:x16}");  // Compiler Error CS0212:
            //                                                                       您只能取得 fixed 陳述式初始設定式中 unfixed 運算式的位址
            //                                                                       You can only take the address of an unfixed expression inside of a fixed statement initializer.
            //
            // 無法取得 ref_int 的 Address, 故用指標的方式來取得 ref_int 的 Address
            // int* p_ref_int = &ref_int;              // (X) Compiler Error CS0212
            // fixed (int* p_ref_int = &ref_int) { };  // (V)

            System.Console.WriteLine("Call by Address:");
            int* p_int = &a;          // Call by address
            *p_int = 4;
            System.Console.WriteLine($"  a      : {a}");
            System.Console.WriteLine($"  *p_int : {*p_int}");
            System.Console.WriteLine($"  &a     : 0x{(int)&a:x16}");
            System.Console.WriteLine($"  p_int  : 0x{(int)p_int:x16}");
            System.Console.WriteLine($"  &p_int : 0x{(int)&p_int:x16}");
            System.Console.WriteLine($"  &*p_int: 0x{(int)&*p_int:x16}\n");

            System.Console.WriteLine("Narrow:");
            byte* p_byte = (byte*)&a;
            // *p_byte = 256;  // Constant value 'value' cannot be converted to a 'type'.
            *p_byte = 255;
            System.Console.WriteLine($"  a      : {a}");
            System.Console.WriteLine($"  ref_int: {ref_int}");
            System.Console.WriteLine($"  *p_int : {*p_int}");
            System.Console.WriteLine($"  *p_byte: {*p_byte}\n");
        }
    }
}