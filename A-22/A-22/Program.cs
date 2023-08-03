using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace A_22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Source and Destination classes
            Source source = new Source()
            {
                Property1 = "Value",
                Property2 = 563,
                Property3 = true
            };

            Destination destination = new Destination();

            MapProperties(source, destination);

            Console.WriteLine($"Property1: {destination.Property1}");
            Console.WriteLine($"Property2: {destination.Property2}");
            Console.WriteLine($"Property4: {destination.Property4}");
            Console.WriteLine($"Property5: {destination.Property5}");
        }

        public static void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = Array.Find(destinationProperties, p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null)
                {
                    object value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }
        }
    }
}
