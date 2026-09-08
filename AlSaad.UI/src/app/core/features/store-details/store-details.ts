import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { StoreService } from '../../services/store-service';
import { Stores, getStoreStatusLabel } from '../../models/Stores';

@Component({
  selector: 'app-store-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './store-details.html',
  styleUrl: './store-details.css',
})
export class StoreDetails implements OnInit{
  store: Stores | null = null;
  isLoading = true;
  errorMessage = '';

  getStatusLabel = getStoreStatusLabel;

  constructor(
    private route: ActivatedRoute,
    private storeService: StoreService
  ) {}
 ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMessage = 'رقم المخزن غير صحيح.';
      this.isLoading = false;
      return;
    }

    this.storeService.getStoreById(id).subscribe({
      next: (data) => {
        this.store = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading store', err);
        this.errorMessage = 'المخزن ده مش موجود أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
  }
}
