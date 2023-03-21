using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.model
{
    public class Person
    {
        private string _phone;
        private string _pname;
        private int _shoeSize;

        public Person()
        {
        }

        public Person(string phone, string pname, int shoeSize)
        {
            _phone = phone;
            _pname = pname;
            _shoeSize = shoeSize;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string Pname
        {
            get => _pname;
            set => _pname = value;
        }

        public int ShoeSize
        {
            get => _shoeSize;
            set => _shoeSize = value;
        }

        public override string ToString()
        {
            return $"{nameof(Phone)}: {Phone}, {nameof(Pname)}: {Pname}, {nameof(ShoeSize)}: {ShoeSize}";
        }
    }
}
