using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryShopModelServiceDAL.ViewModel {
    public class StorageLoadViewModel {
        public string StorageName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Components { get; set; }
    }
}
