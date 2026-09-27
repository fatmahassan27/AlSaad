import { Component,inject  } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MonthlySummary } from '../../models/MonthlySummary';
import { Transaction  } from '../../models/Transaction';
import { FormsModule } from '@angular/forms';
interface AccountInfo {
  customerName: string;
  accountCode: string;
  balance: number;
  currency: string;
  lastMovementDate: string;
}

@Component({
  selector: 'app-account',
  standalone :true,
  imports: [CommonModule,FormsModule],
  templateUrl: './account.html',
  styleUrl: './account.css',
})
export class Account {
   
    accountInfo: AccountInfo = {
    customerName: 'مؤسسة النور لقطع الغيار',
    accountCode: 'DEMO-001',
    balance: 25400,
    currency: 'الجنيه المصري',
    lastMovementDate: '18/09/2026',
  };
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
    searchTerm = '';
  dateFrom = '';
  dateTo = '';
 
  clearFilters(): void {
    this.searchTerm = '';
    this.dateFrom = '';
    this.dateTo = '';
  }
}
