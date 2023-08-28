﻿    namespace Monitor_Lock   
   {   
        class Program   
        {   
           static readonly object _object = new object();          
            public static void PrintNumbers()   
            {   
               Monitor.Enter(_object);   
                try   
                {   
                    for (int i = 0; i < 5; i++)   
                    {   
                       Thread.Sleep(1000);   
                        Console.Write(i + ",");   
                    }   
                    Console.WriteLine();   
                }   
                finally   
                {   
                    Monitor.Exit(_object);   
                }   
            }   
       
           
       
            static void Main(string[] args)       
            {   
       
                  
                Thread[] Threads = new Thread[3];   
                for (int i = 0; i < 3; i++)   
                {   
                    Threads[i] = new Thread(new ThreadStart(PrintNumbers));    
                }   
                foreach (Thread t in Threads)   
                    t.Start();   
       
                Console.ReadLine();   
            }   
        }   
    }