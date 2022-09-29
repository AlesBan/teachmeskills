using System;
using System.Collections.Generic;
using System.Text;

namespace AttributsIntro
{
    class VersionAttribute : Attribute
    {
        public int Version { get; set; }
        public VersionAttribute(int version)
        {
            Version = version;
        }
    }
}
