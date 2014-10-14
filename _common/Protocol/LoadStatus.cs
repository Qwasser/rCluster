using System;

namespace _common.Protocol
{
    public enum LoadStatusType
    {
        Locked,
        Free,
        Limited,
        Adaptive
    }
    [Serializable]
    public struct LoadStatus
    {
        public LoadStatusType LoadType;
        public int Limit;

        public override string ToString()
        {
            var outputString = "Type: " + LoadType;

            if (LoadType == LoadStatusType.Limited)
            {
                outputString += ", Limit: " + Limit;
            }

            return outputString;
        }

        public static bool TryParseString(string data, out LoadStatus status)
        {    
            if (data.IndexOf(';') > 0 && data.IndexOf(';') < data.Length - 1)
            {
                LoadStatusType t;
                bool typeParsed = Enum.TryParse(data.Substring(0, data.IndexOf(';')), true, out t);

                int count;
                bool limitParsed = Int32.TryParse(data.Substring(data.IndexOf(';') + 1), out count);

                if (typeParsed & limitParsed)
                {
                    status = new LoadStatus {Limit = count, LoadType = t};
                    return true;
                }
            }
            status = new LoadStatus();
            return false;
        }
    }
}
