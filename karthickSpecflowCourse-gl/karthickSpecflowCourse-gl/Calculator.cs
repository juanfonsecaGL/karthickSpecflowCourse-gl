using System;
using System.Collections.Generic;

namespace karthickSpecflowCoursegl
{
    public class Calculator
    {
        List<int> operands;

        public Calculator()
        {
            operands = new List<int>();
            operands.Add(0);
        }

        public void enterNumber(int number) {
            operands.Add(number);       
        }

        public int sumAllNumbers() {
            int sum = 0;
            foreach (int o in operands) {
                sum += o;
            }
            operands.Clear();
            operands.Add(sum);
            return sum;
        }

        public int getLastResult() {
            return operands[0];
        }
    }
}
