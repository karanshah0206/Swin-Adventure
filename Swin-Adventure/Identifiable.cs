using System.Collections.Generic;

namespace Swin_Adventure
{
    public class Identifiable
    {
        private List<string> _identifiers = new List<string>();

        public Identifiable(string[] idents)
        {
            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            foreach (string ident in _identifiers)
            {
                if (id == ident)
                    return true;
            }
            return false;
        }

        public string FirstId
        {
            get {
                return _identifiers.Count > 0 ? _identifiers[0] : "";
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
