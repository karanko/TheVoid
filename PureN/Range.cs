using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureN
{
    public class Range
    {
        private Dictionary<int, Dictionary<int, KeyValuePair<int,int>>> _data = new Dictionary<int, Dictionary<int, KeyValuePair<int, int>>>();
        private KeyValuePair<int, int> _default = new KeyValuePair<int, int>(1,127);

        public KeyValuePair<int,int> Get(int version,int x)
        {         
            if(_data.ContainsKey(version) && _data[version].ContainsKey(x))
            {         
                    return _data[version][x]; 
            }
            else
            {
                return _default;
            }          
        }
        public KeyValuePair<int, int> Set(int version, int x, int low, int high)
        {
            KeyValuePair<int, int> value = Validate(low, high);
            if (_data.ContainsKey(version))
            {
                if (_data[version].ContainsKey(x))
                {
                    _data[version][x] = value;
                }
                else
                {
                    _data[version].Add(x, value);
                }
            }
            else if(!value.Equals(_default))
            {
                _data.Add(version, new Dictionary<int, KeyValuePair<int, int>>());
                _data[version].Add(x, value);
            }
            return value;
        }
        private KeyValuePair<int, int> Validate(int key,int value)
        {
            return Validate(new KeyValuePair<int, int>(key, value));
        }
        private KeyValuePair<int, int> Validate(KeyValuePair<int, int> data)
        {
            int key = data.Key;
            int value = data.Value;
            if (key > 127)
            {
                key = 127;
            }
            else if (key < _default.Key)
            {
                key = _default.Key;
            }

            if (value > 127)
            {
                value = 127;
            }
            else if (value < _default.Key)
            {
                value = _default.Key;
            }

            if (key == value)
            {
                return Validate(key-1, value+1);
            }

            return new KeyValuePair<int, int>(key, value );
        }        

    }
}
