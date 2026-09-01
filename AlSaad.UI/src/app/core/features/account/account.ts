import { Component,inject  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthlySummary } from '../../models/MonthlySummary';
import { Transaction  } from '../../models/Transaction';

@Component({
  selector: 'app-account',
  standalone :true,
  imports: [CommonModule],
  templateUrl: './account.html',
  styleUrl: './account.css',
})
export class Account {
   
    currentBalance = 108075;
   clientName = 'عبد الكريم';
   monthlySummary: MonthlySummary[] = [
    { month: 'مارس', year: 2026, netPurchases: 142072, netPayments: 110000 },
    { month: 'أبريل', year: 2026, netPurchases: 56669, netPayments: 80000 },
    { month: 'مايو', year: 2026, netPurchases: 241377, netPayments: 160000 },
    { month: 'يونيو', year: 2026, netPurchases: 0, netPayments: 70000 },
    { month: 'يوليو', year: 2026, netPurchases: 125542, netPayments: 80000 },
    { month: 'أغسطس', year: 2026, netPurchases: 77029, netPayments: 50000 }
  ];
    transactions: Transaction[] = [
    { date: '11/08/2026', operationType: 'إذن صرف', operationValue: 8137, balanceBefore: 72909, balanceAfter: 81046 },
    { date: '24/07/2026', operationType: 'استلام نقدية (Bank)', operationValue: 30000, balanceBefore: 102909, balanceAfter: 72909 },
    { date: '11/07/2026', operationType: 'إذن صرف', operationValue: 40345, balanceBefore: 62564, balanceAfter: 102909 },
    { date: '04/07/2026', operationType: 'إذن صرف', operationValue: 68495, balanceBefore: -5931, balanceAfter: 62564 },
    { date: '20/06/2026', operationType: 'استلام نقدية (Bank)', operationValue: 50000, balanceBefore: 44069, balanceAfter: -5931 }
  ];

  viewStatement(transaction: Transaction): void {
    alert('عرض كشف حساب بتاريخ ' + transaction.date + ' (هيتفعل لاحقًا)');
  }
}
