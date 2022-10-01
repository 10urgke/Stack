using System.Collections;
using StackExample;


class Example
{
    public static void Main()
    {
        Heap yigin = new Heap();
        
        yigin.Push(1); 
        yigin.Push(2);
        yigin.Push(3);
        yigin.Push(4);
        yigin.Push(5);
        yigin.Push(6);
        
        Console.WriteLine("Yığımızın ilk hali..."); 
        Yazdir(yigin);

        int sayi = (int) yigin.Pop(); 
        Console.WriteLine("\n Yığından {0} sayısını aldık", sayi);
        
        sayi = (int) yigin.Pop(); 
        Console.WriteLine("\n Yığından {0} sayısını aldık", sayi);
        
        sayi = (int) yigin.Peek(); 
        Console.WriteLine("\n Yığının tepesindeki sayı şu anda : {0}", sayi);
        
        yigin.Clear();
        Console.WriteLine($"\n Yığın temizlendi eleman sayısı şu anda : {yigin.Count}");
        

        Console.ReadLine();
    }
    public static void Yazdir(Heap yigin)
    {
        object obj = new Object();
        Heap yeniYigin = (Heap) yigin.Clone();
        if (yigin.Count != 0)
        {
            while (yeniYigin.Count > 0)
            {
                obj = yeniYigin.Pop();
                Console.WriteLine("\t" + obj);
            }
        }
        else Console.WriteLine("Yığın boş...!");
    }
   
}