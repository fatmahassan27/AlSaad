import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StockTransactionService } from '../../services/stock-transaction-service';
import {StockTransaction,getTransactionTypeLabel,getSourceTypeLabel,getStockTransactionStatusLabel,} from '../../models/StockTransaction';
@Component({
  selector: 'app-stock-transactions',
  imports: [CommonModule, RouterModule],
  templateUrl: './stock-transactions.html',
  styleUrl: './stock-transactions.css',
})
export class StockTransactions  implements OnInit {

 transactions: StockTransaction[] = [];
  isLoading = signal(true);
  errorMessage = '';

  getTypeLabel = getTransactionTypeLabel;
  getSourceLabel = getSourceTypeLabel;
  getStatusLabel = getStockTransactionStatusLabel;

  constructor(private stockTransactionService: StockTransactionService) {}

  ngOnInit(): void {
    this.loadTransactions();
  }
  loadTransactions(): void {
    this.isLoading.set(true);
    this.errorMessage = '';

    this.stockTransactionService.getStockTransactions().subscribe({
      next: (result) => {
        this.transactions = result.items;
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error loading stock transactions', err);
        this.errorMessage = 'حصل خطأ في تحميل حركات المخزون التفصيلية، حاول تاني.';
        this.isLoading.set(false);
      },
    });
  }
}
