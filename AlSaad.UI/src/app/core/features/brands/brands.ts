import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BrandService } from '../../services/brand-service';
import { Brand } from '../../models/Brand';
@Component({
  selector: 'app-brands',
  imports: [CommonModule, RouterModule],
  templateUrl: './brands.html',
  styleUrl: './brands.css',
})
export class Brands  implements OnInit { 
 brands: Brand[] = [];
  isLoading = signal(true);
  errorMessage = '';

  constructor(private brandService: BrandService) {}

  ngOnInit(): void {
    this.loadBrands();
  }
   loadBrands(): void {
    this.isLoading.set(true);
    this.errorMessage = '';

    this.brandService.getBrands().subscribe({
      next: (result) => {
        this.brands = result.items;
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error loading brands', err);
        this.errorMessage = 'حصل خطأ في تحميل الماركات، حاول تاني.';
        this.isLoading.set(false);
      },
    });
  }
}
