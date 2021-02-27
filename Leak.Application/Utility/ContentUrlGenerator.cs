using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Utility
{
    public static class ContentUrlGenerator
    {
        public static string GenerateUrl(int contentId, string contentTitle)
        {
            return $"{contentId}/{contentTitle}";
           /* StringBuilder sb = new StringBuilder();
            sb.Append(contentId);

            string[] contentParts = contentTitle.Split(new char[] { ' ', ',', '.', '!', '-', '"', ';','(', ')'}, StringSplitOptions.RemoveEmptyEntries);

            foreach(string contentPart in contentParts)
            {
                sb.Append('-');
                sb.Append(contentPart);
            }

            return sb.ToString();*/
        }
    }
}
