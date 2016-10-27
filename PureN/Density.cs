using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureN
{
    public class Density
    {
        private Dictionary<int, Dictionary<int, int>> _data = new Dictionary<int, Dictionary<int, int>>();
        private int _default = 100;

        public int Get(int version,int x)
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
        public int Set(int version, int x, int value)
        {
            value = Validate(value);
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
            else if(value != _default)
            {
                _data.Add(version, new Dictionary<int, int>());
                _data[version].Add(x, value);
            }
            return value;
        }
        private int Validate(int data)
        {
            if(data > 100)
            {
                data = 100;
            }
            else if (data < 0)
            {
                data = 0;
            }
            return data;
        }        

    }
}
