namespace Swin_Adventure
{
    public class Path : Game
    {
        private Location _destination;
        private bool _pathLocked;

        public Path(string[] ids, string name, string desc, Location dest) : base (ids, name, desc)
        {
            _destination = dest;
            _pathLocked = false;
        }

        public override string FullDescription
        { get { return "You go through " + base.FullDescription + ". This path takes you to " + _destination.ShortDescription + "."; } }

        public Location Destination
        { get { return _destination; } }
        public bool IsTraversable
        {
            get { return !_pathLocked; }
            set { _pathLocked = !value; }
        }
    }
}
