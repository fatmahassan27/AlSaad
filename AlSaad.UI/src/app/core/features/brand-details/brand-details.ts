import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { BrandService } from '../../services/brand-service';
import { Brand } from '../../models/Brand';
@Component({
  selector: 'app-brand-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './brand-details.html',
  styleUrl: './brand-details.css',
})
export class BrandDetails implements OnInit {

   brand: Brand | null = null;
  isLoading = true;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    private brandService: BrandService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMessage = 'رقم الماركة غير صحيح.';
      this.isLoading = false;
      return;
    }
    this.brandService.getBrandById(id).subscribe({
      next: (data) => {
        this.brand = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading brand', err);
        this.errorMessage = 'الماركة دي مش موجودة أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
  }
}
