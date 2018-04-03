using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Module2.Infrastructure.Services.Implementations
{
    using System.Text.RegularExpressions;
    using App.Module2.Infrastructure.Services.Implementations;

    public class NameParts
    {
        public string FullName
        {
            get; set;
        }
        public string Prefix
        {
            get; set;
        }
        public string Givenname
        {
            get; set;
        }
        public string Middlenames
        {
            get; set;
        }
        public string Surname
        {
            get; set;
        }
        public string Suffix
        {
            get; set;
        }
        public NameParts()
        {
        }

        public NameParts(string fullName)
        {
            FullName = fullName;
        }
    }



    public class NameParsingService : AppModule2ServiceBase, INameParsingService
    {
        string[] _prefixes = { "mr", "mrs", "ms", "dr", "miss", "sir", "madam", "mayor", "president" };
        string[] _suffixes =
        {
            "jr", "sr", "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x", "xi", "xii", "xiii", "xiv",
            "xv"
        };

        public NameParsingService()
        {
        }

        public NameParts Parse(string fullName, bool singleNameIsLastName=false)
        {
            var result = new NameParts(fullName);


            // Split on period, commas or spaces, but don't remove from results.
            List<string> parts = Regex.Split(fullName, @"(?<=[., ])").ToList();

            // Remove any empty parts
            for (int x = parts.Count - 1; x >= 0; x--)
            {
                if (parts[x].Trim() == "")
                {
                    parts.RemoveAt(x);
                }
            }
            // Done, if no more parts
            if (parts.Count == 0)
            {
                return result;
            }

            // If first part is a prefix, set prefix and remove part
            string normalizedPart = parts.First().Replace(".", "").Replace(",", "").Trim().ToLower();
            if (_prefixes.Contains(normalizedPart))
            {
                result.Prefix = parts[0].Trim();
                parts.RemoveAt(0);
            }
            // Done, if no more parts
            if (parts.Count == 0)
            {
                return result;
            }

            // If last part is a suffix, set suffix and remove part
            normalizedPart = parts.Last().Replace(".", "").Replace(",", "").Trim().ToLower();
            if (_suffixes.Contains(normalizedPart))
            {
                result.Suffix = parts.Last().Replace(",", "").Trim();
                parts.RemoveAt(parts.Count - 1);
            }

            // Done, if no more parts
            if (parts.Count == 0)
            {
                return result;
            }

            // If only one part left...
            if (parts.Count == 1)
            {
                // If no prefix, assume first name, otherwise last
                // i.e.- "Dr Jones", "Ms Jones" -- likely to be last
                if ((result.Prefix == "")|| (singleNameIsLastName))
                {
                    result.Givenname = parts.First().Replace(",", "").Trim();
                }
                else
                {
                    result.Surname = parts.First().Replace(",", "").Trim();
                }
                return result;
            }

            if (parts.First().EndsWith(","))
            {
                // If first part ends with a comma, assume format:
                //   Last, First [...First...]
                result.Surname = parts.First().Replace(",", "").Trim();
                for (int x = 1; x < parts.Count; x++)
                {
                    result.Givenname += parts[x].Replace(",", "").Trim() + " ";
                }
                result.Givenname = result.Givenname.Trim();
                return result;
            }

            // Otherwise assume format:
            // First [...Middle...] Last

            result.Givenname = parts.First().Replace(",", "").Trim();
            result.Surname = parts.Last().Replace(",", "").Trim();
            for (int x = 1; x < parts.Count - 1; x++)
            {
                result.Middlenames += parts[x].Replace(",", "").Trim() + " ";
            }
            if (result.Middlenames!=null)
            {
                result.Middlenames = result.Middlenames.Trim();
            }
            return result;
        }
    }
}

