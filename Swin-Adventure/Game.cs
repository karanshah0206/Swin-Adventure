using System;

namespace Swin_Adventure
{
    abstract class Game : Identifiable
    {
        private string _name, _description;

        public Game(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get { return "a " + _name + " (" + base.FirstId + ")"; }
        }

        virtual public string FullDescription
        {
            get { return _description; }
        }
    }
}
