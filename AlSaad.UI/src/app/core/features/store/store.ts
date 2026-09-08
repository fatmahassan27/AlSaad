import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StoreService } from '../../services/store-service';
import { Stores, getStoreStatusLabel } from '../../models/Stores';

@Component({
  selector: 'app-store',
  imports: [CommonModule, RouterModule],
  templateUrl: './store.html',
  styleUrl: './store.css',
})
export class Store implements OnInit {

   stores: Stores[] = [];
  isLoading = true;
  errorMessage = '';

  getStatusLabel = getStoreStatusLabel;

  constructor(private storeService: StoreService) {}

  ngOnInit(): void {
    this.loadStores();
  }
    loadStores(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.storeService.getStores().subscribe({
      next: (result) => {
        this.stores = result.items;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading stores', err);
        this.errorMessage = 'حصل خطأ في تحميل المخازن، حاول تاني.';
        this.isLoading = false;
      },
    });
  }
}
