﻿namespace Swin_Adventure
{
    public class Path : Game
    {
        private Location _from, _destination;
        private bool _pathLocked;

        public Path(string[] ids, string name, string desc, Location from, Location dest) : base (ids, name, desc)
        {
            _from = from;
            _from.AddExitPath(this);
            _destination = dest;
            _pathLocked = false;
        }

        public Location From
        { get { return _from; } }

        public Location Desetination
        { get { return _destination; } }

        public bool IsTraversable
        { get { return _pathLocked; } }
    }
}