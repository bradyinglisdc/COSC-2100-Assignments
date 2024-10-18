/*
 * Title: Program.cs
 * Name: Brady Inglis (100926284)
 * Date: 2024-10-17
 * Purpose: To provide an interface for the smartphone class
 */

#region Namespace Definition

namespace ClassExercise2
{

    /// <summary>
    /// This class simply provides a testing interface for the Smartphone class.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            RunTest();
        }

        private static void RunTest()
        {
            // Test some serial codes
            for (int i = 0; i < 10000000; i++)
            {
                Smartphone somePhone = new Smartphone();
                if (i % 10000 == 0) { Console.WriteLine(somePhone.SerialCode); }
            }

            // Test some apps
            Smartphone phone = new Smartphone();
            Console.WriteLine(phone.ToString());
            Console.WriteLine(phone.AppsToString());

            phone.AddApp(new KeyValuePair<string, int>("Angry Birds", 2));
            phone.AddApp(new KeyValuePair<string, int>("Instagram", 1));
            phone.AddApp(new KeyValuePair<string, int>("YouTube", 3));
            phone.AddApp(new KeyValuePair<string, int>("Google", 1));
            Console.WriteLine(phone.AppsToString());
        }
    }
}

#endregion