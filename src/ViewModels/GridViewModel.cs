using mrKrrabs.Solver;
using ReactiveUI;
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

        public int VisitCount
        {
            get { return visitCount; }
            set { this.RaiseAndSetIfChanged(ref visitCount, value); }
        }

        public bool Visiting
        {
            get { return visiting; }
            set { this.RaiseAndSetIfChanged(ref visiting, value); }
        }

        public bool IsRoute
        {
            get { return isRoute; }
            set { this.RaiseAndSetIfChanged(ref isRoute, value); }
        }

        public GridViewModel(Element type)
        {
            this.type = type;
        }

        public GridViewModel(char c)
        {
            switch (c)
            {
                case 'K':
                    this.type = Element.KrustyKrab;
                    break;
                case 'R':
                    this.type = Element.Tunnel;
                    break;
                case 'T':
                    this.type = Element.Treasure;
                    break;
                case 'X':
                default:
                    this.type = Element.Dirt;
                    break;
            }
        }

        public string Type {
            get => type.ToString();
        }

        public void Visit()
        {
            VisitCount++;
            Visiting = true;
            Background = "Yellow";
        }

        public void DisableVisiting()
        {
            Visiting = false;
            if (visitCount == 1)
            {
                Background = "GreenYellow";
            }
            else
            {
                Background = "Green";
            }
        }

        public void SetRoute()
        {
            IsRoute = true;
            Background = "Aquamarine";
        }

        public void SetNotRoute()
        {
            IsRoute = false;
            Background = "Aqua";
        }

        string background = "Aqua";

        public string Background
        {
            get => background;
            set => this.RaiseAndSetIfChanged(ref background, value);
        }
    }
}
