using System;
using System.Collections.Generic;
using System.Linq;
using Neo;
using Neo.VM;
using Neo.Cryptography;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);
            engine.LoadScript(File.ReadAllBytes(@"C:\Users\Detoxer\source\repos\NeoContract2\NeoContract2\bin\Debug\NeoContract2.avm"));

            using (ScriptBuilder sb = new ScriptBuilder())
            {
                sb.EmitPush("not dank"); // corresponds to the parameter b
                sb.EmitPush("not dank"); // corresponds to the parameter a
                engine.LoadScript(sb.ToArray());
            }

            engine.Execute(); // start execution

            var result = engine.EvaluationStack.Peek().GetString(); // set the return value here
            Console.WriteLine($"Execution result {result}");
            Console.ReadLine();
        }
    }
}
