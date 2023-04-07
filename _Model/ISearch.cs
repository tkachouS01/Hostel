using System.Collections.Generic;

namespace HostelProject._Model
{
    interface ISearch
    {
        List<object> RequestSearch(List<object> listObjects, string nameObject,
            string nameFeature, string valueFeature);
    }
}
