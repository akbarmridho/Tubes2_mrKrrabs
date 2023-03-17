using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class GridViewModel : ViewModelBase
    {
        string type;

        public GridViewModel(char type)
        {
            this.type = type.ToString();
        }

        public string Type {
            get => type;
        }
    }
}
