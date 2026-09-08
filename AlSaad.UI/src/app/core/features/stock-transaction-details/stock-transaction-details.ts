import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { StockTransactionService } from '../../services/stock-transaction-service';
import {
  StockTransaction,
  getTransactionTypeLabel,
  getSourceTypeLabel,
  getStockTransactionStatusLabel,
} from '../../models/StockTransaction';
@Component({
  selector: 'app-stock-transaction-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './stock-transaction-details.html',
  styleUrl: './stock-transaction-details.css',
})
export class StockTransactionDetails implements OnInit {

  transaction: StockTransaction | null = null;
  isLoading = true;
  errorMessage = '';

  getTypeLabel = getTransactionTypeLabel;
  getSourceLabel = getSourceTypeLabel;
  getStatusLabel = getStockTransactionStatusLabel;

  constructor(
    private route: ActivatedRoute,
    private stockTransactionService: StockTransactionService
  ) {}

    ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMessage = 'رقم الحركة غير صحيح.';
      this.isLoading = false;
      return;
    }
      this.stockTransactionService.getStockTransactionById(id).subscribe({
      next: (data) => {
        this.transaction = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading stock transaction', err);
        this.errorMessage = 'الحركة دي مش موجودة أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
  }
}
