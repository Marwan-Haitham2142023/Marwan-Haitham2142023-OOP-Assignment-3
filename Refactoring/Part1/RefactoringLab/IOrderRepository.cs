using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab
{
    public interface IOrderRepository
    {
        void Save(int orderId, DateTime processedAt);
    }
}
