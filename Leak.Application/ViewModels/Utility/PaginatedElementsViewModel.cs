using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.ViewModels.Utility
{
    public class PaginatedElementsViewModel<TElement>
    {
        public List<TElement> Elements { get; private set; }

        public int CurrentPage { get; private set; }
        public int MaxPage { get; private set; }

        public int CountPerPage { get; private set; }

        public PaginatedElementsViewModel(List<TElement> elements, int page, int countPerPage, int maxElementCount)
        {
            Elements = elements;
            CurrentPage = page;
            CountPerPage = countPerPage;
            MaxPage = (maxElementCount / countPerPage);

            if(maxElementCount % countPerPage != 0)
            {
                if (maxElementCount != (MaxPage * countPerPage))
                    MaxPage++;
            }
        }
    }
}
