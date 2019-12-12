using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DBHealthCheckExecAction
{
    public class Address
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Title.ReplaceQuotes());
            builder.Append(" ");
            builder.Append(FirstName.ReplaceQuotes());
            if (!String.IsNullOrEmpty(MiddleName.Trim()))
            {
                builder.Append(" ");
                builder.Append(MiddleName.ReplaceQuotes());
            }
            builder.Append(" ");
            builder.Append(LastName.ReplaceQuotes());
            builder.Append("\r\n");

            if (!String.IsNullOrEmpty(AddressLine1.Trim()))
            {
                builder.Append(AddressLine1.ReplaceQuotes());
                builder.Append("\r\n");
            }

            if (!String.IsNullOrEmpty(AddressLine2.Trim()))
            {
                builder.Append(AddressLine2.ReplaceQuotes());
                builder.Append("\r\n");
            }

            if (!String.IsNullOrEmpty(City.Trim()))
            {
                builder.Append(City.ReplaceQuotes());
                if (!String.IsNullOrEmpty(PinCode))
                {
                    builder.Append(" - ");
                    builder.Append(PinCode.ReplaceQuotes());
                }
                builder.Append("\r\n");
            }

            builder.Append("\r\n");
            return builder.ToString();
        }
    }

    public class AddressLabelGenerator
    {
        public static void Main(string[] args)
        {
            List<Address> addresses = new List<Address>();
            string path = @"C:\Users\Subodh\Desktop\Labels.csv";
            string[] lines = File.ReadAllLines(path);
            int i = 0;
            foreach(string line in lines)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                string[] parts = line.Split(',');
                // parts = GetAddressParts(parts);
                Address address = new Address {
                    Title = parts[0],
                    FirstName = parts[1],
                    MiddleName = parts[2],
                    LastName = parts[3],
                    AddressLine1 = parts[4],
                    AddressLine2 = parts[5],
                    City = parts[6],
                    PinCode = parts[7]
                };
                addresses.Add(address);
            }

            StringBuilder builder = new StringBuilder();
            foreach (Address address in addresses)
                builder.Append(address.ToString());

            path = @"C:\Users\Subodh\Desktop\output.txt";
            builder = builder.Replace("@@", ",");
            File.WriteAllText(path, builder.ToString());
        }

        private static string[] GetAddressParts(string[] parts)
        {
            List<string> units = new List<string>();
            for (int i = 0; i < parts.Length; i++)
            {
                string part = parts[i];
                if (part.StartsWith("\""))
                {
                    string temp = part;
                    while (!part.EndsWith("\""))
                    {
                        part = parts[++i];
                        temp += part;
                    }
                    part = temp;
                }
                units.Add(part);
            }
            return units.ToArray();
        }
    }

    public static class ExtensionMethods
    {
        public static string ReplaceQuotes(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";
            input = input.Replace("\"", "");
            input = input.Trim();
            return input;
        }
    }
}
