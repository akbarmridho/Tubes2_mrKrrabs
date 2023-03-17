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
        int visitCount;
        bool visiting;
        bool isRoute;

        public GridViewModel(char type)
        {
            this.type = type.ToString();
        }

        public string Type {
            get => type;
        }

        public void visit()
        {
            visitCount++;
            visiting = true;
        }

        public void disableVisiting()
        {
            visiting = false;
        }
    }
}
