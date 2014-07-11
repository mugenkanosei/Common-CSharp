// This source code is available under the Creative Commons Attribution-ShareAlike License; additional terms may apply.
// License may be found here: http://creativecommons.org/licenses/by-sa/3.0/legalcode
// Original code was written by Michael Meadows and posted to Stackoverflow: http://stackoverflow.com/a/839814

namespace Kihon.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SetOnce<T>
    {
        private readonly object syncLock = new object();
        private readonly bool defaultValueSet;
        private readonly string valueName;
        private bool set;
        private T valueStore;

        public SetOnce(string valueName)
        {
            this.valueName = valueName;
        }

        public SetOnce(string valueName, T defaultValue)
        {
            this.valueName = valueName;
            valueStore = defaultValue;
            defaultValueSet = true;
        }

        public T Value
        {
            get
            {
                lock (syncLock)
                {
                    if (!set && !defaultValueSet) throw new ValueNotSetException(valueName);
                    return valueStore;
                }
            }
            set
            {
                lock (syncLock)
                {
                    if (set) throw new AlreadySetException(valueName);
                    set = true;
                    this.valueStore = value;
                }
            }
        }

        public static implicit operator T(SetOnce<T> toConvert)
        {
            return toConvert.Value;
        }
    }


    public class NamedValueException : InvalidOperationException
    {
        private readonly string valueName;

        public NamedValueException(string valueName, string messageFormat)
            : base(string.Format(messageFormat, valueName))
        {
            this.valueName = valueName;
        }

        public string ValueName
        {
            get { return valueName; }
        }
    }

    public class AlreadySetException : NamedValueException
    {
        private const string MESSAGE = "The value \"{0}\" has already been set.";

        public AlreadySetException(string valueName)
            : base(valueName, MESSAGE)
        {
        }
    }

    public class ValueNotSetException : NamedValueException
    {
        private const string MESSAGE = "The value \"{0}\" has not yet been set.";

        public ValueNotSetException(string valueName)
            : base(valueName, MESSAGE)
        {
        }
    }
}
