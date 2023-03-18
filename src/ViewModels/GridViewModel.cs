using mrKrrabs.Solver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mrKrrabs.ViewModels
{
    public class GridViewModel : ViewModelBase
    {
        Element type;
        int visitCount;
        bool visiting;
        bool isRoute;

        public GridViewModel(Element type)
        {
            this.type = type;
        }

        public string Type {
            get => type.ToString();
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
