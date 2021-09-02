using System;

namespace Swin_Adventure
{
    abstract class Game
    {
        private string _name, _description;

        public Game(string[] ids, string name, string desc)
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
            get { return ""; }
        }

        virtual public string FullDescription
        {
            get { return ""; }
        }
    }
}
