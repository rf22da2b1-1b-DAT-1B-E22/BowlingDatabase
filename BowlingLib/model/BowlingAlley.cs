using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.model
{
    public class BowlingAlley
    {
        private int _number;
        private bool _operationalState;

        public BowlingAlley()
        {
        }

        public BowlingAlley(int number, bool operationalState)
        {
            _number = number;
            _operationalState = operationalState;
        }

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public bool OperationalState
        {
            get => _operationalState;
            set => _operationalState = value;
        }

        public override string ToString()
        {
            return $"{nameof(Number)}: {Number}, {nameof(OperationalState)}: {OperationalState}";
        }
    }
}
