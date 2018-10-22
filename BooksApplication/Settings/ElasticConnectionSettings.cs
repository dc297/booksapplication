using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.Settings
{
    public class ElasticConnectionSettings
    {
        public string ClusterUrl { get; set; }

        public string DefaultIndex
        {
            get
            {
                return this.defaultIndex;
            }
            set
            {
                this.defaultIndex = value.ToLower();
            }
        }

        private string defaultIndex;
    }
}
