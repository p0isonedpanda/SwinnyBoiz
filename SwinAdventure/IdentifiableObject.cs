using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();

            foreach (string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            foreach (string s in _identifiers)
            {
                if (id.ToLower() == s) return true;
            }

            return false;
        }

        public string FirstID
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                else
                {
                    return "";
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
